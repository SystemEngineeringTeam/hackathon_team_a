﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void buttonactiv(){
        text.SetActive(true);
    }
    public void buttonfalse(){
        text.SetActive(false);
    }
    public void goHome(){
        SceneManager.LoadScene("Menu");
    }
}
