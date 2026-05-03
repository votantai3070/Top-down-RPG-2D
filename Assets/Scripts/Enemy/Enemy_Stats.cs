using UnityEngine;

public class Enemy_Stats : Entity_Stats
{
    private Enemy enemy;

    [Header("Enemy Exp Drop Config")]
    [SerializeField] private float baseExpDrop = 20f;     // EXP base
    [SerializeField] private float expScalingPerLevel = 0.2f; // +20% exp per level player

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    public float GetExpDrop()
    {
        Player player = enemy.GetPlayer();
        int playerLevel = player != null ? player.stats.GetLevel() : 1;

        // EXP up to level player: baseExp * (1 + 0.2 * level)
        return Mathf.Floor(baseExpDrop * (1f + expScalingPerLevel * (playerLevel - 1)));
    }
}
