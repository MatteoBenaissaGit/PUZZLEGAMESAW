using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlay : MonoBehaviour
{
    public GameObject slider;
    public void OnMouseDown()
    {
        slider.SetActive(true);
    }
}
