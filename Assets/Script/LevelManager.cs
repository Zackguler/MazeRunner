using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private string loadLevel;
    public static LevelManager instance = null;
    public HealthBarScript HealthBarScript_;
    
    public int levelScore;
    public int coinScore;
    public bool levelComplete = false;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    private void Update()
    {
        OnFail();

    }

    private void OnFail()
    {
        if (HealthBarScript_.currentHealth <= 0)
        {
            SceneManager.LoadScene("FirstScene");
        }
    }

    public void onComplete()
    {
        if (levelComplete && coinScore == levelScore)
        {
            Debug.Log("bölüm geçildi");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //SceneManager.LoadScene(loadLevel);
        }
    }

    
}
