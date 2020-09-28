using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance = null;
    public Text myText, finalText;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        finalText.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = "Coins " + LevelManager.instance.coinScore + "/" + LevelManager.instance.levelScore;
    }
    public void finalTextUpdate()
    {
        finalText.enabled = true;
    }
}

