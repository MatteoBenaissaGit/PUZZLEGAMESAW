using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]

public class ButtonCredits : MonoBehaviour
{
    AudioSource audioData;
    public GameObject slider;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }
    public void OnMouseDown()
    {
        audioData.Play(0);
        slider.transform.DOMove(new Vector3(25, 1, 0), 1.5f);
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(8);
    }
}
