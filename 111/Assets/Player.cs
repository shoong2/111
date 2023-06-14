using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    public float jump;

    public GameObject obj;
    public GameObject sword;
    public GameObject particle;
    public GameObject health;

    bool isGround = true;
    int healthCount;

    //게이지 관리
    [Header("UI")]
    public Image attackBar;
    public float maxAttackCount = 10;
    public float attackCount = 0;

    public Image jumpBar;
    public float maxJumpCount = 5;
    float JumpCount = 0;

    public Image shieldBar;
    public GameObject head;
    public float shieldCoolTime = 3;
    bool isShield = true;
    bool clickShield = false;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = sword.GetComponent<Animator>();
        healthCount = health.transform.childCount-1;
    }


    void Update()
    {
       
    }

    public void Jump()
    {
        if (isGround)
        {
            rigid.AddForce(Vector3.up * jump, ForceMode2D.Impulse);
            JumpCount++;
            jumpBar.fillAmount = JumpCount / maxJumpCount;
        }
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
        //attackCount++;
        attackBar.fillAmount = attackCount / maxAttackCount;
    }

    public void Shield()
    {
        if (isGround && isShield)
        {
            clickShield = true;
            isShield = false;
            head.SetActive(false);
            rigid.AddForce(Vector3.up * jump, ForceMode2D.Impulse);
            StartCoroutine(CoolTime(shieldCoolTime));
        }
    }

    IEnumerator CoolTime(float time)
    {
        shieldBar.fillAmount = 1f;
        while (shieldBar.fillAmount>0)
        {
            shieldBar.fillAmount -= Time.smoothDeltaTime / shieldCoolTime;
            yield return null;
        }
        isShield = true;
    }

 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Object")
        //{
        //    Debug.Log("ggfdg");
        //    if (healthCount >= 0 && !clickShield)
        //    {
        //        GameObject part = Instantiate(particle, collision.transform.position, Quaternion.identity);
        //        Destroy(part, 2f);
        //        Destroy(collision.transform.GetChild(0).gameObject);
        //        health.transform.GetChild(healthCount).gameObject.SetActive(false);
        //        healthCount--;
        //        if (healthCount < 0)
        //        {
        //            Debug.Log("End");
        //        }
        //    }

        //    clickShield = false;
        //}

        if (collision.gameObject.tag =="Ground")
        {
            isGround = true;
            head.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Ground")
        {
            isGround = false;
            clickShield = false;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Object")
        {
            Debug.Log("ggfdg");
            if (healthCount >= 0 && !clickShield)
            {
                GameObject part = Instantiate(particle, collision.transform.position, Quaternion.identity);
                Destroy(part, 2f);
                Destroy(collision.gameObject);//.transform.GetChild(0).gameObject);
                health.transform.GetChild(healthCount).gameObject.SetActive(false);
                healthCount--;
                if (healthCount < 0)
                {
                    Debug.Log("End");
                }
            }

            //clickShield = false;
        }
    }

}
