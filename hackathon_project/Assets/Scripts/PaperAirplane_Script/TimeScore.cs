using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeScore : MonoBehaviour
{
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        time = TimeCounter.Count();
        GetComponent<Text>().text = "Time　" + time.ToString("F2") + "s";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // public void OnText(){
        
    // }
}
