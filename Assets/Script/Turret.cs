using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject player;
    private bool playerLocked;
    public GameObject bulletSpawn;
    public GameObject bullet;
    public float fireTimer;
    private bool shotReady;
    public GameObject turretTop;

    void Start()
    {
        shotReady = true;
    }
    void Update()
    {
        if(playerLocked)
        {
            turretTop.transform.LookAt(player.transform);
            turretTop.transform.Rotate(0, -90, 0);

            if(shotReady)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Transform _bullet = Instantiate(bullet.transform, bulletSpawn.transform.position, Quaternion.identity);
        _bullet.transform.rotation = bulletSpawn.transform.rotation;
        shotReady = false;
        StartCoroutine(FireRate());
    }
    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(fireTimer);
        shotReady = true;
        StartCoroutine(FireRate());

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player = other.gameObject;
            playerLocked = true;
        }
    }
}
