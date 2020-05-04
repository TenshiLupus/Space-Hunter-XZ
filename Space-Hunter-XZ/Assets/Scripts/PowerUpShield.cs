using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShield : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.GetChild(2).gameObject.SetActive(true);
            other.GetComponent<CapsuleCollider>().enabled =false;
            Destroy(gameObject);

        }
        if (other.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }

    }
}
