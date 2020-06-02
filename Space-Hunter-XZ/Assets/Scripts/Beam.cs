using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionSmall;
    public GameObject playerExplosion;
    public GameObject shieldExplosion;

    private GameController gameController;
    private PowerUpController powerUpController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        powerUpController = GameObject.FindWithTag("PowerUpController").GetComponent<PowerUpController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Hazard"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.CompareTag("Shield"))
        {
            other.GetComponent<Shield>().Explosion();
            powerUpController.shieldUpActive = false;
            Handheld.Vibrate();
            other.gameObject.SetActive(false);
            other.GetComponentInParent<CapsuleCollider>().enabled = true;
            return;
        }
        if (other.CompareTag("Player"))
        {
            if (gameController.GetLife() < 1)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                other.GetComponent<Player>().Explosion();
                other.GetComponent<Player>().TriggerDestruction(true);
            }
            else if (gameController.GetLife() >= 1)
            {
                gameController.TakeLife();
                Instantiate(explosion, transform.position, transform.rotation);
                other.GetComponent<Player>().Explosion();
                other.GetComponent<Player>().TriggerDestruction(false);
            }
        }
    }
}
