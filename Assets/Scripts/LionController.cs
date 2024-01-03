using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionController : MonoBehaviour
{
    // private Animator anim;
    [SerializeField]
    private float movementSpeed;
    private Vector2 movementDirection;
    private GameObject player;

    private bool hasLineOfSight = false;

    private Vector2 lastKnownPlayerPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        CheckLineOfSight();
        if (hasLineOfSight)
        {
            Move();
        } 
    }

    private void CheckLineOfSight()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);

        if (ray.collider != null)
        {
            bool seesPlayer = ray.collider.CompareTag("Player");
            if (seesPlayer && !hasLineOfSight)
            {
                Debug.Log("player entered line of sight");
            }
            else if (!seesPlayer && hasLineOfSight)
            {
                Debug.Log("player left line of sight");
            }
            hasLineOfSight = seesPlayer;
        }

        // Visualizes Line of Sight Ray
        if (hasLineOfSight)
        {
            Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);

        transform.up = player.transform.position - transform.position;
    }

    private void Move1()
    {
        movementDirection = player.transform.position - transform.position;
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime, Space.World);

        if (movementDirection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime);
        }

    }
}
