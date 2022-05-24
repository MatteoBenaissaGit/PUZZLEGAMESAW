using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    public enum LevelChoice
    {
        Level1 = 1,
        Level2 = 2,
        Level3 = 3,
        Level4 = 4,
        Level5 = 5,
        Level6 = 6
    }

    [Header("Referencing")]
    [Space(10)]
    public GameObject Character;
    Collider _charaCollider;

    [Header("Referencing")]
    [Space(10)]
    public LevelChoice Level;

    private void Start()
    {
        _charaCollider = Character.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == _charaCollider)
            LevelEnding();
    }

    void LevelEnding()
    {
        SceneManager.LoadScene("LevelMenu");
        GameData.levelUnlock = (int)Level + 1;
    }
}
