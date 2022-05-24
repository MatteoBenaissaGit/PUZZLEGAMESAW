using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevelScene : MonoBehaviour
{
    public Transform[] target;
    public int actualPos;

    Animator _anim;

    public bool canMove;
    public bool actu2;

    public GameObject slider;

    public int levelUnlock;
    public bool selec;
    public bool canPick;

    public GameObject cacheSdb;
    public GameObject cacheBiblio;

    public GameObject UISalon;
    public GameObject UISdb;
    public GameObject UIBiblio;

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
        //For test
        if (Input.GetKeyDown(KeyCode.K))
        {
            levelUnlock++;
        }
        //End

        if (levelUnlock >= 6)
            levelUnlock = 6;

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
            if (Input.GetKeyDown(KeyCode.UpArrow) && canMove == true)
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

            if (Input.GetKeyDown(KeyCode.UpArrow) && actu2 == false && canMove == true)
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

        #region UISelection
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIBiblio.SetActive(false);
            UISalon.SetActive(false);
            UISdb.SetActive(false);
            canMove = true;
            selec = false;
            canPick = false;
        }

        if (levelUnlock >= 3)
            cacheSdb.SetActive(false);
        if(levelUnlock >= 5)
            cacheBiblio.SetActive(false);

        if (actualPos == 1 && canMove == true && levelUnlock >= 5 && Input.GetKeyDown(KeyCode.Return))
        {
            selec = true;
            canMove = false;
            UIBiblio.SetActive(true);
            StartCoroutine(Picked());
        }
        if (actualPos == 3 && canMove == true && Input.GetKeyDown(KeyCode.Return))
        {
            selec = true;
            canMove = false;
            UISalon.SetActive(true);
            StartCoroutine(Picked());
        }
        if (actualPos == 4 && canMove == true && levelUnlock >= 3 && Input.GetKeyDown(KeyCode.Return))
        {
            selec = true;
            canMove = false;
            UISdb.SetActive(true);
            StartCoroutine(Picked());
        }
        #endregion
    }

    #region Coroutine
    IEnumerator Actual2()
    {
        yield return new WaitForSeconds(0.1f);
        actu2 = false;
    }

    IEnumerator Picked()
    {
        yield return new WaitForSeconds(0.1f);
        canPick = true;
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1.5f);
        canMove = true;
        _anim.SetBool("isMouving", false);
    }
    #endregion
}