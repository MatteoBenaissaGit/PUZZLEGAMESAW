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

    private void Awake()
    {
        playerLevelScene.levelUnlock = GameData.levelUnlock;
        selected = 1;
        Buttons[0].transform.DOScale(new Vector3(1.1f, 1.1f, 1), timer);
    }

    private void Update()
    {
        for (int i = 1; i <= Buttons.Length; i++)
        {
            if(i <= playerLevelScene.levelUnlock)
                Buttons[i-1].SetActive(true);
        }

        if(playerLevelScene.selec == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                selected = 2;
                Buttons[0].transform.DOScale(new Vector3(1, 1, 1), timer);
                Buttons[1].transform.DOScale(new Vector3(1.1f, 1.1f, 1), timer);
                Buttons[2].transform.DOScale(new Vector3(1, 1, 1), timer);
                Buttons[3].transform.DOScale(new Vector3(1.1f, 1.1f, 1), timer);
                Buttons[4].transform.DOScale(new Vector3(1, 1, 1), timer);
                Buttons[5].transform.DOScale(new Vector3(1.1f, 1.1f, 1), timer);
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
    }
}
