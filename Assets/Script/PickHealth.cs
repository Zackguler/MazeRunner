using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickHealth : MonoBehaviour
{
    // Start is called before the first frame update
    
	private void OnTriggerEnter(Collider other)

{
	if(other.name == "Player") 
{
	other.GetComponent<HealthBarScript>().currentHealth += 20.0f;
	Destroy(gameObject);
}
}
}
