using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]

public class SlideOut : MonoBehaviour
{
    AudioSource audioData;
    bool play;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!play)
        {
            play = true;
            audioData.Play(0);
        }
        transform.DOMove(new Vector3(25, 1, 0), 1.5f);
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}
