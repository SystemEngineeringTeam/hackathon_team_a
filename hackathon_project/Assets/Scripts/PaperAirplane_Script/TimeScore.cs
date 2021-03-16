using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeScore : MonoBehaviour
{
    float time = 0;
    float highScore = 10000f; //スコア用
    private string key = "HIGHSCORE"; //ハイスコア保存先キー
    // Start is called before the first frame update
    void Start()
    {
        time = TimeCounter.Count();
        highScore = PlayerPrefs.GetFloat(key,10000f);
        if(time < highScore){
            highScore = time; //ハイスコア更新
            PlayerPrefs.SetFloat(key,highScore);
        }
        //保存しておいたハイスコアをキーで呼び出し取得し、保存されていなければ0になる
        GetComponent<Text>().text ="Best " + highScore.ToString("F2") + "s\n" + "Time　" + time.ToString("F2") + "s";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // public void OnText(){
        
    // }
}
