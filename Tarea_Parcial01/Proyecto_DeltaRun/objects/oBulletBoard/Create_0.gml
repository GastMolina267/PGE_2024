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