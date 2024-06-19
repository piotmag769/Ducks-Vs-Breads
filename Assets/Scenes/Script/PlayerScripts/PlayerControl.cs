using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float baseMovementSpeed;

    public float movementSpeed;
    public bool isMoving { set; get; }
    private PlayerKeyBindings playerKeyBindings;
    public Vector3 moveDirection;
    public LayerMask solidObjectsLayer;
    public AudioSource src;
    public AudioClip step, waterStep;

    void Start()
    {
        movementSpeed = baseMovementSpeed;
        playerKeyBindings = PlayerKeyBindings.GetInstance();
    }

    void Update()
    {
        GatherInputInfo();
        Move();
    }

    void GatherInputInfo()
    {
        Vector3 directionVector = Vector3.zero;
        if (Input.GetKey(playerKeyBindings.moveUp))
        {
            directionVector.y = 1;
        }
        if (Input.GetKey(playerKeyBindings.moveDown))
        {
            directionVector.y = -1;
        }
        if (Input.GetKey(playerKeyBindings.moveRight))
        {
            directionVector.x = 1;
        }
        if (Input.GetKey(playerKeyBindings.moveLeft))
        {
            directionVector.x = -1;
        }
        directionVector.Normalize();
        moveDirection = directionVector;

        if(directionVector.sqrMagnitude > Mathf.Epsilon) isMoving = true;
        else isMoving = false;

    }

    void Move()
    {
        if (isMoving) {
            Vector3 targetPosition = Vector3.MoveTowards(transform.position, transform.position + moveDirection, movementSpeed * Time.deltaTime);
            if (IsWalkable(targetPosition)) {
                if (movementSpeed > 3)
                {
                    src.clip = waterStep;
                }
                else
                {
                    src.clip = step;
                }
                src.Play();
                transform.position = targetPosition;
            }
        }
    }

    bool IsWalkable(Vector3 targetPosition)
    {
        return Physics2D.OverlapCircle(targetPosition, 0.2f, solidObjectsLayer) == null;
    }

}
