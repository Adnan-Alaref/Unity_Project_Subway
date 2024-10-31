using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_boom : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject po;
    void Start()
    {
        StartCoroutine("firee");
    }
    IEnumerator firee()
    {
            for(int i=0;i<10;i++){
           // transform.position = new Vector3(x/6f,12,20);
           GameObject pullet_made=Instantiate(po,transform.position+Vector3.up*1,transform.rotation);
           Destroy(pullet_made,5);
            yield return new WaitForSeconds(4);
        }
    }
}
