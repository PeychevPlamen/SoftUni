package military_elite.implementation;

import military_elite.interfaces.Spy;

public class SpyImpl extends SoldierImpl implements Spy {
    private int codeNumber;

    public SpyImpl(int id, String firstName, String lastName, int codeNumber) {
        super(id, firstName, lastName);
        this.codeNumber = codeNumber;
    }
    public void setCodeNumber(int codeNumber) {
        this.codeNumber = codeNumber;
    }
    @Override
    public int getCodeNumber() {
        return codeNumber;
    }
}
