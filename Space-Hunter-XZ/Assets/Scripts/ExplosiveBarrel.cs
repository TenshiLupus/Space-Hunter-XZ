using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    CapsuleCollider colCapsule;
    public GameObject explosionObject;

     public float radius;

    private void Awake() {
        colCapsule = GetComponent<CapsuleCollider>();
        Debug.Log("Bomb Spawned");
    }

     void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("Wall"))
        {
            Debug.Log("Bomb Spawned");
        } 
        if (other.CompareTag("Bullet"))
        {
            Explode();
            Debug.Log("Bullet hit by bomb");
        }
        if (other.CompareTag("Hazard"))
        {
            Debug.Log("Hazard hit by bomb");
        }
        if (other.CompareTag("Player"))
        {
            Debug.Log("player hit by bomb");
        }
     }
    

    void Explode(){
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        Instantiate(explosionObject, transform.position, transform.rotation);
        foreach(Collider nearbyObject in colliders)
        {
            
            Destroy(nearbyObject.transform.gameObject);
            
        }
        Destroy(this);
    }

}
