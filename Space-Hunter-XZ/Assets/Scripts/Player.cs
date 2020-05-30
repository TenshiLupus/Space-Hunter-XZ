using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameController gameController;
    public GameObject shot;
    public GameObject shotAdv;
    public Transform shotSpawn;
    public float fireRate;

    private Coroutine shootCoroutine;
    private AudioSource audioSource;
    private bool isReady;

    void Start()
    {
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
}
