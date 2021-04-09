using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingMark : MonoBehaviour
{
    const float BASE_SHOTTER = 1080;
    const float BASE_LONGER = 1920;

    [SerializeField]
    float rotationSpeed, scale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.width < Screen.height)
        {
            this.transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(Screen.width / BASE_SHOTTER, Screen.width / BASE_SHOTTER, 1) * scale;
        }
        else
        {
            this.transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(Screen.width / BASE_LONGER, Screen.width / BASE_LONGER, 1) * scale;
        }
    }

    private void FixedUpdate()
    {
        this.transform.GetChild(0).GetComponent<RectTransform>().Rotate(0,0,rotationSpeed);
    }

    public void RemoveLoadingUI()
    {
        this.gameObject.SetActive(false);
    }

    public void SetLoadingUI()
    {
        this.gameObject.SetActive(true);
    }
}
