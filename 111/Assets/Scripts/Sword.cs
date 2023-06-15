using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Animator anim;
    public GameObject particle;
    public SkillController player;
    public GameObject Rplayer;
    Player playerS;

    bool test;
    void Start()
    {
        playerS = Rplayer.GetComponent<Player>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        test = playerS.isGround;
        if (playerS.jumpSkill.isSkill == true)
        {
            Debug.Log("in");

            StartCoroutine(Skill());
            playerS.jumpSkill.isSkill = false;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Object" && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            //if(player.attackCount < player.maxAttackCount)
            //    player.attackCount++;
            if (player.skillCount < player.maxSkillCount)
                player.SetSkillCount();
            GameObject part = Instantiate(particle, collision.transform.position, Quaternion.identity);
            Destroy(part, 2f);
            Destroy(collision.gameObject);
            GameManager.instance.combo++;
            GameManager.instance.ShowCombo();
           
        }
    }

    IEnumerator Skill()
    {
        Debug.Log("h");
        Rplayer.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 15f, ForceMode2D.Impulse);
        while (Rplayer.transform.position.y>-3.2f)
        {
            Debug.Log("Check");
            anim.SetTrigger("Attack");
            yield return null;
        }

    }
}
