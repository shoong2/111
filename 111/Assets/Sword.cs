using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    
    public GameObject parent;
    //GameObject[] seperate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Object")
        {
         
            Destroy(collision.gameObject);
            Debug.Log(parent.transform.childCount);
            GameObject[] seperate = new GameObject[parent.transform.childCount];


            for (int i=0; i<parent.transform.childCount; i++)
            {
                seperate[i] = parent.transform.GetChild(i).gameObject;
            }


            parent.transform.DetachChildren();
            Debug.Log(seperate[0]);
            parent.transform.position = seperate[0].transform.position;
            for (int i = 0; i < seperate.Length; i++)
            {
                seperate[i].transform.SetParent(parent.transform);
            }
            Debug.Log(seperate[0]);
        }
    }
}
