using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectConnection
{
    ArrowLauncher = 0,
    Other = 1
}
public class Disjoncteur : MonoBehaviour
{
    bool _isActive;
    bool _isTrigger;
    Animator _anim;
    Animator _characterAnim;
    Collider _characterCollider;

    [Header("Referencing")] [Space(10)]
    public GameObject Character;
    public ArrowLauncher ArrowLauncher;
    [Header("Object Connected")] [Space(10)] [Tooltip("Object that is activated/desactivated by this button")]
    public ObjectConnection ObjectConnected;

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
        if (!_isActive)
            Activate();
        else
            Desactivate();
    }

    void Activate()
    {
        _isActive = true;
        if (ObjectConnected == 0)
            ArrowLauncher.Desactivate();
    }

    void Desactivate()
    {
        _isActive = false;
        if (ObjectConnected == 0)
            ArrowLauncher.Activate();
    }
}
