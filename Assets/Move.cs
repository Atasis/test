using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public float speed = 5f;
    public float jumpforce = 12f;

    public float fallingspeed;
    private Rigidbody2D rb;
    public bool jumpcheck;
    public bool groundcheck;

    public bool leftmove = true;
    public bool rightmove = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A) && leftmove == true)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            if (Input.GetKey(KeyCode.D) && rightmove == true)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (jumpcheck)
        {
            fallingspeed = rb.velocity.y;
        }else{
            fallingspeed = 0;
        }
        if (Input.GetKeyDown(KeyCode.W) && groundcheck == true && jumpcheck == false && fallingspeed==0)
        {
            jumpcheck = true;
            rb.velocity = Vector2.up*jumpforce;
        }
    }

    void OnCollisionEnter2D(Collision2D selfbody)
    {
        if (selfbody.gameObject.tag == "ground" || selfbody.gameObject.tag == "trap")
        {
            groundcheck = true;
            jumpcheck = false;
        }
    }

    void OnCollisionExit2D(Collision2D selfbodyexit)
    {
        if (selfbodyexit.gameObject.tag == "ground"|| selfbodyexit.gameObject.tag == "trap")
        {
            groundcheck = false;
        }
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (rb.velocity.x > 0)
        {
            rightmove = false;
        }
        if (rb.velocity.x < 0)
        {
            leftmove = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!leftmove)
        {
            leftmove = true;
        
        }
        if (!rightmove)
        {
            rightmove = true;
        }
    }
   
}


