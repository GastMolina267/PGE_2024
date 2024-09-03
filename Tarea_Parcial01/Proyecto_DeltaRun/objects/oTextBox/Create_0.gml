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
