using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Transform[] target;
    public int actualPos;
    public bool _canMove;


    void Update()
    {
        float step = 3 * Time.deltaTime;

        if (actualPos == 0 && _canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, target[0].position, step);
        }
        if (actualPos == 1 && _canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, target[1].position, step);
        }
        if (actualPos == 2 && _canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, target[2].position, step);
        }
        if (actualPos == 3 && _canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, target[3].position, step);
        }
        if (actualPos == 4 && _canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, target[4].position, step);
        }


        //ActualPos = 0
        if (actualPos == 0)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                actualPos = 1;
                transform.LookAt(target[1]);
                _canMove = true;
                StartCoroutine(Moving());
            }
        }

        //ActualPos = 1
        if (actualPos == 1)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                actualPos = 2;
                transform.LookAt(target[2]);
                _canMove = true;
                StartCoroutine(Moving());
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                actualPos = 0;
                transform.LookAt(target[0]);
                _canMove = true;
                StartCoroutine(Moving());
            }
        }

        //ActualPos = 2
        if (actualPos == 2)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                actualPos = 3;
                transform.LookAt(target[3]);
                _canMove = true;
                StartCoroutine(Moving());
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                actualPos = 1;
                transform.LookAt(target[1]);
                _canMove = true;
                StartCoroutine(Moving());
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                actualPos = 4;
                transform.LookAt(target[4]);
                _canMove = true;
                StartCoroutine(Moving());
            }
        }

        //ActualPos = 3
        if (actualPos == 3)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                actualPos = 2;
                transform.LookAt(target[2]);
                _canMove = true;
                StartCoroutine(Moving());
            }
        }

        if(actualPos == 4)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                actualPos = 2;
                transform.LookAt(target[2]);
                _canMove = true;
                StartCoroutine(Moving());
            }
        }

    }

    IEnumerator Moving()
    {
        yield return new WaitForSeconds(0);
        //yield return new WaitForSeconds(2);
        //_canMove = false;
    }
}