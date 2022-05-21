using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Transform target;
    public Collider cube;
    public bool near;

    private void OnTrriggerEnter(Collider cube)
    {
        near = true;
    }
    void Update()
    {
        if(!near)
        {
            transform.LookAt(target);
        }

        Moving();
    }

    void Moving()
    {
        var step = 3 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

}
