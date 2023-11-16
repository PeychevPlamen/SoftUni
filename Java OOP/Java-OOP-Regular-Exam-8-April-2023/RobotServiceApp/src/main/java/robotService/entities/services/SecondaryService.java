package robotService.entities.services;

import robotService.entities.robot.Robot;
import robotService.entities.supplements.Supplement;

import java.util.Collection;

public class SecondaryService extends BaseService{
    private static final int CAPACITY = 15;
    public SecondaryService(String name) {
        super(name, CAPACITY);
    }

}
