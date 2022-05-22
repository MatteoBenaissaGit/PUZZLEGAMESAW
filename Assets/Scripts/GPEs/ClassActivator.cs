using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassActivator : MonoBehaviour
{
    [HideInInspector] public bool IsActive;

    public enum ObjectConnection
    {
        ArrowLauncher = 0,
        Other = 1
    }

    [Header("Referencing")][Space(10)]
    public GameObject Character;
    public ArrowLauncher ArrowLauncher;

    [Header("Object Connected")][Space(10)]
    [Tooltip("Object that is activated/desactivated by this button")]
    public ObjectConnection ObjectConnected;

    public virtual void Activate()
    {
        if (!IsActive)
        {
            IsActive = true;
            if (ObjectConnected == 0)
                ArrowLauncher.Desactivate();
        }
        else
        {
            IsActive = false;
            if (ObjectConnected == 0)
                ArrowLauncher.Activate();
        }
    }
}
