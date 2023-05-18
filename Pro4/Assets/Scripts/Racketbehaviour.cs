using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racketbehaviour : MonoBehaviour
{
    Transform target;
    float speed=15 , racketStrength=15 , aliveTimer=5 ;
    bool homing;

    // Start is called before the first frame update
   public void Fire(Transform newTarget){
    target=newTarget;
    homing=true;
    Destroy(gameObject,aliveTimer);

   }
   void Update(){
    if(homing && target!=null)
    {
        Vector3 moveDirection= (target.transform.position-transform.position).normalized;
        transform.position+=moveDirection*speed*Time.deltaTime;
        transform.LookAt(target);
    }
   }
   void OnCollisionEnter(Collision collision)
   {
    if(target!=null)
    {
        Rigidbody targetRb= collision.gameObject.GetComponent<Rigidbody>();
        Vector3 away=-collision.contacts[0].normal;
        targetRb.AddForce(away*racketStrength,ForceMode.Impulse);
        Destroy(gameObject);
    }
   }
}
