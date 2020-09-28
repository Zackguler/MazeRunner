using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<HealthBarScript>().currentHealth -= 25.0f;
        Destroy(gameObject);
    }
}
