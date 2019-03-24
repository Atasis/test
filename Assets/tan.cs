using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tan : MonoBehaviour {

    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" )
        {
            rb.velocity = Vector2.up * 25;
        }
    }
}
