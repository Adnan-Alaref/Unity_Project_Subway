using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conan_bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(-200,0,Random.Range(-80,-130)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
