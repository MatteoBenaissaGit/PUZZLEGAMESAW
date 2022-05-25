using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToCredits : MonoBehaviour
{
    public GameObject Character;
    Collider _charaCollider;

    public GameObject slider;

    private void Start()
    {
        _charaCollider = Character.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == _charaCollider)
        {
            slider.SetActive(true);
            StartCoroutine(Waiting());
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(8);
    }
}
