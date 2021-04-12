﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    Punicon puniconSys;
    float sensitivity = 0.05f;
    float maxSpeed = 10;

    public AudioClip sound1;
    AudioSource audioSource;

    public bool isMine=false;
    public bool activeMoving = true;
    void Start()
    {
        puniconSys = GameObject.Find("Punicon").GetComponent<Punicon>();
    }
    void Awake(){
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //キーボード優先
        if (activeMoving) { 
        MoveWithPunicon();
        MoveWithKey();
        }
    }

    void MoveWithPunicon() 
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 moveVec = puniconSys.GetMoveVector() * sensitivity;
            if (moveVec.magnitude < maxSpeed)
            {
                this.GetComponent<Rigidbody2D>().velocity = moveVec;
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = moveVec.normalized * maxSpeed;
            }
        }
    }

    void MoveWithKey()
    {
        Vector2 moveVec = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            moveVec += new Vector2(-1, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVec += new Vector2(0, -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveVec += new Vector2(1, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveVec += new Vector2(0, 1);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            this.GetComponent<Rigidbody2D>().velocity = moveVec.normalized * maxSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(isMine){
            if(collision.tag == "tea"){
                audioSource.PlayOneShot(sound1);
            }

            if(collision.tag == "cng"){
                popUpMenu("popUpInWPlace",gameObject);
                gameObject.GetComponent<Player>().enabled=false;
                // SceneManager.LoadSceneAsync("popUpInWPlace", LoadSceneMode.Additive);
            }
        }
    }

    private void popUpMenu(string sceneName,GameObject obj){
        StartCoroutine(_popUpMenu(sceneName,()=>{
            var menu = FindObjectOfType<PopupToMenu>() as PopupToMenu;
            menu.player= obj;
        }));
    }

    private IEnumerator _popUpMenu(string sceneName,System.Action onLoad) {
        var asyncOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        yield return asyncOp;
        onLoad.Invoke();
    }
}
