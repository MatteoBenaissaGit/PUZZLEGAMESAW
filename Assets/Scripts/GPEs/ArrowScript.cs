using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float movementSpeed;

    private void Update()
    {
        transform.position -= transform.forward * Time.deltaTime * movementSpeed; 
    }
}
