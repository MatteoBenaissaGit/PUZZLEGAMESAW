using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PressurePlate : MonoBehaviour
{
    public bool IsPressured;
    public float MovementHeight, MovementDuration;
    float BaseY;

    private void Start()
    {
        BaseY = transform.position.y;
    }

    private void Update()
    {
        if (CheckTopContact() && !IsPressured)
            Activate();
        if (!CheckTopContact() && IsPressured)
            Desactivate();
    }

    void Activate()
    {
        transform.DOMoveY(BaseY - MovementHeight, MovementDuration);
        IsPressured = true;
    }

    void Desactivate()
    {
        transform.DOMoveY(BaseY, MovementDuration);
        IsPressured = false;
    }

    bool CheckTopContact()
    {
        return (Physics.Raycast(transform.position, new Vector3(0,1,0), 1f, 1));
    }
}
