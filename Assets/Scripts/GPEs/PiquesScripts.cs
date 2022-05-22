using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiquesScripts : MonoBehaviour
{
    public GameObject Character;

    private void OnCollisionEnter(Collision collision)
    {
        //player kill
        if (collision.collider == Character.GetComponent<Collider>())
            Character.GetComponent<PlayerLife>().IsAlive = false;
    }
}
