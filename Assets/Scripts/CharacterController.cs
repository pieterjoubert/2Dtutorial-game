using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public Rigidbody2D rb;
    public Camera camera;
    public bool followCharacter;
    public AudioClip coinCollect;
    private bool airborne = false;
    public float thrust;
    public float maxVelocity;
    private int direction = 0; //0 = facing east

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

            if(direction == 1)
            {
                SpriteRenderer sr = GetComponent<SpriteRenderer>();
                sr.flipX = false;
            }
            direction = 0;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb = GetComponent<Rigidbody2D>();
            if (Mathf.Abs(rb.velocity.x) < maxVelocity)
                rb.AddForce(transform.right * -thrust);
            if (direction == 0)
            {
                SpriteRenderer sr = GetComponent<SpriteRenderer>();
                sr.flipX = true;
            }
            direction = 1;

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb = GetComponent<Rigidbody2D>();
            if (!airborne && Mathf.Abs(rb.velocity.y) < maxVelocity)
            {
                rb.AddForce(transform.up * thrust * 30f);
                airborne = true;
            }
        }

        if (followCharacter)
        {
            Vector3 newPos = new Vector3(this.transform.position.x, this.transform.position.y, -10);
            camera.transform.position = newPos;
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "platform")
        {
            airborne = false;
        }
        else if (coll.gameObject.tag == "ramp")
        {
            rb = GetComponent<Rigidbody2D>();
            if (Mathf.Abs(rb.velocity.y) < maxVelocity)
                rb.AddForce(transform.up * thrust * 50f);
            airborne = true;
        }
        

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
    
        if (coll.gameObject.tag == "coin")
        {
            AudioSource.PlayClipAtPoint(coinCollect, transform.position);
            Destroy(coll.gameObject);
        }
    }
}
