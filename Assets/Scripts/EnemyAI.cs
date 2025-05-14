using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    private bool isVulnerable = false;

    void Update()
    {
        if (isVulnerable)
        {
            RunAway();
        }
        else
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        transform.LookAt(player);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void RunAway()
    {
        Vector3 directionFromPlayer = transform.position - player.position;
        transform.position += directionFromPlayer.normalized * speed * Time.deltaTime;
    }

    public void SetVulnerable(bool state)
    {
        isVulnerable = state;
    }
}