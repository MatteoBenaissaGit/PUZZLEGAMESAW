using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disjoncteur : ClassActivator
{
    bool _isTrigger;
    Animator _anim;
    Animator _characterAnim;
    Collider _characterCollider;
    
    [Header("Button&Cam Reference")][Space(10)]
    public GameObject ButtonImage;
    public Transform Camera;

    private void Start()
    {
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
