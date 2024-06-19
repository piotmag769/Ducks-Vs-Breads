using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    public Vector2 directionToPlayer;
    private Transform playerTransform;

    void Awake()
    {
        playerTransform = FindObjectOfType<PlayerControl>().transform;
    }

    void Update()
    {
        directionToPlayer = (playerTransform.position - transform.position).normalized;
    }
}
