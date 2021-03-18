using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundMng : MonoBehaviour
{
    public AudioClip pityu;
    AudioSource audiosource;

    private void Start() {
        audiosource = GetComponent<AudioSource>();
    }

    public void pityun(){
        audiosource.PlayOneShot(pityu);
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("BirdBeanEnd");
    }
}
