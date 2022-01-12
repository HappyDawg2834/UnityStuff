using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    [SerializeField] float xValue = 0f;
    [SerializeField] float yValue = 0f;
    [SerializeField] float zValue = 1f;
    [SerializeField] float waitTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (time.Time)

        if (time.Time - (waitTime * Time.time = 0)
        {
        transform.Translate(xValue,yValue,zValue);
        }
    }
}
