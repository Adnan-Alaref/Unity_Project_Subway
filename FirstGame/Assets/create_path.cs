using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_path : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] prefabs;
    private float len,tileLen=22.8f,numTilesMade=22.5f;
    public Transform player;
    private int n=1,preveois_road=0;
    bool p=true;
    void Start()
    {
        make_tile(0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(player.transform.position.z>numTilesMade-3*tileLen)
        {
            if(preveois_road==3||preveois_road==4)
            {
                preveois_road=Random.Range(0,prefabs.Length-2);
                make_tile(preveois_road);
            }
            else
            {
                preveois_road=Random.Range(0,prefabs.Length);
                make_tile(preveois_road);
            }
            n++;
        }
    }
    
    public void make_tile(int tileIndex)
    {
        //if(p==true)
            GameObject plane=Instantiate(prefabs[tileIndex],transform.forward*numTilesMade,transform.rotation);
            Destroy(plane,15);
        // else
        //     Instantiate(prefabs[tileIndex],transform.left*numTilesMade,transform.rotation);
        // if(p==true)
            numTilesMade+=tileLen;
        // else
        
    }
}
