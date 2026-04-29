using UnityEngine;

public class DropSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] dropPrefabs;
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    public void SpawnDrop()
    {
        if (dropPrefabs.Length == 0)
            return;

        int randomIndex = Random.Range(0, dropPrefabs.Length);
        GameObject go = ObjectPool.instance.Spawn(dropPrefabs[randomIndex].gameObject.name, transform.position, Quaternion.identity);

        if (go.TryGetComponent(out SkillObject_Soul soul))
        {
            Player player = enemy.player.GetComponent<Player>();
            if (player == null)
            {
                Debug.LogError("Player reference is null in DropSystem. Cannot setup soul.");
                return;
            }


            Skill_AbsorbSoul absorbSoul = player.skillManager.GetSkillByType(SkillType.AbsorbSoul).GetComponent<Skill_AbsorbSoul>();

            bool canMove =
                Vector2.Distance(soul.transform.position, player.transform.position)
                < absorbSoul.checkEnemyRadius;

            soul.SetupSoul(player.skillManager.absorbSoul, canMove, player.skillManager.absorbSoul.speedOfSoul, enemy.player);
        }
    }
}
