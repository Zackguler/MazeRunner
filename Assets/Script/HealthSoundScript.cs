using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HealthSoundScript : MonoBehaviour
{
    
    public AudioClip HealthSound;
    public AudioSource Music;


    void Start()
    {
        Music.clip = HealthSound;
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("HealthItem"))
        {
            Music.Play();
            
        }

    }
}
 