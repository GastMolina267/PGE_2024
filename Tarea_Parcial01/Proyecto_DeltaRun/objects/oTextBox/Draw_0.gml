// Callback para el setup
function setup_textbox() {
    oPlayer.can_move = false;
    draw_set_font(fText);
    draw_set_valign(fa_top);
    draw_set_halign(fa_left);

    page_number = array_length(text);
    for (var p = 0; p < page_number; p++) {
        text_length[p] = string_length(text[p]);
        text_x_offset[p] = 80;  // Valor por defecto de desplazamiento del texto
        portrait_x_offset[p] = 50;
        line_width = textbox_width - border*2 - text_x_offset[p];
        
        // Determinar si el hablante es el NPC o el Player
        if (speaker[p] == 0) {  // NPC
            if (speaker_sprite[p] == noone) {
                text_x_offset[p] = 15;  // No hay sprite del NPC, ajustar texto a la izquierda
                line_width = textbox_width - border*2;
            }
        } else {  // Player
            if (player_sprite[p] == sInvisible) {  // Si el sprite es invisible, no dejar espacio
                text_x_offset[p] = 15;  // Ajustar texto sin espacio para sprite
                line_width = textbox_width - border*2;
            } else if (player_sprite[p] != noone) {  // Si hay un sprite visible del player
                text_x_offset[p] = 80;  // Dejar espacio para el sprite
                line_width = textbox_width - border*2 - text_x_offset[p];
            }
        }
    }
}


// Callback para actualizar el texto
function update_text() {
    if (draw_char < text_length[page]) {
        draw_char += text_speed;
        draw_char = clamp(draw_char, 0, text_length[page]);

        // Verificar si el carácter ha cambiado y reproducir el sonido
        if old_draw_char != draw_char {
            if (speaker[page] == 0) {
                audio_play_sound(txtb_snd, 10, false);  // Sonido del NPC
            } else if (speaker[page] == 1) {
                audio_play_sound(txtb_sound_player, 10, false);  // Sonido del Player
            }
        }

        old_draw_char = draw_char;
    }
}

// Callback para avanzar páginas
function handle_page_navigation() {
    if (confirm_key) {
        if (draw_char == text_length[page]) {
            if (page < page_number - 1) {
                page++;
                draw_char = 0;

                // Reproducir el sonido adecuado para el siguiente hablante
                if (speaker[page] == 0) {
                    audio_play_sound(txtb_snd, 10, false);
                } else if (speaker[page] == 1) {
                    audio_play_sound(txtb_sound_player, 10, false);
                }

            } else {
                oPlayer.can_move = true;
                instance_destroy();
            }
        }
    } else if (skip_key && draw_char != text_length[page]) {
        draw_char = text_length[page];
    }
}

// Callback para dibujar el texto
function draw_textbox() {
    txtb_image += txtb_image_spd;
    var txtb_sprite_w = sprite_get_width(txtb_sprite);
    var txtb_sprite_h = sprite_get_height(txtb_sprite);

    // Dibujar el cuadro de texto
    draw_sprite_ext(txtb_sprite, txtb_image, textbox_x, textbox_y, textbox_width / txtb_sprite_w, textbox_height / txtb_sprite_h, 0, c_white, 1);
	
    // Dibujar el sprite del hablante
    if (speaker[page] == 0 && speaker_sprite[page] != noone) {  // NPC está hablando
        var _speaker_x = textbox_x + portrait_x_offset[page];
        sprite_index = speaker_sprite[page];
        if (draw_char == text_length[page]) {
            image_index = 0;  // Resetear la animación del sprite cuando termine de hablar
        }
        draw_sprite_ext(sprite_index, image_index, _speaker_x, textbox_y + (textbox_height / 2), 55 / sprite_width, 55 / sprite_height, 0, c_white, 1);
    } else if (speaker[page] == 1 && player_sprite[page] != noone) {  // Player está hablando
        var _speaker_x = textbox_x + portrait_x_offset[page];
        sprite_index = player_sprite[page];
        if (draw_char == text_length[page]) {
            image_index = 0;  // Resetear la animación del sprite cuando termine de hablar
        }
        draw_sprite_ext(sprite_index, image_index, _speaker_x, textbox_y + (textbox_height / 2), 55 / sprite_width, 55 / sprite_height, 0, c_white, 1);
    }
    
    // Dibujar el texto del diálogo
    var _drawtext = string_copy(text[page], 1, draw_char);
    draw_text_ext(textbox_x + text_x_offset[page] + border, textbox_y + border, _drawtext, line_sep, line_width);
}

// Obtención de entradas
confirm_key = keyboard_check_pressed(ord("Z")) or keyboard_check_pressed(vk_enter);
skip_key = keyboard_check_pressed(ord("X")) or keyboard_check_pressed(vk_shift);
textbox_x = camera_get_view_x(view_camera[0]) + 20;
textbox_y = camera_get_view_y(view_camera[0]) + 165;

// Setup
if (!setup) {
    setup_textbox();
    setup = true;
}

// Actualización del texto
update_text();

// Manejo de la navegación entre páginas
handle_page_navigation();

// Dibujo del textBox
draw_textbox();