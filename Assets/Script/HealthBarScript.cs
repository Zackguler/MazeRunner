using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthBarScript : MonoBehaviour
{
	public float maxHealth = 100;
	public float currentHealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth > 0) 
	{
		TakeDamage(10);
	}
        
	void TakeDamage(float damage) 
	{
		currentHealth -= damage * Time.deltaTime;
		healthBar.SetHealth(currentHealth);
           
        }
    }
}

