using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PlayerMovement : MonoBehaviour
{

    [Header("Character's physic variables")]
    [Space(10)]
    [Tooltip("---EN \n The speed of the character \n " +
        "---FR \n La vitesse du personnage")]
    [Range(0f, 100.0f)] public float MoveSpeed;
    [Tooltip("---EN \n The speed at which the character can turn to another direction \n " +
        "---FR \n La vitesse à laquelle le personnage peut se tourner dans une autre direction")]
    [Range(0.0f, 0.5f)] public float RotationFacingSpeed;
    [Tooltip("---EN \n The tracting force that the character has to pull objects \n " +
        "---FR \n La force du personnage pour tirer des objets")]
    [Range(0.0f, 1f)] public float PullForce;

    [Header("Input variables")]
    [Space(10)]
    [Tooltip("---EN \n Control necessary closeness between the direction of the joystick and the back direction of the character to be able to pull, the lower it is the higher the tolerance is \n " +
        "---FR \n Controle le rapprochement nécéssaire entre la direction du joystick et la direction back du personnage pour pouvoir tirer, plus elle est faible plus la tolérance est elevée")]
    [Range(0.0f, 1f)] public float JoystickPullDeadzone;

    Rigidbody _rb;
    Animator _anim;

    AudioSource audioData;
    public bool _sound = true;

    Vector3 _dir = new Vector3();
    float _x, _y, _xy, _currentSpeed;
    bool _push, _pull;
    GameObject _pulledObject;
    [HideInInspector] public bool IsAlive = true;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _currentSpeed = MoveSpeed;

        audioData = GetComponent<AudioSource>();
    }

    void Update()
    {
        Inputs();
    }

    void FixedUpdate()
    {
        if (IsAlive)
        {
            Moving();
            Animating();
            Pulling();

            Sound();
        }
    }

    void Inputs()
    {
        //inputs
        if (!_anim.GetCurrentAnimatorStateInfo(0).IsName("Standing") && !_anim.GetCurrentAnimatorStateInfo(0).IsName("PushButton"))
        {
            _x = Input.GetAxis("Horizontal");
            _y = Input.GetAxis("Vertical");  
        }

        //direction
        _dir = new Vector3(_x, 0, _y);
        if (_pull)
        {
            Vector3 diff = _dir - (-transform.forward), lateral = new Vector3(JoystickPullDeadzone, JoystickPullDeadzone, JoystickPullDeadzone);
            if (Vector3.Distance(diff, lateral) < 1f) _dir = -transform.forward;
            else _dir = Vector3.zero;
        }
        _dir.Normalize();
    }

    void Sound()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            if (_sound)
            {
                _sound = false;
                audioData.Play(0);
                StartCoroutine(SoundCheck());
            }
        }
    }
    IEnumerator SoundCheck()
    {
        yield return new WaitForSeconds(0.8f);
        _sound = true;
    }

    void Moving()
    {
        //movement
        Vector3 force = _dir * _currentSpeed;
        if (_pull) force *= PullForce;
        _rb.AddForce(force);
        if (_xy > 0.1f) Mathf.Lerp(_currentSpeed, MoveSpeed, 0.1f);
    }


    void Animating()
    {
        //anim
        _anim.SetFloat("PlayerSpeed", Mathf.Abs(_rb.velocity.magnitude));
        _xy = Mathf.Abs(_x) + Mathf.Abs(_y);
        if (_xy > 0.1f)
        {
            _anim.SetBool("Walk", true);
            if (!_pull) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_dir), RotationFacingSpeed);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.collider.tag != "PressurePlate") //dont push if its the pressure plate collider
                {
                    if (CheckForwardContact()) { _anim.SetBool("Push", true); _push = true; }
                    else { _anim.SetBool("Push", false); _push = false; }
                }
            }
        }
        else
        {
            _anim.SetBool("Push", false); _push = false;
            _anim.SetBool("Walk", false);
        }
    }

    void Pulling()
    {
        Vector3 offset = Vector3.zero;
        if (CheckForwardContact() && (Input.GetAxis("Pull") != 0 || Input.GetAxis("PullKeyboard") != 0))
        {
            //anim & speed
            _anim.SetBool("Pull", true); _pull = true;

            //object pulled management 
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                _pulledObject = hit.collider.gameObject;
                if (offset == Vector3.zero) offset = transform.position - hit.collider.gameObject.transform.position;
                if (_pulledObject.GetComponent<Rigidbody>() != null)
                {
                    _pulledObject.GetComponent<Rigidbody>().isKinematic = true;
                    _pulledObject.transform.SetParent(this.gameObject.transform);
                }
            }
        }
        else
        {
            //reset pulled object & player's anim
            if (_pulledObject != null)
            {
                if (_pulledObject.GetComponent<Rigidbody>() != null)
                    _pulledObject.GetComponent<Rigidbody>().isKinematic = false;
                _pulledObject.transform.SetParent(null); _pulledObject = null;
            }
            _anim.SetBool("Pull", false); _pull = false;
            offset = Vector3.zero;
        }
    }

    bool CheckForwardContact()
    {
        return (Physics.Raycast(transform.position, transform.forward, .5f, 1));
    }
}
