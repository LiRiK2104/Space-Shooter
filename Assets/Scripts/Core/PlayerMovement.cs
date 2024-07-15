using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementZone))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0.1f, 10)] private float speed;

    private PlayerMovementZone _movementZone;

    
    private void Awake()
    {
        _movementZone = GetComponent<PlayerMovementZone>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 direction = new (x, y);
        Move(direction);
    }


    private void Move(Vector2 direction)
    {
        Vector3 offset = direction * Time.deltaTime * speed;

        transform.position = _movementZone.GetClampedPosition(
            transform.position + offset, transform.localScale);
    }
}
