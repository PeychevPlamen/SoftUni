package military_elite.interfaces;

import java.util.Collection;

public interface LieutenantGeneral {
    Collection<Private> getPrivates();
    void addPrivate(Private priv);

}
