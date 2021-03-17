using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMng : MonoBehaviour
{
    public GameObject heart;
    public GameObject blue_heart;

    float _timer = 0.0f;
    float _btimer = 10.0f;
    void Start()
    {
        
    }

    void Update()
    {
        _timer -= Time.deltaTime;// タイマーのカウントダウン
        _btimer -= Time.deltaTime;
        if(_timer<0){ // _timerが０になったときheartを生成
            Vector3 position = transform.position;
            position.x = Random.Range(-7, 7); // heartがランダムに生成される幅

            GameObject obj = Instantiate(heart, position, Quaternion.identity);// heartの生成
            _timer += 1.0f;
        }

        if(_btimer<0){
            Vector3 bposition = transform.position;
            bposition.x = Random.Range(-7, 7);
            GameObject bobj = Instantiate(blue_heart, bposition, Quaternion.identity);
            _btimer += 10.0f;
        }
    }
}
