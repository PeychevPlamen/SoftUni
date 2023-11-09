package military_elite.implementation;

import com.sun.jdi.request.StepRequest;
import military_elite.interfaces.Repair;

public class RepairImpl implements Repair {
    private String partName;
    private int hoursWorked;

    public RepairImpl(String partName, int hoursWorked) {
        this.partName = partName;
        this.hoursWorked = hoursWorked;
    }


    @Override
    public String getPartName() {
        return null;
    }

    @Override
    public int getHoursWorked() {
        return 0;
    }
}
