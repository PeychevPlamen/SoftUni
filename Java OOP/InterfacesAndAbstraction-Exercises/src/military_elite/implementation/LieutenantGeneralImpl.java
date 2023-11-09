package military_elite.implementation;

import military_elite.interfaces.LieutenantGeneral;
import military_elite.interfaces.Private;

import java.util.Collection;

public class LieutenantGeneralImpl extends PrivateImpl implements LieutenantGeneral {
    private Collection<Private> privates;


    public LieutenantGeneralImpl(int id, String firstName, String lastName, double salary, Collection<Private> privates) {
        super(id, firstName, lastName, salary);
        this.privates = privates;
    }

    @Override
    public Collection<Private> getPrivates() {
        return privates;
    }

    @Override
    public void addPrivate(Private priv) {
        privates.add(priv);
    }
}
