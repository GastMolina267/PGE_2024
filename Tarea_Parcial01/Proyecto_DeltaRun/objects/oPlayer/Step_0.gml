right_key = keyboard_check(vk_right) or keyboard_check(ord("D"));
left_key = keyboard_check(vk_left) or keyboard_check(ord("A"));
down_key = keyboard_check(vk_down) or keyboard_check(ord("S"));
up_key = keyboard_check(vk_up) or keyboard_check(ord("W"));
// Movimientos
xspd = (right_key - left_key) * move_spd;
yspd = (down_key - up_key) * move_spd;

// Colisiones
if place_meeting(x + xspd, y, oWall) {
    xspd = 0;
}
if place_meeting(x, y + yspd, oWall) {
    yspd = 0;
}

// Correr
if keyboard_check(vk_shift){
	move_spd = run_spd;	
} else {
	move_spd = walk_spd;	
}

if(can_move){
	// Animación
	if xspd != 0 {
	    sprite_index = (xspd > 0) ? sPlayerRight : sPlayerLeft;
	} else if yspd != 0 {
	    sprite_index = (yspd > 0) ? sPlayerDown : sPlayerUp;
	}

	image_speed = (xspd != 0 || yspd != 0) ? 1 : 0;
	if image_speed == 0 {
	    image_index = 0;
	}


	x += xspd;
	y += yspd;	
}