using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsBlinking : MonoBehaviour
{
    bool fade;
    public GameObject fader;

    private void Start()
    {
        StartCoroutine(Blink());
        StartCoroutine(Waiting());
    }

    private void Update()
    {
        if (fade)
            fader.SetActive(true);
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(30);
        fade = true;
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