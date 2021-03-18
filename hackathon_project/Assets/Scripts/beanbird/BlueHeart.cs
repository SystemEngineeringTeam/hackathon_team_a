using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueHeart : MonoBehaviour
{
    GameObject ScoreMng;
    ScoreMng script;
    RegeneMng rgnscript;
    public float hearttmp;
    int flag = 0;
    
    void Start()
    {
        ScoreMng = GameObject.Find("ScoreMng");
        script = ScoreMng.GetComponent<ScoreMng>();
        rgnscript = GameObject.Find("RegenerateMng").GetComponent<RegeneMng>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // ハートがブロックに当たると消滅
        if(collision.tag == "block"){
            Destroy(gameObject);
            flag++;
        }else if(collision.tag == "knife"){
            if(flag!=0)
            {
            rgnscript.Regene();
            flag--;
            }
            hearttmp = this.transform.position.y;
            script.GetScore(hearttmp);// 得点
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()// 画面外にいくと消滅
    {
        Destroy(gameObject);
    }

}
