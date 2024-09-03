// Definir atajos de teclas
var key_confirm = keyboard_check_pressed(vk_enter) || keyboard_check_pressed(ord("Z"));
var key_right = keyboard_check_pressed(vk_right) || keyboard_check_pressed(ord("D"));
var key_left = keyboard_check_pressed(vk_left) || keyboard_check_pressed(ord("A"));

// Cambios de image_index
if key_confirm {
    if image_index == 0 {
        image_index = 1;
    } else if image_index == 1 {
        image_index = 2;
    } else if image_index == 2 {
        room_goto(startRoom);
		var instantiated = instance_create_layer(startX, startY, "Player", oPlayer);
		//instance_destroy();
    }
}

// Movimiento entre imágenes 2 y 3 con teclas derecha e izquierda
if image_index == 2 && key_right {
    image_index = 3;
} else if image_index == 3 && key_left {
    image_index = 2;
}

/*
if image_index = 0 and (keyboard_check_pressed(vk_enter) or keyboard_check_pressed(ord("Z"))){
	image_index = 1;	
} else if image_index = 1 and (keyboard_check_pressed(vk_enter) or keyboard_check_pressed(ord("Z"))){
	image_index = 2;	
} else if image_index = 2 and (keyboard_check_pressed(vk_right) or keyboard_check_pressed(ord("D"))){
	image_index = 3; 	
} else if image_index = 3 and (keyboard_check_pressed(vk_left) or keyboard_check_pressed(ord("A"))){
	image_index = 2; 	
} else if image_index = 2 and (keyboard_check_pressed(vk_enter) or keyboard_check_pressed(ord("Z"))){
	room_goto(rSansRoom);
}
*/