using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star_audio : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource Audio;
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag=="Player")
        {
            Audio.Play();
            //Debug.Log("1111111111113222222222222222222222222222222222222233333");
        }
        
    }
}
