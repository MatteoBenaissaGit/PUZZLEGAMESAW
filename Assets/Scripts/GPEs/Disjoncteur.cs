using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disjoncteur : ClassActivator
{
    bool _isTrigger;
    Animator _anim;
    Animator _characterAnim;
    Collider _characterCollider;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _characterAnim = Character.GetComponent<Animator>();
        _characterCollider = Character.GetComponent<Collider>();
    }

    private void Update()
    {
        PushCheck();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == _characterCollider)
            _isTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == _characterCollider)
            _isTrigger = false;
    }

    void PushCheck()
    {
        if (_isTrigger && Input.GetButtonDown("ButtonActivation"))
            Pushed();
    }

    void Pushed()
    {
        _anim.SetTrigger("Push");
        _characterAnim.SetTrigger("PushButton");
        Activate();
    }
}
