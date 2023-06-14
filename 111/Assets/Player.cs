using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    public float jump;

    public GameObject obj;
    public GameObject sword;
    GameObject bottom;

    public GameObject particle;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = sword.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(obj.transform.GetChild(0).name);
    }

    public void Jump()
    {
        rigid.AddForce(Vector3.up * jump, ForceMode2D.Impulse);
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
  
    }

    public void Shield()
    {
        rigid.AddForce(Vector3.up * jump, ForceMode2D.Impulse);
    }

 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Object")
        {
            Debug.Log("Ãæµ¹");
            GameObject part = Instantiate(particle, collision.transform.position, Quaternion.identity);
            Destroy(part, 2f);
            Destroy(collision.gameObject);
        }
    }

}
