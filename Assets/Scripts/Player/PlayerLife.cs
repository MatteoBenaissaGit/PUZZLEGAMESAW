using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [HideInInspector] public bool IsAlive = true;

    [Header("Variables")]
    [Space(10)]
    [Tooltip("---EN \n Time it takes to reset scene after player's death \n ---FR \n Le temps que met le jeu a reset la scene à la mort du joueur")]
    [Range(0,10)] public int TimeToDie;
    [Header("Referencing")]
    [Space(10)]
    public GameObject Slider;

    private void Update()
    {
        LifeChecking();
    }

    void LifeChecking()
    {
        if (!IsAlive)
        {
            gameObject.GetComponent<PlayerMovement>().IsAlive = false;
            GetComponent<Animator>().SetBool("Alive", false);
            StartCoroutine(CharacterDies());
        }
    }

    IEnumerator CharacterDies()
    {
        yield return new WaitForSeconds(TimeToDie);
        if (Slider!=null)
            Slider.SetActive(true);
        yield return new WaitForSeconds(2);
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name); 
    }
}
