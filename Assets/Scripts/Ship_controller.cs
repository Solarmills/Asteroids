using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(0, 0, Input.GetAxis("Horizontal")*3f);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(0, Input.GetAxis("Vertical") * .1f, 0);
        }
    }
}
