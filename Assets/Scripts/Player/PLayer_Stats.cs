using UnityEngine;

public class Player_Stats : Entity_Stats
{
    private Player player;
    [SerializeField] private LevelSystem levelSystem = new LevelSystem();

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Start()
    {
        levelSystem.OnLevelUp += HandleLevelUp;
        levelSystem.OnExpChanged += HandleExpChanged;
        HandleExpChanged(levelSystem.CurrentExp(), levelSystem.CurrentMaxExp());
    }

    public void GainExp(float amount) => levelSystem.AddExp(amount);
    public int GetLevel() => levelSystem.CurrentLevel();

    private void HandleLevelUp(int newLevel)
    {
        player?.ui?.OpenSkillBoard();
        player.ui?.ingameUI?.ShowLevelUpEffect(newLevel);
    }

    private void HandleExpChanged(float current, float max)
    {
        player.ui?.ingameUI?.UpdateExpBar(current, max);
        player.ui?.ingameUI?.UpdateLevelText(levelSystem.CurrentLevel());
    }
}