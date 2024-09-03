if place_meeting(x,y,oPlayer) and oPlayer.can_move && (keyboard_check_pressed(vk_enter) or keyboard_check_pressed(ord("Z"))){
	var instantiated = instance_create_depth(0, 0, -9998, oTextBox);
	instantiated.text = text;
	instantiated.speaker_sprite = speaker_sprite;
	instantiated.txtb_snd = txtb_sound;
}