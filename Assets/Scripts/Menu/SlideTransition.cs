using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SlideTransition : MonoBehaviour
{
    private void Update()
    {
        transform.DOMove(new Vector3(25, 1, 0), 1.5f);
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}
