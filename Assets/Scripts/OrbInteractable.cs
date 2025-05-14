using UnityEngine;

public class OrbInteractable : MonoBehaviour
{
    public float hunterDuration = 10f;
    public GameObject interactionPrompt; // Assign your "E to Collect" UI here
    public float interactionDistance = 2f; // Distance in units to trigger prompt

    private Transform playerTransform; // Reference to the player's transform
    private bool isPlayerNearby = false;

    void Start()
    {
        // Get reference to the player's transform
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check if the player is within the interaction distance
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer <= interactionDistance)
        {
            if (!isPlayerNearby)
            {
                interactionPrompt.SetActive(true);
                isPlayerNearby = true;
            }
        }
        else
        {
            if (isPlayerNearby)
            {
                interactionPrompt.SetActive(false);
                isPlayerNearby = false;
            }
        }

        // Collect the orb if E is pressed while nearby
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Collect();
        }
    }

    void Collect()
    {
        // Notify the GameManager that an orb was collected
        GameManager.instance.CollectOrb();

        // Destroy the orb
        Destroy(gameObject);

        // Optional: Play sound effect or particle effect
    }
}