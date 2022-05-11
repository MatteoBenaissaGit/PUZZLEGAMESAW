using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Logger _logger;

    Rigidbody _rb;
    Animator _anim;

    [Range(0f, 100.0f)] public float MoveSpeed;
    [Range(0.0f, 0.5f)] public float RotationFacingSpeed;

    Vector3 _dir = new Vector3();
    float _x, _y;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        Inputs();
    }

    void FixedUpdate()
    {
        Walking();
    }

    void Inputs()
    {
        //inputs
        if (!_anim.GetCurrentAnimatorStateInfo(0).IsName("Standing"))
        {
            _x = Input.GetAxis("Horizontal");
            _y = Input.GetAxis("Vertical");
        }

        //direction
        _dir = new Vector3(_x, 0, _y);
        _dir.Normalize();

        _logger.Log($"x = {_x}, y = {_y}", this);
    }

    void Walking()
    {
        //movement
        _rb.AddForce(_dir * MoveSpeed);

        //anim
        float xy = Mathf.Abs(_x) + Mathf.Abs(_y);
        if (xy > 0.1f)
        {
            _anim.SetBool("Walk", true);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_dir), RotationFacingSpeed);
            if (CheckForwardContact()) _anim.SetBool("Push", true);
            else _anim.SetBool("Push", false);
        }
        else
        {
            _anim.SetBool("Push", false);
            _anim.SetBool("Walk", false);
        }

    }

    bool CheckForwardContact()
    {
        return (Physics.Raycast(transform.position, transform.forward, .5f, 1));
    }
}
