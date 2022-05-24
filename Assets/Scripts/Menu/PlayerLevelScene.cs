using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevelScene : MonoBehaviour
{
    public Transform[] target;
    [Range(0, 4)] public int actualPos;

    Animator _anim;

    public bool canMove;
    bool actu2;

    public GameObject slider;

    [Range(1, 6)] public int levelUnlock;
    public bool selec;
    public bool canPick;

    public GameObject cacheSdb;
    public GameObject cacheBiblio;

    public GameObject UISalon;
    public GameObject UISdb;
    public GameObject UIBiblio;

    public GameObject arrow;
    private void Awake()
    {
        levelUnlock = GameData.levelUnlock;

        actualPos = GameData.actualPos;
    }
    private void Start()
    {
        transform.position = target[actualPos].position;
        canMove = true;
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        var hor = Input.GetAxis("Horizontal");
        var ver = Input.GetAxis("Vertical");

        //For test
        if (Input.GetKeyDown(KeyCode.K))
        {
            levelUnlock++;
            GameData.levelUnlock++;
        }
        //End

        if (levelUnlock >= 6)
            levelUnlock = 6;

        float step = 3 * Time.deltaTime;

        #region Input

        if (actualPos == 0)
        {
            if (Right(hor) && canMove == true)
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
            if (Up(ver) && canMove == true)
            {
                canMove = false;
                _anim.SetBool("isMouving", true);
                actu2 = true;
                StartCoroutine(Actual2());
                actualPos = 2;
                transform.LookAt(target[2]);
                StartCoroutine(Waiting());
            }

            if (Left(hor) && canMove == true)
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
            if (Left(hor) && canMove == true)
            {
                canMove = false;
                actu2 = false;
                _anim.SetBool("isMouving", true);
                actualPos = 3;
                transform.LookAt(target[3]);
                StartCoroutine(Waiting());
            }

            if (Down(ver) && canMove == true)
            {
                canMove = false;
                _anim.SetBool("isMouving", true);
                actu2 = false;
                actualPos = 1;
                transform.LookAt(target[1]);
                StartCoroutine(Waiting());
            }

            if (Up(ver) && actu2 == false && canMove == true)
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
            if (Right(hor) && canMove == true)
            {
                canMove = false;
                _anim.SetBool("isMouving", true);
                actualPos = 2;
                transform.LookAt(target[2]);
                StartCoroutine(Waiting());
            }
        }
        if (actualPos == 4)
        {
            if (Down(ver) && canMove == true)
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

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("ButtonEscape") )
        {
            UIBiblio.SetActive(false);
            UISalon.SetActive(false);
            UISdb.SetActive(false);
            arrow.SetActive(false);
            canMove = true;
            selec = false;
            canPick = false;
        }

        if (levelUnlock >= 3)
            cacheSdb.SetActive(false);
        if (levelUnlock >= 5)
            cacheBiblio.SetActive(false);

        if (actualPos == 1 && canMove == true && levelUnlock >= 5 && SelectButton())
        {
            selec = true;
            canMove = false;
            UIBiblio.SetActive(true);
            arrow.SetActive(true);
            StartCoroutine(Picked());
        }
        if (actualPos == 3 && canMove == true && SelectButton())
        {
            selec = true;
            canMove = false;
            UISalon.SetActive(true);
            arrow.SetActive(true);
            StartCoroutine(Picked());
        }
        if (actualPos == 4 && canMove == true && levelUnlock >= 3 && SelectButton())
        {
            selec = true;
            canMove = false;
            UISdb.SetActive(true);
            arrow.SetActive(true);
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
    bool SelectButton()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("ButtonActivation"))
            return true;
        else return false;
    }
    bool Up(float axis)
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || axis > 0.5f)
            return true;
        else return false;
    }
    bool Down(float axis)
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || axis < -0.5f)
            return true;
        else return false;
    }
    bool Left(float axis)
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || axis < -0.5f)
            return true;
        else return false;
    }
    bool Right(float axis)
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || axis > 0.5f)
            return true;
        else return false;
    }
}