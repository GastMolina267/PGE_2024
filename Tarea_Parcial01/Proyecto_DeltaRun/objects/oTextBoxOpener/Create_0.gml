text[0] = "Hola, soy un NPC."; 
speaker = [];  // Inicializar el array de speakers
speaker[0] = 1;  // 1 representa al Player por defecto
speaker_sprite = [];  // Inicializar el array de sprites de speaker
speaker_sprite[0] = sPapyrusDefault;  // Cambia a un sprite específico para el NPC
txtb_sound = snd_TxtSans;
player_sprite = [];
player_sprite[0] = sSansDefault;
txtb_sound_player = snd_TxtSans;
is_npc_dialog = false;  // Inicializar la variable que indica si es diálogo con NPC