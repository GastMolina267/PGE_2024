// En la escena donde defines el diálogo
text[0] = "I'm angry bro";   // NPC habla
text[1] = "Why are you angry?";           // Player habla
text[2] = "Oh no, Sans...";               // NPC habla
text[3] = "I don't understand you bro";          // Player habla

// Indicador de quién habla: 0 = NPC, 1 = Player
speaker[0] = 0;
speaker[1] = 1;
speaker[2] = 0;
speaker[3] = 1;

speaker_sprite[0] = sPapyrusAngry;
speaker_sprite[2] = sPapyrusEmbarrassed;
player_sprite[1] = sSansDefault;  // Sprites del Player
player_sprite[3] = sSansDefault2; 

txtb_sound = snd_TxtPapy;