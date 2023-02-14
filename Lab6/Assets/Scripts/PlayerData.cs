[System.Serializable]
public class PlayerData
{
    public string name;
    public int health;
    public int level;

    public PlayerData(PlayerBehavior player)
    {
        name = player.playerName;
        health = player.playerHealth;
        level = player.playerLevel;
    }
}
