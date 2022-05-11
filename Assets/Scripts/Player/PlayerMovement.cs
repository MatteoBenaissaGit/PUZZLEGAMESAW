using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //gets
    [SerializeField] private Logger _logger;
    private Rigidbody _rb;
    private Animator _animator;

    //movement's type bool
    [HideInInspector] public bool Walk;

    //variables
    [SerializeField] [Range(0f, 100.0f)] private float _moveSpeed;
    [SerializeField] [Range(0.0f, 0.5f)] private float _rotationFacingSpeed;
    private Vector3 _dir = new Vector3();
    float x, y;

    private void Start()
    {
        if (GetComponent<Rigidbody>()!=null)
            _rb = GetComponent<Rigidbody>();
        if (GetComponent<Animator>() != null)
            _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Inputs();
    }

    private void FixedUpdate()
    {
        Walking();
    }

    private void Inputs()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        _dir = new Vector3(x, 0, y);
        _dir.Normalize();
        _logger.Log($"x = {x}, y = {y}", this);
    }

    private void Walking()
    {
        if (Mathf.Abs(x) > 0.1f || Mathf.Abs(y) > 0.1f)
        {
            _rb.AddForce(_dir * _moveSpeed);
            Walk = true;
            _animator.SetBool("Walk", true);
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(_dir), _rotationFacingSpeed);
        }
        else
        {
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            Walk = false;
            _animator.SetBool("Walk", false);
        }
    }
}
