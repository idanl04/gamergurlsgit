using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private float speed;

    private float direction; // left(-1) or right(+1)
    private bool isGrounded = true;
    private bool facingRight = true;

    // Denne metode kaldes netop en gang ..ved opstart
    public void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    public void Update()
    {
        direction = Input.GetAxis("Horizontal"); //Left = -1  .. Right= +1

        rb.velocity = new Vector2(direction * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);

        }


        // Går mod højre..
        if (direction > 0 && facingRight == false)
        {
            Flip();
        }

        //Går mod venste ??
        if (direction < 0 && facingRight == true)
        {
            Flip();
        }
        if (direction > 0)
        {
            //       anim.SetBool("isRunning", true);
            //    }
            //    else if (direction < 0)
            //    {
            //     anim.SetBool("isRunning", true);
            //    }
            //   else
            //     {
            //    anim.SetBool("isRunning", false);
            //   }

        }
    }
        private void Flip()
        {

            Vector3 current = gameObject.transform.localScale;
            current.x = current.x * -1;

            gameObject.transform.localScale = current;
            facingRight = !facingRight;
        }

        // For kun at kunne hoppe på jorden
        private void OnCollisionEnter2D(Collision2D other)
        {

            if (other.gameObject.CompareTag("Floor"))
            {
                isGrounded = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {

            if (other.gameObject.CompareTag("Floor"))
            {
                isGrounded = false;
            }
        }


        // Samle Collectables op
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Collectable") == true)
            {
                string itemType = other.gameObject.GetComponent<Collectable>().itemType;

                if (itemType.Equals("Monster"))
                {
                    Debug.Log("Monster");
                    ScoreManager.instance.AddPoint();
                }
                if (itemType.Equals("Snus"))
                {
                    Debug.Log("Snus");
                    ScoreManager.instance.AddPoint();
                    ScoreManager.instance.AddPoint();
                    ScoreManager.instance.AddPoint();
                    ScoreManager.instance.AddPoint();
                    ScoreManager.instance.AddPoint();
                }
                Debug.Log("i was here..");
                Destroy(other.gameObject); // For at fjerne collectables fra scene
            }
        }

    private void OnLevelWasLoaded(int level)
    {
        FindStartPos();
    }

    void FindStartPos()
    {
        transform.position = GameObject.FindGameObjectWithTag("StartPos").transform.position;
    }



}
