// Cambio de sala con Alt
if keyboard_check_pressed(vk_space) {
	room_goto(rBattleRoom);
    oPlayer.visible = false;
    oPlayer.x = 0;
    oPlayer.y = 0;
    oPlayer.can_move = false;
}

// Control de pantalla completa
if keyboard_check_pressed(vk_escape) {
    if window_get_fullscreen() {
        window_set_fullscreen(false);  // Salir de pantalla completa
    }
} else if (keyboard_check(vk_alt) and keyboard_check(vk_enter)) {
    if window_get_fullscreen() {
        window_set_fullscreen(false);  // Salir de pantalla completa
    } else {
        window_set_fullscreen(true);   // Entrar a pantalla completa
    }
}