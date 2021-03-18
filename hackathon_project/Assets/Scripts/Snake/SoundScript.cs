using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{

    public bool DontDestroyEnabled = true;
    private AudioSource audioSource;
    public static int flag;
    // Start is called before the first frame update
    void Start()
    {
        // if(DontDestroyEnabled){
        //     DontDestroyOnLoad(this);
        // }
        // if(gameObject == false || flag == 0){
        //     audioSource = gameObject.GetComponent<AudioSource>();
        //     audioSource.Play ();
        //     flag = 1;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
