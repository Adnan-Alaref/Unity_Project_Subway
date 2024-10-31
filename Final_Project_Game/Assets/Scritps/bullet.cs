using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject po;
    float nowFire=0;
    void Start()
    {     
        if(controller_.run)
        StartCoroutine("firee");
    }
    IEnumerator firee()
    {
            for(int i=0;i<5;i++){
            float x=(float)Random.Range(-9,9);
            transform.position = new Vector3(x/6f,12,20);
            GameObject pullet_made=Instantiate(po,transform.position,transform.rotation);
            Destroy(pullet_made,5);
            yield return new WaitForSeconds(4);
            
        }
    }
}
