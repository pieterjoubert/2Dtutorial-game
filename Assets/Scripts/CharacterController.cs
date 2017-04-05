using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public Rigidbody2D rb;
    private bool airborne = false;
    public float thrust;
    public float maxVelocity;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            
            rb = GetComponent<Rigidbody2D>();
            if(Mathf.Abs(rb.velocity.x) < maxVelocity)
                rb.AddForce(transform.right * thrust);
         
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb = GetComponent<Rigidbody2D>();
            if (Mathf.Abs(rb.velocity.x) < maxVelocity)
                rb.AddForce(transform.right * -thrust);
            
           
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb = GetComponent<Rigidbody2D>();
            if (!airborne && Mathf.Abs(rb.velocity.y) < maxVelocity)
            {
                rb.AddForce(transform.up * thrust * 20f);
                airborne = true;
            }
        }

        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "platform")
           airborne = false;

        if (coll.gameObject.tag == "ramp")
        {
            rb = GetComponent<Rigidbody2D>();
            if (Mathf.Abs(rb.velocity.y) < maxVelocity)
                rb.AddForce(transform.up * thrust * 40f);
           
        }

        if (coll.gameObject.tag == "coin")
        {
            Destroy(coll.gameObject);
        }
    }
}
