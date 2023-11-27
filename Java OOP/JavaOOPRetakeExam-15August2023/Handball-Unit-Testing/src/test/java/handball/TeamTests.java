package handball;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

public class TeamTests {
    private Team team;
    private static final HandballPlayer handballPlayer = new HandballPlayer("Pesho");

    @Before
    public void prepareTeam(){
        team = new Team("SoftUni", 1);
        team.add(handballPlayer);
    }

    @Test
    public void testTeamConstructorCreateObject(){
        Assert.assertEquals("SoftUni", team.getName());
        Assert.assertEquals(1, team.getPosition());
        Assert.assertEquals(1, team.getCount());
    }
    @Test (expected = NullPointerException.class)
    public void testSetNameWithNull(){
       team = new Team(null, 2);
    }
    @Test (expected = NullPointerException.class)
    public void testSetNameWithEmptyString(){
        team = new Team("     ", 2);
    }
    @Test
    public void testGetNameReturnCorrectName(){
        Assert.assertEquals("SoftUni", team.getName());
    }
    @Test
    public void testGetPositionReturnCorrect(){
        Assert.assertEquals(1, team.getPosition());
    }
    @Test (expected = IllegalArgumentException.class)
    public void testPositionWithNegativeNumber(){
        team = new Team("SoftUni", -2);
    }
    @Test (expected = IllegalArgumentException.class)
    public void testAddPlayerInFullTeam(){
        HandballPlayer handballPlayer = new HandballPlayer("Joni");
        team.add(handballPlayer);
    }
    @Test (expected = IllegalArgumentException.class)
    public void testRemoveNoExistTeam(){
        team.remove("Toni");
    }
    @Test
    public void testRemoveTeam(){
        team.remove("Pesho");
        Assert.assertEquals(0, team.getCount());
    }
    @Test
    public void testPlayerFromAnotherTeam(){
        team.playerForAnotherTeam("Pesho");
        Assert.assertFalse(handballPlayer.isActive());

    }

    @Test(expected = IllegalArgumentException.class)
    public void testPlayerFromAnotherTeamThrowException() {
        team.playerForAnotherTeam("Toni");
    }
    @Test
    public void testGetStatisticsReturnCorrectMessage() {
        team.getStatistics().equals("The player Pesho is in the team SoftUni.");
    }
}
