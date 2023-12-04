package football;


import org.testng.Assert;
import org.testng.annotations.Test;

import java.util.ArrayList;
import java.util.Collection;


import junit.framework.TestCase;
public class FootballTeamTests {

    @Test
    public void testConstructor() {
        FootballTeam footballTeam = new FootballTeam("demo", 1);
        Assert.assertEquals("demo", footballTeam.getName());
        Assert.assertEquals(1, footballTeam.getVacantPositions());
    }

    @Test(expectedExceptions = NullPointerException.class)
    public void testSetNameWithNull() {
        FootballTeam footballTeam = new FootballTeam(null, 1);
    }

    @Test(expectedExceptions = NullPointerException.class)
    public void testSetNameWithSpace() {
        FootballTeam footballTeam = new FootballTeam("   ", 1);
    }

    @Test(expectedExceptions = IllegalArgumentException.class)
    public void testSetVacantPositionWithBellowZero() {
        FootballTeam footballTeam = new FootballTeam("demo", -1);
    }

    @Test
    public void testListFootballers() {
        FootballTeam footballTeam = new FootballTeam("demo", 1);
        Collection<Footballer> footballers = new ArrayList<>(1);

        Footballer footballer = new Footballer("pesho");
        footballers.add(footballer);
        footballTeam.addFootballer(footballer);
        Assert.assertEquals(1, footballTeam.getCount());
        Assert.assertEquals(1, footballers.size());

    }

    @Test(expectedExceptions = IllegalArgumentException.class)
    public void testAddFootballerThrowException() {
        FootballTeam footballTeam = new FootballTeam("demo", 1);
        Collection<Footballer> footballers = new ArrayList<>(1);

        Footballer footballer = new Footballer("pesho");
        Footballer footballer2 = new Footballer("pesho2");

        footballTeam.addFootballer(footballer);
        footballTeam.addFootballer(footballer2);

    }

    @Test(expectedExceptions = IllegalArgumentException.class)
    public void testFootballerForSaleThrowException() {
        FootballTeam footballTeam = new FootballTeam("demo", 1);
        Footballer footballer = new Footballer("pesho");
        footballTeam.addFootballer(footballer);
        footballTeam.footballerForSale("pesho2");
    }

    @Test
    public void testFootballerForSale() {
        FootballTeam footballTeam = new FootballTeam("demo", 1);
        Footballer footballer = new Footballer("pesho");
        footballTeam.addFootballer(footballer);
        footballTeam.footballerForSale("pesho");
        Assert.assertFalse(footballer.isActive());
    }
    @Test(expectedExceptions = IllegalArgumentException.class)
    public void testRemoveFootballerThrowException() {
        FootballTeam footballTeam = new FootballTeam("demo", 1);
        Footballer footballer = new Footballer("pesho");
        footballTeam.addFootballer(footballer);
        footballTeam.removeFootballer("pesho2");
    }
    @Test
    public void testRemoveFootballer() {
        FootballTeam footballTeam = new FootballTeam("demo", 1);
        Footballer footballer = new Footballer("pesho");
        footballTeam.addFootballer(footballer);
        footballTeam.removeFootballer("pesho");
        Assert.assertEquals(0, footballTeam.getCount());
    }
    @Test
    public void testGetStatistics() {
        FootballTeam footballTeam = new FootballTeam("demo", 1);
        Footballer footballer = new Footballer("pesho");
        footballTeam.addFootballer(footballer);
        Assert.assertEquals("The footballer pesho is in the team demo.", footballTeam.getStatistics());
    }
}
