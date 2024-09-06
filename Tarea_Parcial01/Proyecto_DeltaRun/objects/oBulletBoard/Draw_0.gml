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