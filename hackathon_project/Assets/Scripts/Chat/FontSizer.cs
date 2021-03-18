using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontSizer : MonoBehaviour
{
    private int height,width;
    private float area;
    public float fontSize;
    private float beforeFontScaler;
    public float fontScaler=1000;
    // Start is called before the first frame update
    void Start()
    {
        beforeFontScaler=-1;
    }

    // Update is called once per frame
    void Update()
    {
        if(width!=Screen.width||height!=Screen.height||beforeFontScaler!=fontScaler){
            height=Screen.height;
            width=Screen.width;
            area=width*height;
            fontSize=(Mathf.Sqrt(area)/100)*fontScaler;
            foreach(Text text in transform.GetComponentsInChildren<Text>()){
                text.fontSize=(int)fontSize;
            }
        }
        beforeFontScaler=fontScaler;
    }
    
}
