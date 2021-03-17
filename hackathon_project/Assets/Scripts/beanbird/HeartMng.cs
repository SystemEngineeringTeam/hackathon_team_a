using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMng : MonoBehaviour
{
    public GameObject heart;

    float _timer = 0;
    void Start()
    {
        
    }

    void Update()
    {
        _timer -= Time.deltaTime;// タイマーのカウントダウン
        if(_timer<0){ // _timerが０になったときheartを生成
            Vector3 position = transform.position;
            position.x = Random.Range(-7, 7); // heartがランダムに生成される幅

            GameObject obj = Instantiate(heart, position, Quaternion.identity);// heartの生成
            _timer += 1;
        }
    }
}
