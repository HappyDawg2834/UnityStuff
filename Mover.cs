using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        PrintInstructions();
        rb = GetComponent <Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.Space))
        {
            FreezePosition();
        }
        else if (Input.anyKey)
        {
        MovePlayer();
        }
    }

    void PrintInstructions()
    {
        Debug.Log("Welcome to the game");
        Debug.Log("You are now known as the speedy and daring Zippy");
        Debug.Log("Using WASD or the arrow keys, navigate the obstacle course while bumping into as few obstacles and walls as you possibly can");
        Debug.Log("Good Luck :)");
    }

    void MovePlayer()
    {
        float xValue = Input.GetAxis ("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis  ("Vertical")  * Time.deltaTime * moveSpeed;

        transform.Translate(xValue,0,zValue);
    }

    void FreezePosition()
    {
        rb.constraints =  RigidbodyConstraints.FreezePositionX;
        rb.constraints =  RigidbodyConstraints.FreezePositionZ;
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints =  RigidbodyConstraints.FreezePositionY;
        rb.freezeRotation = true;       
    }

}