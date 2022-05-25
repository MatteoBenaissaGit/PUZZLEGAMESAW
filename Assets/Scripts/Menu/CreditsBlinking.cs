using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsBlinking : MonoBehaviour
{
    bool _fade;
    public GameObject fader;
    public GameObject panel;

    public bool canSwitch;
    public GameObject buttonBack;

    private void Start()
    {
        StartCoroutine(Blink());
        StartCoroutine(Waiting());
    }

    private void Update()
    {
        if (_fade)
        {
            _fade = false;
            fader.SetActive(true);
            panel.SetActive(true);
            StartCoroutine(Waiting2());
        }

        if (canSwitch)
        {
            buttonBack.SetActive(true);
        }
    }

    IEnumerator Waiting2()
    {
        yield return new WaitForSeconds(4);
        canSwitch = true;
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(30);
        _fade = true;
    }
    IEnumerator Blink()
    {
         yield return new WaitForSeconds(0.5f);
         GetComponent<Light>().intensity = 0;
         yield return new WaitForSeconds(0.2f);
         GetComponent<Light>().intensity = 1;
         yield return new WaitForSeconds(0.1f);
         GetComponent<Light>().intensity = 0;
         yield return new WaitForSeconds(0.05f);
         GetComponent<Light>().intensity = 1;
         yield return new WaitForSeconds(0.2f);
         GetComponent<Light>().intensity = 0;
         yield return new WaitForSeconds(0.7f);
         GetComponent<Light>().intensity = 1;
         yield return new WaitForSeconds(5);
         StartCoroutine(Blink());
    }
}