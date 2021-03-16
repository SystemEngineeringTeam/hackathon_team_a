using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryScript : MonoBehaviour
{
    GameObject player;
    PlayerController Script;
    // Start is called before the first frame update
    void Start()
    {
        Script = GameObject.Find("紙ヒコーキ").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(){
        player = GameObject.Find("紙ヒコーキ");
        Vector3 pos = player.transform.position;
        pos.x = 0;
        pos.y = 20;
        pos.z = 0;
        player.transform.position = pos;
        Script.flag = 0;
    }
}
