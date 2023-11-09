package military_elite.implementation;

import military_elite.interfaces.Mission;

public class MissionImpl implements Mission {
    private static final String IN_PROGRESS = "inProgress";
    private static final String FINISHED = "finished";
    private String codeName;
    private String state;

    public MissionImpl(String partName, String state) {
        this.codeName = partName;
        setState(state);
    }

    @Override
    public String getCodeName() {
        return codeName;
    }

    @Override
    public String getState() {
        return state;
    }

    public void setState(String state) {
        if (IN_PROGRESS.equals(state) || FINISHED.equals(state)) {
            this.state = state;
        }
    }
}
