if place_meeting(x,y, oPlayer) and !instance_exists(oTransition){
	var instantiated = instance_create_depth(0,0, -9999, oTransition);
	instantiated.target_x = target_x;
	instantiated.target_y = target_y;
	instantiated.target_rm = target_rm;
}

/*
if (room == rSansRoom){
    target_rm = rHallRoom;
} else if (room == rHallRoom){
    target_rm = rSansRoom;
}
*/