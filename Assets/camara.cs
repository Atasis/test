using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour {

    public Transform target;
    public float interp = 3f;
    public float range = 5f;

    private float z;
    private bool following = false;

	// Use this for initialization
	void Start () {
        z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = new Vector3(target.position.x, target.position.y, z);
        Vector3 cur = transform.position;
        if (following)
        {
            transform.position = new Vector3(Mathf.Lerp(cur.x, target.position.x, interp * Time.deltaTime), Mathf.Lerp(cur.y, target.position.y, interp * Time.deltaTime), z);
            Vector3 dif = target.position - transform.position;
            if (dif.magnitude < range)
            {
                following = false;
            }
        }
        else
        {
            Vector3 dif = target.position - transform.position;
            if (dif.magnitude > range)
            {
                following = true;
            }
        }
    }
}
