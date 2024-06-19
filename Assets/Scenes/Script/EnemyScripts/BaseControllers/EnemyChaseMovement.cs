using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseMovement : MonoBehaviour
{
    public float movementSpeed;
    private PlayerAwarenessController targetDirectionController;
    private Vector3 targetRelativePosition;
    void Awake()
    {
        targetDirectionController = GetComponent<PlayerAwarenessController>();
    }

    void Update()
    {
        UpdateTargetDirection();
        MoveTowardsTarget();
    }

    private void UpdateTargetDirection()
    {
        targetRelativePosition = targetDirectionController.directionToPlayer;
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + targetRelativePosition, movementSpeed * Time.deltaTime);
    }
}
