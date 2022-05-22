using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PressurePlate : ClassActivator
{
    [Header("Pressure Plate Parameters")]
    [Space(10)]
    public float MovementHeight, MovementDuration;
    float BaseY;
    bool _isTrigger;

    private void Start()
    {
        BaseY = transform.position.y;
        IsActive = false;
    }

    private void Update()
    {
        PressureCheck();
    }

    void PressureCheck()
    {
        if (CheckTopContact() && !_isTrigger)
        {
            Activate();
            Anim();
        }
        if (!CheckTopContact() && _isTrigger)
        {
            Anim();
            Activate();
        }
    }

    void Anim()
    {
        if (!_isTrigger)
        {
            transform.DOMoveY(BaseY - MovementHeight, MovementDuration);
            _isTrigger = true;
        }
        else
        {
            transform.DOMoveY(BaseY, MovementDuration);
            _isTrigger = false;
        }
    }

    bool CheckTopContact()
    {
        return (Physics.Raycast(transform.position, new Vector3(0, 1, 0), 1f, 1));
    }
}
