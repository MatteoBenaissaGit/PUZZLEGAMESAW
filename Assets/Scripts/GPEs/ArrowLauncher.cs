using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLauncher : MonoBehaviour
{
    [HideInInspector] public bool IsTriggered;
    [HideInInspector] public bool IsActivated = true;
    float _timer = 0;
    Collider _characterCollider;

    [Header("Referencing")]
    [Space(10)]
    public GameObject Character;
    public GameObject Arrow;
    public Transform SpawnPoint;

    [Header("Variables")]
    [Space(10)]
    [Tooltip("---EN \n Speed of the arrow thrown by the launcher \n ---FR \n Vitesse des flèches tirées par la lance-flèche")]
    [Range(0f, 1f)] public float ArrowSpeed;
    [Tooltip("---EN \n The rate of arrow throwed in seconds \n ---FR \n La fréquence de tir des flèches en secondes")]
    [Range(0f, 5f)] public float ShootingRate;

    private void Start()
    {
        _characterCollider = Character.GetComponent<Collider>();
    }

    private void Update()
    {
        CharacterDetector();
    }

    void CharacterDetector()
    {
        //timer & arrow launching management
        _timer--;
        if (IsActivated && IsTriggered && _timer <= 0 && Character.GetComponent<PlayerLife>().IsAlive)
        {
            LaunchArrow();
            float framerate = 1.0f / Time.deltaTime;
            _timer = ShootingRate * framerate;
        }
    }

    void LaunchArrow()
    {
        //arrow setup
        GameObject arrow = Instantiate(Arrow);
        arrow.GetComponent<ArrowScript>().MovementSpeed = ArrowSpeed;
        arrow.transform.position = SpawnPoint.transform.position;
        arrow.GetComponent<ArrowScript>().DirectionForward = transform.forward + new Vector3(-90,0,0);
        arrow.GetComponent<ArrowScript>().Character = Character;
    }

    private void OnTriggerEnter(Collider other)
    {
        //check player in trigger
        if (other == _characterCollider)
            IsTriggered = true;
    }
    private void OnTriggerExit(Collider other)
    {
        //reset trigger when player get out of it
        if (other == _characterCollider)
            IsTriggered = false;
    }
}
