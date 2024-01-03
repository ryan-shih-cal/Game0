using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    private Vector2 movementDirection;


    void Update()
    {
        Move();
    }

    private void Move()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector2(Horizontal, Vertical).normalized;
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime, Space.World);
    }
}
