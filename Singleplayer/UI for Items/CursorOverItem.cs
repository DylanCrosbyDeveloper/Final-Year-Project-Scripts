using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CursorOverItem : MonoBehaviour
{
    public GameObject PopupImage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        PopupImage.SetActive(true);
    }

    private void OnMouseExit()
    {
        PopupImage.SetActive(false);
    }
}
