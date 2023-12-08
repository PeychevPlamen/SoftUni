package fairyShop.core;

import fairyShop.models.*;
import fairyShop.repositories.HelperRepository;
import fairyShop.repositories.PresentRepository;
import fairyShop.repositories.Repository;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.stream.Collectors;

import static fairyShop.common.ConstantMessages.*;
import static fairyShop.common.ExceptionMessages.*;

public class ControllerImpl implements Controller {
    private Repository<Helper> helperRepository = new HelperRepository<>();
    private Repository<Present> presentRepository = new PresentRepository<>();

    @Override
    public String addHelper(String type, String helperName) {
        Helper helper;
        switch (type) {
            case "Happy":
                helper = new Happy(helperName);
                break;
            case "Sleepy":
                helper = new Sleepy(helperName);
                break;
            default:
                throw new IllegalArgumentException(HELPER_TYPE_DOESNT_EXIST);
        }
        helperRepository.add(helper);
        return String.format(ADDED_HELPER, type, helperName);
    }

    @Override
    public String addInstrumentToHelper(String helperName, int power) {
        Instrument instrument = new InstrumentImpl(power);
        Helper helper = helperRepository.findByName(helperName);

        if (helper == null) {
            throw new IllegalArgumentException(HELPER_DOESNT_EXIST);
        }
        this.helperRepository.getModels().stream()
                .filter(h -> h.getName().equals(helperName))
                .findFirst()
                .ifPresent(h -> h.addInstrument(instrument));

        return String.format(SUCCESSFULLY_ADDED_INSTRUMENT_TO_HELPER, power, helperName);
    }

    @Override
    public String addPresent(String presentName, int energyRequired) {
        Present present = new PresentImpl(presentName, energyRequired);
        presentRepository.add(present);
        return String.format(SUCCESSFULLY_ADDED_PRESENT, presentName);
    }

    @Override
    public String craftPresent(String presentName) {
        Present present = presentRepository.findByName(presentName);
        List<Helper> helpersCanWork = helperRepository.getModels().stream().filter(helper -> helper.getEnergy() > 50)
                .collect(Collectors.toList());
        Shop shop = new ShopImpl();
        if (helpersCanWork.isEmpty()) {
            throw new IllegalArgumentException(NO_HELPER_READY);
        }
        int instrumentsBrokeCount = 0;
        String isDonePresent = "not done";

        for (Helper helper : helpersCanWork) {
            shop.craft(present, helper);
            instrumentsBrokeCount += (int) (instrumentsBrokeCount + helper.getInstruments().stream().filter(Instrument::isBroken).count());
            if (present.isDone()) {
                isDonePresent = "done";
                break;
            }
        }

        StringBuilder sb = new StringBuilder();
        sb.append(String.format(PRESENT_DONE, presentName, isDonePresent));
        sb.append(String.format(COUNT_BROKEN_INSTRUMENTS, instrumentsBrokeCount));

        return sb.toString().trim();
    }

    @Override
    public String report() {
        int size = (int) presentRepository.getModels().stream().filter(Present::isDone).count();
        List<String> collect = helperRepository.getModels().stream()
                .map(helper -> String.format("Name: %s%n" +
                                "Energy: %d%n" +
                                "Instruments: %d not broken left%n", helper.getName(), helper.getEnergy(),
                        (int) helper.getInstruments().stream()
                                .filter(instrument -> !instrument.isBroken())
                                .count())).collect(Collectors.toList());
        return String.format("%d presents are done!%n", size) + String.format("Helpers info:%n") + String.join("", collect).trim();
    }
}
