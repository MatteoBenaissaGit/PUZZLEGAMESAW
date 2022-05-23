using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelectLevel : MonoBehaviour
{
    public Transform[] target;
    public int actualPos;

    Animator _anim;

    public bool canMove;
    public bool actu2;

    public GameObject slider;

    public int levelUnlock;

    private void Awake()
    {
        levelUnlock = GameData.levelUnlock;
    }
    private void Start()
    {
        canMove = true;
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        float step = 3 * Time.deltaTime;

        #region Input

        if (actualPos == 0)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && canMove == true)
            {
                canMove = false;
                _anim.SetBool("isMouving", true);
                actualPos = 1;
                transform.LookAt(target[1]);
                StartCoroutine(Waiting());
            }
        }
        if (actualPos == 1)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && canMove == true && levelUnlock >= 3)
            {
                canMove = false;
                _anim.SetBool("isMouving", true);
                actu2 = true;
                StartCoroutine(Actual2());
                actualPos = 2;
                transform.LookAt(target[2]);
                StartCoroutine(Waiting());
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && canMove == true)
            {
                canMove = false;
                _anim.SetBool("isMouving", true);
                actualPos = 0;
                transform.LookAt(target[0]);
                StartCoroutine(Waiting());
            }
        }
        if (actualPos == 2)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && canMove == true)
            {
                canMove = false;
                actu2 = false;
                _anim.SetBool("isMouving", true);
                actualPos = 3;
                transform.LookAt(target[3]);
                StartCoroutine(Waiting());
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && canMove == true)
            {
                canMove = false;
                _anim.SetBool("isMouving", true);
                actu2 = false;
                actualPos = 1;
                transform.LookAt(target[1]);
                StartCoroutine(Waiting());
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && actu2 == false && canMove == true && levelUnlock >= 5)
            {
                canMove = false;
                _anim.SetBool("isMouving", true);
                actu2 = false;
                actualPos = 4;
                transform.LookAt(target[4]);
                StartCoroutine(Waiting());
            }
        }
        if (actualPos == 3)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && canMove == true)
            {
                canMove = false;
                _anim.SetBool("isMouving", true);
                actualPos = 2;
                transform.LookAt(target[2]);
                StartCoroutine(Waiting());
            }
        }
        if(actualPos == 4)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && canMove == true)
            {
                canMove = false;
                _anim.SetBool("isMouving", true);
                actualPos = 2;
                transform.LookAt(target[2]);
                StartCoroutine(Waiting());
            }
        }

        #endregion

        #region Mouvement
        if (actualPos == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target[0].position, step);
        }
        if (actualPos == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, target[1].position, step);
        }
        if (actualPos == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, target[2].position, step);
        }
        if (actualPos == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, target[3].position, step);
        }
        if (actualPos == 4)
        {
            transform.position = Vector3.MoveTowards(transform.position, target[4].position, step);
        }
        #endregion

        #region EnterInLevel
        if (actualPos == 1 && canMove == true && Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(Switch());
        }
        if (actualPos == 3 && canMove == true && Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(Switch());
        }
        if (actualPos == 4 && canMove == true && Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(Switch());
        }
        #endregion
    }

    #region Coroutine
    IEnumerator Actual2()
    {
        yield return new WaitForSeconds(0.1f);
        actu2 = false;
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1.5f);
        canMove = true;
        _anim.SetBool("isMouving", false);
    }

    IEnumerator Switch()
    {
        slider.SetActive(true);
        yield return new WaitForSeconds(2);
        if(actualPos == 1)
            SceneManager.LoadScene(2);
        if (actualPos == 3)
            SceneManager.LoadScene(2);
        if (actualPos == 4)
            SceneManager.LoadScene(2);
    }
    #endregion
}