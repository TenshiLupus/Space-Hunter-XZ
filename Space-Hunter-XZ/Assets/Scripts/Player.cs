using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameController gameController;
    public GameObject shot;
    public GameObject shotAdv;
    public GameObject engine;
    public Transform shotSpawn;
    public float fireRate;

    private Coroutine shootCoroutine;
    private AudioSource audioSource;
    private Renderer renderer;
    private bool isReady;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
        Invoke("SetReady", 2f);
    }

    IEnumerator Shoot ()
    {
        while (true)
        {
            if (isReady && gameController.canShoot && !gameController.advancedWeapon)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                audioSource.Play();
                yield return new WaitForSeconds(0.1f);
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                audioSource.Play();
                yield return new WaitForSeconds(0.1f);
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                audioSource.Play();
            }
            if (isReady && gameController.canShoot && gameController.advancedWeapon)
            {
                Instantiate(shotAdv, shotSpawn.position, shotSpawn.rotation);
                audioSource.Play();
                yield return new WaitForSeconds(0.1f);
                Instantiate(shotAdv, shotSpawn.position, shotSpawn.rotation);
                audioSource.Play();
                yield return new WaitForSeconds(0.1f);
                Instantiate(shotAdv, shotSpawn.position, shotSpawn.rotation);
                audioSource.Play();
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

    public void Respawn()
    {
        gameController.canShoot = false;
        gameController.advancedWeapon = false;
        transform.position = new Vector3(0, 0, 0);
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
