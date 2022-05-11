using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCam : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;
    public GameObject Cam4;

    private void Start()
    {
        Cam1.SetActive(true);
        Cam2.SetActive(false);
        Cam3.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            Cam1.SetActive(true);
            Cam2.SetActive(false);
            Cam3.SetActive(false);
            Cam4.SetActive(false);
        }
        if (Input.GetKeyDown("y"))
        {
            Cam1.SetActive(false);
            Cam2.SetActive(true);
            Cam3.SetActive(false);
            Cam4.SetActive(false);
        }
        if (Input.GetKeyDown("u"))
        {
            Cam1.SetActive(false);
            Cam2.SetActive(false);
            Cam3.SetActive(true);
            Cam4.SetActive(false);
        }
        if (Input.GetKeyDown("i"))
        {
            Cam1.SetActive(false);
            Cam2.SetActive(false);
            Cam3.SetActive(false);
            Cam4.SetActive(true);
        }
    }
}