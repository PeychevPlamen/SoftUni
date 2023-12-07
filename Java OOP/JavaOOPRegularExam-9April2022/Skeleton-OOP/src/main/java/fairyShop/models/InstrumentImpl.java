package fairyShop.models;

import static fairyShop.common.ExceptionMessages.*;

public class InstrumentImpl implements Instrument {
    private int power;

    public InstrumentImpl(int power) {
        setPower(power);
    }

    private void setPower(int power) {
        if (power < 0) {
            throw new IllegalArgumentException(INSTRUMENT_POWER_LESS_THAN_ZERO);
        }
        this.power = power;
    }


    @Override
    public int getPower() {
        return power;
    }

    @Override
    public void use() {
        if (getPower() - 10 < 0) {
            setPower(0);
        }
        setPower(getPower() - 10);
    }

    @Override
    public boolean isBroken() {
        return getPower() == 0;
    }
}
