using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        Rigidbody rb=GetComponent<Rigidbody>();
        anim=GetComponent<Animator>();
        rb.velocity = new Vector3(0, 0, -.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (transform.position.x < 4f)
                transform.Translate(new Vector3(10f, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (transform.position.x < 4)
                transform.Translate(new Vector3(-10f, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

        }
    }
}
