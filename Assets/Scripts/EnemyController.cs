using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject westWP;
    public GameObject eastWP;
    private float speed = 2f; 
    private float direction = 1f; // direction starts east;
    public AudioClip death;

    // Use this for initialization
    void Start () {
        transform.position = new Vector3(westWP.transform.position.x, transform.position.y, transform.position.z);

    }
	
	// Update is called once per frame
	void Update () {
       /* transform.position = new Vector3(
            Mathf.PingPong(Time.time * speed, eastWP.transform.position.x * 2) + westWP.transform.position.x,
            transform.position.y, transform.position.z);*/
        
            transform.position = new Vector3((Time.deltaTime * speed * direction) + transform.position.x , transform.position.y, transform.position.z);

            if (transform.position.x > eastWP.transform.position.x)
            {
                direction = -1f;
            }
            else if (transform.position.x < westWP.transform.position.x)
            {
                direction = 1f;
            }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "character")
        {
           
            AudioSource.PlayClipAtPoint(death, transform.position);
            Destroy(coll.gameObject);
        }
    }

}
