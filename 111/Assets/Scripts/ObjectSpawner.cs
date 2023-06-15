using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    Vector2 pos;
    public GameObject objectPrefab;
    Rigidbody2D rigid;

    public float upTime;
    public float downSpeed;
    void Start()
    {
        pos = transform.position;
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 pos = transform.position;

        //pos.y = pos.y - downSpeed*Time.deltaTime;

        //rigid.MovePosition(pos);
        transform.Translate(0, -downSpeed*Time.deltaTime, 0);  
        if(transform.childCount==0)
        {
            StartCoroutine(Spawn());
        }

        if(rigid.velocity.y>0)
        {
            StartCoroutine(CollisionCheck());
        }
    }

    IEnumerator Spawn()
    {
        int objectNum = Random.Range(3, 11);
     
        float waitTime = Random.Range(0, 2.5f);
        yield return new WaitForSeconds(waitTime);
        if (transform.childCount == 0)
        {
            rigid.velocity = Vector2.zero;
            transform.position = pos;
            for (int i = 0; i < objectNum; i++)
            {
                Instantiate(objectPrefab, transform.position + new Vector3(0, i * 3, 0), Quaternion.identity).transform.parent = transform;
                yield return null;
            }
        }
    }

    IEnumerator CollisionCheck()
    {
        yield return new WaitForSeconds(upTime);
        while(rigid.velocity.y>0)
        {
            rigid.velocity -= new Vector2(0,Time.deltaTime);
            yield return new WaitForSeconds(0.1f);
        }
        rigid.velocity = Vector2.zero;
    }
}
