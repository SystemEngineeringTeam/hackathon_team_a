using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighOnly : MonoBehaviour
{
    int score = 0;
    int highScore = 0; //スコア用
    private string key = "HIGHSCORE"; //ハイスコア保存先キー
    // Start is called before the first frame update
    void Start()
    {
        score = ZoomScale.GetScore();
        highScore = PlayerPrefs.GetInt(key,0);
        if(score > highScore){
            highScore = score; //ハイスコア更新
            PlayerPrefs.SetInt(key,highScore);
        }
        //保存しておいたハイスコアをキーで呼び出し取得し、保存されていなければ0になる
        GetComponent<Text>().text ="ハイスコア\n" + highScore;
    }

}
