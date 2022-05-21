using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [HideInInspector] public float MovementSpeed;
    [HideInInspector] public Vector3 DirectionForward;
    [HideInInspector] public GameObject Character;

    bool stuck;

    private void Update()
    {
        //arrow movement
        if (!stuck)
            transform.position += DirectionForward * Time.deltaTime * MovementSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //player kill
        if (collision.collider == Character.GetComponent<Collider>() && !stuck)
        {
            Character.GetComponent<PlayerLife>().IsAlive = false;
            gameObject.transform.SetParent(Character.transform);
        }
        //arrow contact to something
        stuck = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
