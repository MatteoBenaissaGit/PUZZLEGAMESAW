using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]


public class CreditsBlinking : MonoBehaviour
{
    bool _fade;
    public GameObject fader;
    public GameObject panel;

    public bool canSwitch;
    public GameObject buttonBack;

    AudioSource audioData;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
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
            Cursor.visible = true;
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