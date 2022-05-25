using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PiquesScripts : MonoBehaviour
{
    public GameObject Character;

    AudioSource audioData;
    bool play;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!play)
        {
            play = true;
            audioData.Play(0);
        }
        //player kill
        if (collision.collider == Character.GetComponent<Collider>())
            Character.GetComponent<PlayerLife>().IsAlive = false;
    }
}
