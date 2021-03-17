using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomScale : MonoBehaviour
{
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        //ランダムに角度を決定

    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.localScale.x < 0.15){
            this.transform.localScale += new Vector3(0.001f,0.001f,0);
        }else if(this.transform.localScale.x >= 0.15 && this.transform.localScale.x < 0.35){
            this.transform.localScale += new Vector3(0.002f,0.002f,0);
        }else if(this.transform.localScale.x >= 0.35 && this.transform.localScale.x < 0.55){
            this.transform.localScale += new Vector3(0.003f,0.003f,0);
        }else{
            count++;
        }
    }
}
