using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public GameObject Player;
    Vector3 targetPos;


    private void Start()
    {
        Player = GameObject.Find("Player");
        targetPos = Player.transform.position;
        Invoke("DestroyBullet", .5f);
    }

    void Update()
    {

        //transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, bulletSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player = other.gameObject;
            Player.GetComponent<HealthBarScript>().currentHealth -= 5;
            Destroy(this.gameObject);
            
        }
        
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
    

}
