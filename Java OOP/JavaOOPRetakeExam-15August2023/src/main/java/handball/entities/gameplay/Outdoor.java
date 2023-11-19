package handball.entities.gameplay;

import handball.entities.equipment.Equipment;
import handball.entities.team.Team;

import java.util.Collection;

public class Outdoor extends BaseGameplay{
private static final int CAPACITY = 150;
    public Outdoor(String name) {
        super(name, CAPACITY);
    }

}
