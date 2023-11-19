package handball.entities.gameplay;

import handball.entities.equipment.Equipment;
import handball.entities.team.Team;

import java.util.Collection;

public class Indoor extends BaseGameplay{
    private static final int CAPACITY = 250;
    public Indoor(String name) {
        super(name, CAPACITY);
    }

}
