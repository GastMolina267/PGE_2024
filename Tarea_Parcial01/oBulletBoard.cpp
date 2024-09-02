/*
----> CÓDIGO ORIGINAL
Crear
current_height = 0;
current_width = 0;

Paso
// Función para ajustar un valor hacia un objetivo
function adjust_value(current_value, target_value) {
    return current_value + ((target_value - current_value) / 2);
}

// Ajustar width y height en una sola línea
current_width = adjust_value(current_width, global.border_width);
current_height = adjust_value(current_height, global.border_height);

// Cambio de tamaño al presionar Control
if keyboard_check_pressed(vk_control) {
    global.border_width = random(600);
    global.border_height = random(800);
}


Dibujar
var border_l = 320 - (current_width/2);
var border_r = 320 + (current_width/2);
var border_u = 384 - current_height;
var border_d = 384;

oSoul.x = clamp(oSoul.x, border_l+8, border_r-8);
oSoul.y = clamp(oSoul.y, border_u+8, border_d-8);

draw_set_color(c_white);
draw_rectangle(border_l - 4, border_u - 4, border_r + 4, border_d + 4, false);
draw_set_color(c_black);
draw_rectangle(border_l, border_u, border_r, border_d, false);

var hp_bardwidth = (global.player_max_hp);
var hp_bardwidth_fill = (global.player_hp);
draw_set_font(fBattleStats);
draw_set_color(c_white);
draw_text(90, 400, global.name + "              LV " + string(global.player_lv));
draw_text(380 + hp_bardwidth, 400, string(global.player_hp) + " / " + string(global.player_max_hp));

draw_text(320, 400, "HP");

draw_set_color(c_red);
draw_rectangle(370, 400, 370 + hp_bardwidth, 418, false);
draw_set_color(c_yellow);
draw_rectangle(370, 400, 370 + hp_bardwidth_fill, 418, false);
*/

/*
----> CÓDIGO MODIFICADO
// Crear
current_height = 0;
current_width = 0;

// Callback para ajustar valores
function adjust_value_callback(current_value, target_value, callback) {
    var new_value = current_value + ((target_value - current_value) / 2);
    callback(new_value);
}

// Función para actualizar ancho y alto
function update_dimensions() {
    adjust_value_callback(current_width, global.border_width, function(value) {
        current_width = value;
    });
    
    adjust_value_callback(current_height, global.border_height, function(value) {
        current_height = value;
    });
}

// Manejo de teclado
function handle_input() {
    if keyboard_check_pressed(vk_control) {
        global.border_width = random(600);
        global.border_height = random(800);
    }
}

// Paso
update_dimensions();
handle_input();

// Dibujar
function draw_borders() {
    var border_l = 320 - (current_width/2);
    var border_r = 320 + (current_width/2);
    var border_u = 384 - current_height;
    var border_d = 384;

    oSoul.x = clamp(oSoul.x, border_l+8, border_r-8);
    oSoul.y = clamp(oSoul.y, border_u+8, border_d-8);

    draw_set_color(c_white);
    draw_rectangle(border_l - 4, border_u - 4, border_r + 4, border_d + 4, false);
    draw_set_color(c_black);
    draw_rectangle(border_l, border_u, border_r, border_d, false);
}

function draw_hp_bar() {
    var hp_bardwidth = (global.player_max_hp);
    var hp_bardwidth_fill = (global.player_hp);

    draw_set_font(fBattleStats);
    draw_set_color(c_white);
    draw_text(90, 400, global.name + "              LV " + string(global.player_lv));
    draw_text(380 + hp_bardwidth, 400, string(global.player_hp) + " / " + string(global.player_max_hp));

    draw_text(320, 400, "HP");

    draw_set_color(c_red);
    draw_rectangle(370, 400, 370 + hp_bardwidth, 418, false);
    draw_set_color(c_yellow);
    draw_rectangle(370, 400, 370 + hp_bardwidth_fill, 418, false);
}

// Llamada a funciones de dibujo
draw_borders();
draw_hp_bar();


*/