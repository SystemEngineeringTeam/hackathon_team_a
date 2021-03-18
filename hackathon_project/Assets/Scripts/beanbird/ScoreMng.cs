using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMng : MonoBehaviour
{
    public GameObject score_object = null;
    public int score = 0;
    public GameObject Heart;
    public GameObject BlueHeart;
    public GameObject YellowHeart;
    BlueHeart bscript;
    Heart script;
    YellowHeart yscript;


    void Start()
    {
        script = Heart.GetComponent<Heart>();
    }

    void Update()
    {
        Text score_text = score_object.GetComponent<Text> ();
        score_text.text = "Score："+ score;
    }

    public void GetScore(float height){
        
        if(height < 0.0f){
            score += 50;
        }else
        {
            score += 150;
        }
        
    }
}


//　高さからスコアを判定