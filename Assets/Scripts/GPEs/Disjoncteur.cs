using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Disjoncteur : ClassActivator
{
    bool _isTrigger;
    Animator _anim;
    Animator _characterAnim;
    Collider _characterCollider;

    [Header("Button&Cam Reference")][Space(10)]
    public GameObject ButtonImage;
    public Transform Camera;

    AudioSource audioData;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
        _characterAnim = Character.GetComponent<Animator>();
        _characterCollider = Character.GetComponent<Collider>();
        ButtonImage.SetActive(false);
    }

    private void Update()
    {
        PushCheck();
        ButtonImage.transform.LookAt(Camera);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == _characterCollider)
        {
            _isTrigger = true;
            ButtonImage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == _characterCollider)
        {
            _isTrigger = false;
            ButtonImage.SetActive(false);
        }
    }

    void PushCheck()
    {
        if (_isTrigger && (Input.GetButtonDown("ButtonActivation")||Input.GetKeyDown(KeyCode.E)))
        {
            audioData.Play(0);
            Pushed();
        }
    }

    void Pushed()
    {
        _anim.SetTrigger("Push");
        _characterAnim.SetTrigger("PushButton");
        Activate();
    }
}
