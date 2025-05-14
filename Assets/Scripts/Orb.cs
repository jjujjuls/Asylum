using UnityEngine;

public class Orb : MonoBehaviour
{
    public float hunterDuration = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<OrbManager>().ActivateHunterMode(hunterDuration);
            Destroy(gameObject);
        }
    }
}