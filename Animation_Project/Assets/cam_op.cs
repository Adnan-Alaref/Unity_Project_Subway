using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_op : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    Vector3 offset;
    void Start()
    {
        offset=transform.position-player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(transform.position.x,transform.position.y,player.position.z+offset.z);
    }
}
