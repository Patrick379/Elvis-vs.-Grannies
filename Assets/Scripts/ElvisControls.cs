using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ElvisControls : MonoBehaviour {

    static Animator anim;
    NavMeshAgent agent;
    public Transform goal;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        //agent.destination = goal.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
                anim.SetTrigger("isMoving");
            }
        }
        
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.name.Contains("Cube"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Lose");

        }
    }
}
