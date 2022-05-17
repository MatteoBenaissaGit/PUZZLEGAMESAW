using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public GameObject BookUI;
    public GameObject BookUILaunchButton;

    private void Start()
    {
        BookUI.active = false;
        BookUILaunchButton.active = true;
    }

    public void QuitBookUI()
    {
        BookUI.active = false;
        BookUILaunchButton.active = true;
    }

    public void LaunchBookUI()
    {
        BookUI.active = true;
        BookUILaunchButton.active = false;
    }
}
