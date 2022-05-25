using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]

public class PressurePlate : ClassActivator
{
    [Header("Pressure Plate Parameters")]
    [Space(10)]
    public float MovementHeight, MovementDuration;
    float BaseY;
    bool _isTrigger;
    bool _topContact;

    AudioSource audioData;

    private void Start()
    {
        BaseY = transform.position.y;
        IsActive = false;

        audioData = GetComponent<AudioSource>();
    }

    private void Update()
    {
        PressureCheck();
    }

    private void OnTriggerEnter(Collider other)
    {
        _topContact = true;
    }
    private void OnTriggerExit(Collider other)
    {
        _topContact = false;
    }

    void PressureCheck()
    {
        if (_topContact && !_isTrigger)
        {
            Activate();
            Anim();
        }
        if (!_topContact && _isTrigger)
        {
            Anim();
            Activate();
        }
    }

    void Anim()
    {
        if (!_isTrigger)
        {
            audioData.Play(0);
            transform.DOMoveY(BaseY - MovementHeight, MovementDuration);
            _isTrigger = true;
        }
        else
        {
            audioData.Play(0);
            transform.DOMoveY(BaseY, MovementDuration);
            _isTrigger = false;
        }
    }
}
