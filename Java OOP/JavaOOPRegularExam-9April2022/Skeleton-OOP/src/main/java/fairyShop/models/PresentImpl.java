package fairyShop.models;

import static fairyShop.common.ExceptionMessages.PRESENT_ENERGY_LESS_THAN_ZERO;
import static fairyShop.common.ExceptionMessages.PRESENT_NAME_NULL_OR_EMPTY;

public class PresentImpl implements Present {
    private String name;
    private int energyRequired;

    public PresentImpl(String name, int energyRequired) {
        setName(name);
        setEnergyRequired(energyRequired);
    }

    private void setName(String name) {
        if (name == null || name.isBlank()) {
            throw new NullPointerException(PRESENT_NAME_NULL_OR_EMPTY);
        }
        this.name = name;
    }

    private void setEnergyRequired(int energyRequired) {
        if (energyRequired < 0) {
            throw new IllegalArgumentException(PRESENT_ENERGY_LESS_THAN_ZERO);
        }
        this.energyRequired = energyRequired;
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public int getEnergyRequired() {
        return energyRequired;
    }

    @Override
    public boolean isDone() {
        return getEnergyRequired() == 0;
    }

    @Override
    public void getCrafted() {
        if (getEnergyRequired() - 10 < 0) {
            setEnergyRequired(0);
        }
        setEnergyRequired(getEnergyRequired() - 10);
    }
}