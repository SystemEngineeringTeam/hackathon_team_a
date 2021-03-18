using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMng : MonoBehaviour
{
    public GameObject heart;
    public GameObject blue_heart;
    public GameObject yellow_heart;

    float _timer = 0.0f;
    float _btimer = 10.0f;
    float _ytimer = 40.0f;
    float _totalTime = 0.0f;
    int _cnt = 0;
    void Start()
    {
        
    }

    void Update()
    {
        _timer -= Time.deltaTime;// タイマーのカウントダウン
        _btimer -= Time.deltaTime;
        _ytimer -= Time.deltaTime;
        _totalTime += Time.deltaTime;
        if(_timer<0.0f){ // _timerが０になったときheartを生成
            Vector3 position = transform.position;
            position.x = Random.Range(-9, 9); // heartがランダムに生成される幅

            GameObject obj = Instantiate(heart, position, Quaternion.identity);// heartの生成
            _timer += 2.0f;
            if(_cnt%10 == 0){
                _timer -= 1.0f;
            }
            _timer -= _totalTime/70;
            _cnt++;
        }

        if(_btimer<0){
            Vector3 bposition = transform.position;
            bposition.x = Random.Range(-9, 9);
            GameObject bobj = Instantiate(blue_heart, bposition, Quaternion.identity);
            _btimer += 10.0f;
        }

        if(_ytimer<0){
            Vector3 yposition = transform.position;
            yposition.x = Random.Range(-9, 9);
            GameObject yobj = Instantiate(yellow_heart, yposition, Quaternion.identity);
            _ytimer += 40.0f;
        }
    }
}
