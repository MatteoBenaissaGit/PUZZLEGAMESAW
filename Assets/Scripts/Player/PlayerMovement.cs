using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //gets
    [SerializeField] private Logger _logger;
    private Rigidbody _rb;

    //movement's type bool
    [HideInInspector] public bool Walk;

    //variables
    [SerializeField] [Range(0f, 50.0f)] private float _moveSpeed;
    [SerializeField] [Range(0.0f, 0.5f)] private float _rotationFacingSpeed;

    private void Start()
    {
        if (GetComponent<Rigidbody>()!=null)
            _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Walking();
    }

    private void Walking()
    {
        float x = Input.GetAxis("Horizontal"), y = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(x, 0, y);
        _logger.Log($"x = {x}, y = {y}", this);
        _rb.AddForce(dir * _moveSpeed);
        if (dir.magnitude > 0)
        {
            Walk = true;
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(dir), _rotationFacingSpeed);
        }
        else
        {
            Walk = false;
        }
    }
}
