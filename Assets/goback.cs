using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goback : MonoBehaviour {

    public Transform gotoback;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = gotoback.position;
        }
        if (collision.gameObject.tag == "trap")
        {
            
            Destroy(collision.gameObject);
        }
    }
   
}
