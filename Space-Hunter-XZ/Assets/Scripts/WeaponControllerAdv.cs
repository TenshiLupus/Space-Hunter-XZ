using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControllerAdv : MonoBehaviour
{

    public float distance;
    public float fireRate;
    public float bulletSpeed = 100;
    public float bulletTimer;

    public GameObject bolt;
    public Transform target;
    public Transform shootPoint;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        Invoke("StartAttack",0.3f);
    }

    void Update()
    {

    }

    void StartAttack ()
    {
        StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(fireRate);

        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();

        GameObject bulletClone;
        bulletClone = Instantiate(bolt, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
        bulletClone.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
        bulletTimer = 0;

    }
}
