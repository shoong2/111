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
}
