using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public int levelUnlock;

    public GameObject[] Buttons;

    private void Awake()
    {
        levelUnlock = GameData.levelUnlock;
    }

    private void Update()
    {
        //For test
        if (Input.GetKeyDown(KeyCode.K))
        {
            levelUnlock++;
        }
        //End

        for (int i = 1; i <= Buttons.Length; i++)
        {
            if(i <= levelUnlock )
                Buttons[i-1].SetActive(true);
        }
    }
}
