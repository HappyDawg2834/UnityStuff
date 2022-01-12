using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] float thrustPower = 1000f;
    [SerializeField] float rotateSpeed = 100f;
    [SerializeField] AudioClip mainEngine;

    Rigidbody rb;
    AudioSource audioSource;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
            
            //might want to work on volume and sounds
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
        }
        else
        {
            audioSource.Stop();
        }

        //how to stop rocket sound from playing after getting hit

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(-rotateSpeed);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so that we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame *  Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation so that the physics system can take over
    }

}