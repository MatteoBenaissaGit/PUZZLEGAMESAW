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
    [Range(0.0f, 1f)] public float PullForce;

    Vector3 _dir = new Vector3();
    float _x, _y, _xy, _currentSpeed;
    bool _push, _pull;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _currentSpeed = MoveSpeed;
    }

    void Update()
    {
        Inputs();
    }

    void FixedUpdate()
    {
        Moving();
        Animating();
        Pulling();
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

    void Moving()
    {
        //movement
        _rb.AddForce(_dir * _currentSpeed);
        if (_xy > 0.1f) Mathf.Lerp(_currentSpeed, MoveSpeed, 0.1f);
    }

    void Animating()
    {
        //anim
        _anim.SetFloat("PlayerSpeed", _xy);
        _xy = Mathf.Abs(_x) + Mathf.Abs(_y);
        if (_xy > 0.1f){
            _anim.SetBool("Walk", true);
            if (!_pull) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_dir), RotationFacingSpeed);
            if (CheckForwardContact()) { _anim.SetBool("Push", true); _push = true; }
            else { _anim.SetBool("Push", false); _push = false; }
        }
        else{
            _anim.SetBool("Push", false); _push = false;
            _anim.SetBool("Walk", false);
        }
    }

    void Pulling()
    {
        Vector3 offset = Vector3.zero;
        if (CheckForwardContact() && (Input.GetAxis("Pull") != 0 || Input.GetAxis("PullKeyboard") != 0)){
            _anim.SetBool("Pull", true); _pull = true;
            GameObject pulledObject;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit)){
                pulledObject = hit.collider.gameObject;
                if (offset == Vector3.zero) offset = transform.position - hit.collider.gameObject.transform.position;
                //
            }
        }
        else{
            _anim.SetBool("Pull", false); _pull = false;
            offset = Vector3.zero;
        }
    }

    bool CheckForwardContact(){
        return (Physics.Raycast(transform.position, transform.forward, .5f, 1));
    }
}
