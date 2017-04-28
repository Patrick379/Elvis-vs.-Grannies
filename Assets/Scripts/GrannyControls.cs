using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrannyControls : MonoBehaviour {

    static Animator anim;
    Rigidbody rb;
    GameObject elvis;
    Vector3 velocity;
    public AudioClip fallSound;
    AudioSource source;

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        elvis = GameObject.Find("Big_Vegas");
        velocity = Vector3.zero;
        source = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray groundRay = new Ray(transform.position + Vector3.up, Vector3.down);

        if(!Physics.Raycast(groundRay, out hit))
        {
           
            anim.SetTrigger("isFalling");
            rb.transform.Rotate(Vector3.right * 180 * Time.deltaTime);
            rb.MovePosition(transform.position + Vector3.down* 2 * Time.deltaTime);
            source.PlayOneShot(fallSound, 0.4f);
        }
        if (Vector3.Distance(transform.position, elvis.transform.position) < 5f)
        {
            Vector3 v = elvis.transform.position - transform.position;
		    v.y = 0;
            rb.MoveRotation(Quaternion.LookRotation(v));
		    v *= 0.01f;
		    velocity += v;

            Vector3.ClampMagnitude(velocity, 2f);
		    rb.MovePosition(transform.position + v);
           
            anim.SetTrigger("isMoving");
        }
        

       

    }

   
}
