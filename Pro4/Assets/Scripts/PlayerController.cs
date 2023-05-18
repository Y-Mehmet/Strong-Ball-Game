using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    public GameObject powerupIndicator;
    GameObject focalPoint;
    public static bool hasPowerup=false;
    public float speed=10;
    float forcepower=10;
    //public PowerUpType currentPowerUp=PowerUpType.None;
    // Start is called before the first frame update
    void Start()
    {
        playerRb=GetComponent<Rigidbody>();
        focalPoint=GameObject.Find("FocalPoint");
        powerupIndicator.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        FollowPlayer();
    }
    void Move(){
        float verInput=Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward*speed*verInput);
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Powerup"))
        {
            hasPowerup=true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine("PowerupCountDownRutine");
            
            
        }
    }
    void OnCollisionEnter(Collision collision){
        Rigidbody enemyRb=collision.gameObject.GetComponent<Rigidbody>();
        Vector3 awayFormPlayer=collision.gameObject.transform.position-transform.position;
        if(collision.gameObject.CompareTag("Enemy")&& hasPowerup)
        {
            enemyRb.AddForce(awayFormPlayer*forcepower,ForceMode.Impulse);
            Debug.Log("Collided whit "+collision.gameObject.name+" whit power up set "+hasPowerup);

        }
        else if( collision.gameObject.CompareTag("HarderEnemy")&& !hasPowerup)
        {
             enemyRb.AddForce(-awayFormPlayer*forcepower,ForceMode.Impulse);
        }
         else if( collision.gameObject.CompareTag("HarderEnemy")&& hasPowerup)
         {
            enemyRb.AddForce(awayFormPlayer*0.5f*forcepower,ForceMode.Impulse);
         }
    }
    IEnumerator PowerupCountDownRutine(){
        
        yield return new WaitForSeconds(7);
        hasPowerup=false;
        powerupIndicator.gameObject.SetActive(false);
    }
    void FollowPlayer(){
        Vector3 diference=new Vector3(0,-0.4f,0);
        powerupIndicator.gameObject.transform.position=transform.position+diference;
    }
    
    
    }
