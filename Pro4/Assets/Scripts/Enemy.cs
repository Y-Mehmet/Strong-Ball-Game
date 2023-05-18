using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    Rigidbody enemyRb;
    public float speed=9;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb=GetComponent<Rigidbody>();
        player=GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        DestroyEnemy();
    }
    void FollowPlayer() {
        Vector3 diference=player.transform.position-transform.position;
       enemyRb.AddForce(diference.normalized*speed);
    }
    void DestroyEnemy(){
        if(transform.position.y<-10)
        {
            Destroy(gameObject);
        }
    }
}
