using UnityEngine;

public class OrbManager : MonoBehaviour
{
    public static OrbManager instance;

    public float hunterDuration = 10f;
    private EnemyAI[] enemies;

    void Awake()
    {
        instance = this;
        enemies = FindObjectsOfType<EnemyAI>();
    }

    public void ActivateHunterMode(float duration)
    {
        foreach (EnemyAI enemy in enemies)
        {
            enemy.SetVulnerable(true);
        }

        Invoke("DeactivateHunterMode", duration);
    }

    void DeactivateHunterMode()
    {
        foreach (EnemyAI enemy in enemies)
        {
            enemy.SetVulnerable(false);
        }
    }
}
