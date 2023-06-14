using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Animator anim;
    public GameObject particle;
    public Player player;
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
            if(player.attackCount < player.maxAttackCount)
                player.attackCount++;
            GameObject part = Instantiate(particle, collision.transform.position, Quaternion.identity);
            Destroy(part, 2f);
            Destroy(collision.gameObject);      
        }
    }
}
