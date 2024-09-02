/*
---> CÓDIGO ORIGINAL

Crear
// Parámetros del TextBox
textbox_width = 275;
textbox_height = 68;
border = 8;
line_sep = 15;
line_width = textbox_width - border*2;
txtb_sprite = sTextBox;
txtb_image = 0;
txtb_image_spd = 0;
txtb_snd = snd_TxtSans;
// El Texto
page = 0;
page_number = 0;
text[0] = "text";
text_length[0] = string_length(text[0]);
draw_char = 0;
old_draw_char = 0;
text_speed = 0.6;
setup = false;
speaker_sprite[0] = noone;



Dibujar
confirm_key = keyboard_check_pressed(ord("Z")) or keyboard_check_pressed(vk_enter);
skip_key = keyboard_check_pressed(ord("X")) or keyboard_check_pressed(vk_shift);
textbox_x = camera_get_view_x(view_camera[0]) + 20;
textbox_y = camera_get_view_y(view_camera[0]) + 165;
// Setup
if(setup == false){
	setup = true;
	
	oPlayer.can_move = false;
	
	draw_set_font(fText);
	draw_set_valign(fa_top);
	draw_set_halign(fa_left);
	
	// Recorrer las páginas
	page_number = array_length(text);
	for(var p = 0; p < page_number; p++){
		// Encuentre cuántos caracteres hay en cada página y 
		// almacene ese número en una matriz de longitud de texto	
		text_length[p] = string_length(text[p]);
		
		// Obtener la posición x para el cuadro de texto donde 
		// hay retrato del personaje
		text_x_offset[p] = 80;
		portrait_x_offset[p] = 50;
		line_width = textbox_width - border*2 - text_x_offset[p];
		// no hay retrato de personaje
		if speaker_sprite[0] == noone {
			text_x_offset[p] = 15;
			line_width = textbox_width - border*2;
		}
	}
}
// Escribiendo texto
if draw_char < text_length[page]{
	draw_char += text_speed;
	draw_char = clamp(draw_char, 0, text_length[page]);
}
// Hojear páginas
if confirm_key{
	// Si la escritura está hecha
	if draw_char == text_length[page]{
		// Próxima página
		if page < page_number-1{
			page++;
			draw_char = 0;
		}else
		// Destruir el textBox
		{
			oPlayer.can_move = true;
			instance_destroy();
		}
	}
} else if skip_key and draw_char != text_length[page]{
	// Rellenar la página
	draw_char = text_length[page];
}
// Dibujar la textBox
txtb_image += txtb_image_spd;
txtb_sprite_w = sprite_get_width(txtb_sprite);
txtb_sprite_h = sprite_get_height(txtb_sprite);
draw_sprite_ext(txtb_sprite, txtb_image, textbox_x, textbox_y, textbox_width/txtb_sprite_w, textbox_height/txtb_sprite_h, 0, c_white, 1);
// Dibujar el speaker
if speaker_sprite[0] != noone{
	sprite_index = speaker_sprite[page];	
	if draw_char == text_length[page] {image_index = 0};
	var *speaker*x = textbox_x + portrait_x_offset[page];
	
	draw_sprite_ext(sprite_index, image_index, *speaker*x, textbox_y+(textbox_height/2), 55/sprite_width, 55/sprite_height, 0, c_white, 1);
}
// Dibujar el texto
var *drawtext = string*copy(text[page], 1, draw_char);
draw_text_ext(textbox_x + text_x_offset[page] + border, textbox_y + border, *drawtext, line*sep, line_width);

*/


/*
----> CÓDIGO RENOVADO

Dibujar 
// Callback para el setup
function setup_textbox() {
    oPlayer.can_move = false;
    draw_set_font(fText);
    draw_set_valign(fa_top);
    draw_set_halign(fa_left);

    page_number = array_length(text);
    for (var p = 0; p < page_number; p++) {
        text_length[p] = string_length(text[p]);
        text_x_offset[p] = 80;
        portrait_x_offset[p] = 50;
        line_width = textbox_width - border*2 - text_x_offset[p];
        if (speaker_sprite[0] == noone) {
            text_x_offset[p] = 15;
            line_width = textbox_width - border*2;
        }
    }
}

// Callback para actualizar el texto
function update_text() {
    if (draw_char < text_length[page]) {
        draw_char += text_speed;
        draw_char = clamp(draw_char, 0, text_length[page]);
    }
}

// Callback para avanzar páginas
function handle_page_navigation() {
    if (confirm_key) {
        if (draw_char == text_length[page]) {
            if (page < page_number - 1) {
                page++;
                draw_char = 0;
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

    draw_sprite_ext(txtb_sprite, txtb_image, textbox_x, textbox_y, textbox_width / txtb_sprite_w, textbox_height / txtb_sprite_h, 0, c_white, 1);
    
    if (speaker_sprite[0] != noone) {
        var _speaker_x = textbox_x + portrait_x_offset[page];
        sprite_index = speaker_sprite[page];
        if (draw_char == text_length[page]) {
            image_index = 0;
        }
        draw_sprite_ext(sprite_index, image_index, _speaker_x, textbox_y + (textbox_height / 2), 55 / sprite_width, 55 / sprite_height, 0, c_white, 1);
    }

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


Crear
// Parámetros del TextBox
textbox_width = 275;
textbox_height = 68;
border = 8;
line_sep = 15;
line_width = textbox_width - border*2;
txtb_sprite = sTextBox;
txtb_image = 0;
txtb_image_spd = 0;
txtb_snd = snd_TxtSans;

// El Texto
page = 0;
page_number = 0;
text[0] = "text";
text_length[0] = string_length(text[0]);
draw_char = 0;
old_draw_char = 0;
text_speed = 0.6;
setup = false;
speaker_sprite[0] = noone;

*/