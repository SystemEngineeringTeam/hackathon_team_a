using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupMng : MonoBehaviour
{

    public GameObject popup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClickPopupButtom()//ポップアップを出現させる
    {
        popup.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
