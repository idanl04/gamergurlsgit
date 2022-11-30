using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour
{
    public bool isPatrolling;
    public float walkingSpeed;
    public float distance;
    public float direction = 1;

    private Rigidbody2D rb;
    private Vector2 startPos;
    private Vector2 endPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isPatrolling = true;
        startPos = new Vector2(transform.position.x, transform.position.y);
        endPos = new Vector2(transform.position.x + distance, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPatrolling == true)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        rb.velocity = new Vector2(walkingSpeed * Time.fixedDeltaTime * direction, rb.velocity.y);
        if (transform.position.x > endPos.x)
            direction = -1;
        if (transform.position.x < startPos.x)
            direction = 1;
    }
}
