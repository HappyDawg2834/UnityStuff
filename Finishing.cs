using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finishing : MonoBehaviour
{

    Rigidbody rb;
    float hits = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();
    }
    

    private void OnCollisionEnter(Collision other) 
    {
        float ending = Time.time;
        float bigScore = 100000f / ((hits * 25) + 1) / ending;
        int score = (int) bigScore;
        
        

        if (other.gameObject.tag == "Obstacle")
        {
        hits = hits + 1f;
        }

        if (other.gameObject.tag == "Finish")
        {
        Debug.Log ("You Finished!");
        rb.isKinematic = true;
        Debug.Log ("You had a time of " + ending);
        Debug.Log ("And bumped into " + hits + " obstacle(s)");
        Debug.Log ("This gives you a score of " + score);
        Debug.Log ("click the play button twice if you wish to restart");
        }

        
    }




   /* // Update is called once per frame
    void Update()
    {

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Finish")
        {
            Debug.Log ("You Finished");
            sphereCollider.enable = false;
        }
    }

    }*/
}

