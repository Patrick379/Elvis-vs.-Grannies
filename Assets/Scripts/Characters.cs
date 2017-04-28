using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    public GameObject elvisCharacter;
    private int numGrannies;
    public GameObject granny;
    public new GameObject camera;
    private Vector3 offset;
    
    // Use this for initialization
    void Start()
    {
        numGrannies = 0;
       
        //GameObject granny = Resources.Load("Sporty_Granny/Sporty_Granny", typeof(GameObject)) as GameObject;

        //GameObject grannyClone = Instantiate(granny, new Vector3(elvisCharacter.transform.position.x - 3, 0, elvisCharacter.transform.position.z - 3), Quaternion.identity);

        //grannyClone.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Granny Animator Controller") as RuntimeAnimatorController; ;
           
        StartCoroutine("AddGranny");

    }

    // Update is called once per frame
    void Update()
    {

    }
 
    IEnumerator AddGranny()
    {
        while (numGrannies < 3)
        {

            yield return new WaitForSeconds(3);
            granny = transform.Find("Sporty_Granny " + (numGrannies + 1)).gameObject;
            granny.SetActive(true);
            numGrannies++;
            yield return new WaitForSeconds(5);

        }
        
    }
}