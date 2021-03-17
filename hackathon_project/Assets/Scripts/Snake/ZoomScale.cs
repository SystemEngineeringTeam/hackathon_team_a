using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomScale : MonoBehaviour
{
    static int count = 0;
    float Base = 0.0008f;
    int flag = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.transform.localScale.x < 0.15){
            this.transform.localScale += new Vector3(Base,Base,0);
        }else if(this.transform.localScale.x >= 0.15 && this.transform.localScale.x < 0.35){
            this.transform.localScale += new Vector3(Base + 0.0008f,Base + 0.0008f,0);
        }else if(this.transform.localScale.x >= 0.35 && this.transform.localScale.x < 0.5){
            this.transform.localScale += new Vector3(Base + 0.0018f,Base + 0.0018f,0);
        }else if(this.transform.localScale.x >= 0.5){
            count++;
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0,359));
            this.transform.localScale = new Vector3(0.1f,0.1f,1);
            flag = 0;
            //効果音を入れたい
        }
        if(count % 5 == 0 && count != 0 && flag == 0){
            Base += 0.0003f;
            flag = 1;
        }
    }
    public static int GetScore(){
        return count;
    }
}
