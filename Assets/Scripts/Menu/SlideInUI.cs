using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]

public class SlideInUI : MonoBehaviour
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

        transform.DOLocalMove(new Vector3(4500, 1, 0), 1.5f);
    }
}
