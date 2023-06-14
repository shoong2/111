using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    
    int test = 0;
    public Animator anim;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Object" && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {        
            Destroy(collision.gameObject);      
        }
    }
}
