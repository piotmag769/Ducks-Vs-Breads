using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponRotationController : MonoBehaviour
{
    public Vector2 weaponDirection;
    private PlayerKeyBindings playerKeyBindings;

    [SerializeField]
    public bool blockWeaponRotation;
    [SerializeField]
    private float playerOffset;
    private Transform playerTransform;

    private Vector3 previousWeaponPosition;
    void Start()
    {
        playerKeyBindings = PlayerKeyBindings.GetInstance();
        playerTransform = FindObjectOfType<PlayerControl>().transform;
        Debug.Log(playerTransform);
    }

    void Update()
    {
        Vector2 weaponDirection = GetWeaponDirection();
        SetWeaponPosition(weaponDirection);
        SetWeaponDirection(weaponDirection);
    }

    private void SetWeaponDirection(Vector2 weaponDirection)
    {
        if (!blockWeaponRotation)
        {
            transform.up = weaponDirection;
        }
    }

    private void SetWeaponPosition(Vector2 weaponDirection)
    {
        if(!blockWeaponRotation)
        {
            Vector3 weaponPosition = new Vector3(weaponDirection.x, weaponDirection.y, 0);
            if(weaponPosition.magnitude >= 1)
            {
                weaponPosition.Normalize();
            }
            transform.position = playerTransform.position + weaponPosition * playerOffset;
            previousWeaponPosition = weaponPosition;
            Debug.Log(weaponPosition);
        } else {
            transform.position = playerTransform.position + previousWeaponPosition * playerOffset;
        }
    }

    private Vector2 GetWeaponDirection()
    {
        Vector2 relativeCursorPosition = Camera.main.ScreenToWorldPoint(playerKeyBindings.getControllerPosition());
        return new Vector2(
            relativeCursorPosition.x - transform.position.x, 
            relativeCursorPosition.y - transform.position.y
        );
    }
}
