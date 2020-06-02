using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameController gameController;
    public Material materialNormal;
    public Material materialHighlight;
    public GameObject playerExplosion;
    public GameObject shot;
    public GameObject shotAdv;
    public GameObject engine;
    public Transform shotSpawn;
    public float fireRate;

    public float respawnTimer;

    private Coroutine shootCoroutine;
    private AudioSource audioSource;
    private Renderer renderer;
    private Quaternion quaternion;
    private bool isReady;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
        Invoke("SetReady", 2f);
        quaternion = new Quaternion(0, 0, 0, 0);
    }

    IEnumerator Shoot ()
    {
        while (true)
        {
            if (isReady && gameController.canShoot && !gameController.advancedWeapon)
            {
                Instantiate(shot, shotSpawn.position, quaternion);
                audioSource.Play();
                yield return new WaitForSeconds(0.1f);
                if (gameController.canShoot) 
                {
                    Instantiate(shot, shotSpawn.position, quaternion);
                    audioSource.Play();
                    yield return new WaitForSeconds(0.1f);
                }
                if (gameController.canShoot)
                {
                    Instantiate(shot, shotSpawn.position, quaternion);
                    audioSource.Play();
                }
            }
            if (isReady && gameController.canShoot && gameController.advancedWeapon)
            {
                Instantiate(shotAdv, shotSpawn.position, quaternion);
                audioSource.Play();
                yield return new WaitForSeconds(0.1f);
                if (gameController.canShoot)
                {
                    Instantiate(shotAdv, shotSpawn.position, quaternion);
                    audioSource.Play();
                    yield return new WaitForSeconds(0.1f);
                }
                if (gameController.canShoot)
                {
                    Instantiate(shotAdv, shotSpawn.position, quaternion);
                    audioSource.Play();
                }
            }
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void SetReady()
    {
        audioSource.volume = 0.2f;
        isReady = true;
        shootCoroutine = StartCoroutine(Shoot());
    }
    public void ChangeMaterial()
    {
        renderer.material = materialHighlight;
    }
    public void ResetMaterial()
    {
        renderer.material = materialNormal;
    }
    public void TriggerDestruction(bool dead)
    {
        ChangeMaterial();
        Handheld.Vibrate();
        Invoke("Explosion", 0.1f);
        if (dead)
        {
            gameController.GameOver();
            Invoke("Destroy", 0.1f);
        } else
        {
            gameController.canShoot = false;
            ResetMaterial();
            Invoke("Respawn", 0.1f);
        }
    }
    public void Explosion()
    {
        Instantiate(playerExplosion, transform.position, transform.rotation);
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

        public void Respawn()
    {
        gameController.canShoot = false;
        gameController.advancedWeapon = false;
        transform.position = new Vector3(0, -4, 0);
        transform.rotation = new Quaternion(0, 0, 0, 0);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        renderer.enabled = false;
        engine.SetActive(false);
        GetComponent<ShipMove>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        Invoke("Reactivate", 1f);
    }
    public void Reactivate()
    {
        gameController.canShoot = true;
        renderer.enabled = true;
        engine.SetActive(true);
        GetComponent<ShipMove>().enabled = true;
        GetComponent<CapsuleCollider>().enabled = true;
    }
}
