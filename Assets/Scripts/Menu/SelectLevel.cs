using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SelectLevel : MonoBehaviour
{
    public PlayerLevelScene playerLevelScene;
    
    public GameObject[] Buttons;

    public int selected;
    public float timer = 0.3f;

    public GameObject slider;

    public int switchLevel = 0;

    private void Awake()
    {
        selected = 1;
        Buttons[0].transform.DOScale(new Vector3(1.1f, 1.1f, 1), timer);
        Buttons[2].transform.DOScale(new Vector3(1.1f, 1.1f, 1), timer);
        Buttons[4].transform.DOScale(new Vector3(1.1f, 1.1f, 1), timer);
    }

    private void Update()
    {
        for (int i = 1; i <= Buttons.Length; i++)
        {
            if(i <= playerLevelScene.levelUnlock)
                Buttons[i-1].SetActive(true);
        }

        if (playerLevelScene.selec == false)
        {
            selected = 1;
            Buttons[0].transform.DOScale(new Vector3(1.1f, 1.1f, 1), timer);
            Buttons[2].transform.DOScale(new Vector3(1.1f, 1.1f, 1), timer);
            Buttons[4].transform.DOScale(new Vector3(1.1f, 1.1f, 1), timer);
            Buttons[1].transform.DOScale(new Vector3(1, 1, 1), timer);
            Buttons[3].transform.DOScale(new Vector3(1, 1, 1), timer);
            Buttons[5].transform.DOScale(new Vector3(1, 1, 1), timer);
        }
            

        if(playerLevelScene.selec == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if(playerLevelScene.levelUnlock % 2 == 0)
                {
                    selected = 2;
                    
                    if(playerLevelScene.levelUnlock >= 2)
                    {
                        Buttons[0].transform.DOScale(new Vector3(1, 1, 1), timer);
                        Buttons[1].transform.DOScale(new Vector3(1.1f, 1.1f, 1), timer);
                    }
                    if (playerLevelScene.levelUnlock >= 4)
                    {
                        Buttons[2].transform.DOScale(new Vector3(1, 1, 1), timer);
                        Buttons[3].transform.DOScale(new Vector3(1.1f, 1.1f, 1), timer);
                    }
                    if (playerLevelScene.levelUnlock >= 6)
                    {
                        Buttons[4].transform.DOScale(new Vector3(1, 1, 1), timer);
                        Buttons[5].transform.DOScale(new Vector3(1.1f, 1.1f, 1), timer);
                    }
                }
            }
                
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                selected = 1;
                Buttons[0].transform.DOScale(new Vector3(1.1f, 1.1f, 1), timer);
                Buttons[1].transform.DOScale(new Vector3(1, 1, 1), timer);
                Buttons[2].transform.DOScale(new Vector3(1.1f, 1.1f, 1), timer);
                Buttons[3].transform.DOScale(new Vector3(1, 1, 1), timer);
                Buttons[4].transform.DOScale(new Vector3(1.1f, 1.1f, 1), timer);
                Buttons[5].transform.DOScale(new Vector3(1, 1, 1), timer);
            }
        }

        if(selected == 1)
        {
            if(playerLevelScene.actualPos == 1 && playerLevelScene.levelUnlock >= 5 && Input.GetKeyDown(KeyCode.Return) && playerLevelScene.canPick == true)
            {
                switchLevel = 5;
                StartCoroutine(Switch());
            }
            if (playerLevelScene.actualPos == 3 && Input.GetKeyDown(KeyCode.Return) && playerLevelScene.canPick == true)
            {
                switchLevel = 1;
                StartCoroutine(Switch());
            }
            if (playerLevelScene.actualPos == 4 && playerLevelScene.levelUnlock >= 3 && Input.GetKeyDown(KeyCode.Return) && playerLevelScene.canPick == true)
            {
                switchLevel = 3;
                StartCoroutine(Switch());
            }
        }
        if (selected == 2)
        {
            if (playerLevelScene.actualPos == 1 && playerLevelScene.levelUnlock >= 6 && Input.GetKeyDown(KeyCode.Return) && playerLevelScene.canPick == true)
            {
                switchLevel = 6;
                StartCoroutine(Switch());
            }
            if (playerLevelScene.actualPos == 3 && playerLevelScene.levelUnlock >= 2 && Input.GetKeyDown(KeyCode.Return) && playerLevelScene.canPick == true)
            {
                switchLevel = 2;
                StartCoroutine(Switch());
            }
            if (playerLevelScene.actualPos == 4 && playerLevelScene.levelUnlock >= 4 && Input.GetKeyDown(KeyCode.Return) && playerLevelScene.canPick == true)
            {
                switchLevel = 4;
                StartCoroutine(Switch());
            }
        }
    }

    IEnumerator Switch()
    {
        playerLevelScene.UIBiblio.SetActive(false);
        playerLevelScene.UISalon.SetActive(false);
        playerLevelScene.UISdb.SetActive(false);
        slider.SetActive(true);
        yield return new WaitForSeconds(2);

        if (switchLevel == 1)
            SceneManager.LoadScene(2);
        if (switchLevel == 2)
            SceneManager.LoadScene(3);
        if (switchLevel == 3)
            SceneManager.LoadScene(4);
        if (switchLevel == 4)
            SceneManager.LoadScene(2);
        if (switchLevel == 5)
            SceneManager.LoadScene(2);
        if (switchLevel == 6)
            SceneManager.LoadScene(2);
    }
}