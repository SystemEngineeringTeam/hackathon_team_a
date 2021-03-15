using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeCounter : MonoBehaviour
{
    float countTime = 0;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("紙ヒコーキ");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y > -138.8f){
            countTime += Time.deltaTime;
            GetComponent<Text>().text = countTime.ToString("F2");
        }
    }
}
