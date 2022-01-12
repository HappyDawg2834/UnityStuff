using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{

    Rigidbody rb;
    MeshRenderer mr;
    [SerializeField] float waitTime = 15f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        mr = GetComponent <MeshRenderer>();

        mr.enabled = false;
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > waitTime)
        {
           mr.enabled = true;
           rb.useGravity = true; 
        }
    }
}
