if (place_meeting(x, y, oPlayer) && oPlayer.can_move && (keyboard_check_pressed(vk_enter) || keyboard_check_pressed(ord("Z")))) {
    var instantiated = instance_create_depth(0, 0, -9998, oTextBox);
    instantiated.text = text;

    // Ajustar tamaño de los arrays 'speaker', 'speaker_sprite', y 'player_sprite'
    var text_len = array_length(text);
    array_resize(speaker, text_len);
    array_resize(speaker_sprite, text_len);
    array_resize(player_sprite, text_len);

    // Inicializar valores predeterminados si no están definidos
    for (var i = 0; i < text_len; i++) {
        if (speaker[i] == undefined) {
            speaker[i] = 1;  // Por defecto, el Player habla
        }
        if (speaker_sprite[i] == undefined) {
            speaker_sprite[i] = noone;  // Sin sprite de NPC por defecto
        }
        if (player_sprite[i] == undefined) {
            player_sprite[i] = noone;  // Sprite invisible del Player por defecto
        }
    }

    // Asignar los valores a la instancia de oTextBox
    instantiated.speaker = speaker;
    instantiated.speaker_sprite = speaker_sprite;
    instantiated.player_sprite = player_sprite;
    instantiated.txtb_snd = txtb_sound;
    instantiated.txtb_sound_player = txtb_sound_player;
    instantiated.is_npc_dialog = is_npc_dialog;
}