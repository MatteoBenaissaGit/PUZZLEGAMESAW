using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancePique : MonoBehaviour
{
    [Header("Referencing")]
    [Space(10)]
    [Tooltip("---EN \n The speed of the character \n ---FR \n La vitesse du personnage")]
        public Collider CharacterCollider;
        public GameObject Arrow;
        public BoxCollider Detector;

    [Header("Booleans, do NOT touch !")]
    [Space(10)]
        public bool IsActivated = true;
        public bool IsTriggered;

    [Header("Variables")]
    [Space(10)]
        public float ArrowSpeed;

    private void Update()
    {
        CharacterDetector();
    }

    void CharacterDetector()
    {
        if (IsActivated && IsTriggered)
        {
            LaunchArrow();
        }
    }

    void LaunchArrow()
    {
        Instantiate(Arrow, transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == CharacterCollider)
            IsTriggered = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == CharacterCollider)
            IsTriggered = false;
    }
}
