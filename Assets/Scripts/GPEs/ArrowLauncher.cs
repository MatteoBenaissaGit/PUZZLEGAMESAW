using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLauncher : MonoBehaviour
{
    [HideInInspector] public bool IsTriggered;
    [HideInInspector] public bool IsActivated = true;
    float _timer = 0;
    Collider _characterCollider;
    LineRenderer _lineRenderer;
    Collider _laserCollider;

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
    [Range(0.01f, 0.25f)] public float LaserWidth;
    public ColorChoice.HueColorNames LaserColor;

    private void Start()
    {
        _characterCollider = Character.GetComponent<Collider>();
        ArrowLine();
    }

    private void Update()
    {
        CharacterDetector();
        if (IsActivated)
            ResetArrowLine();
    }

    void CharacterDetector()
    {
        //timer & arrow launching management
        _timer--;
        if (IsActivated && IsTriggered && _timer <= 0 && Character.GetComponent<PlayerLife>().IsAlive && _laserCollider == Character.GetComponent<Collider>())
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
        arrow.GetComponent<ArrowScript>().DirectionForward = transform.forward + new Vector3(-90, 0, 0);
        arrow.GetComponent<ArrowScript>().Character = Character;
    }

    private void OnTriggerEnter(Collider other)
    {
        //check player in trigger
        if (other == _characterCollider)
            IsTriggered = true;
        ResetArrowLine();
    }
    private void OnTriggerExit(Collider other)
    {
        //reset trigger when player get out of it
        if (other == _characterCollider)
            IsTriggered = false;
        ResetArrowLine();
    }

    void ArrowLine()
    {

        //creating line renderer object
        _lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
        _lineRenderer.startColor = ColorChoice.HueColourValue(LaserColor);
        _lineRenderer.endColor = ColorChoice.HueColourValue(LaserColor);
        _lineRenderer.startWidth = LaserWidth;
        _lineRenderer.endWidth = LaserWidth;
        _lineRenderer.positionCount = 2;
        _lineRenderer.useWorldSpace = true;
        Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
        _lineRenderer.material = whiteDiffuseMat;

        //drawing line in the world space
        _lineRenderer.SetPosition(0, transform.position);
        RaycastHit hit;
        Vector3 rayDirection = transform.TransformDirection(transform.forward) + new Vector3(-90, 0, 0);
        if (Physics.Raycast(transform.position, rayDirection, out hit))
        {
            _lineRenderer.SetPosition(1, hit.point);
            _laserCollider = hit.collider;
        }
    }

    void ResetArrowLine()
    {
        if (_lineRenderer != null)
            Destroy(_lineRenderer.gameObject);
        if (IsActivated)
            ArrowLine();
    }

    public void Desactivate()
    {
        IsActivated = false;
        ResetArrowLine();
    }

    public void Activate()
    {
        IsActivated = true;
        ResetArrowLine();
    }
}
