using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SlideInUI : MonoBehaviour
{
    private void Update()
    {
        transform.DOLocalMove(new Vector3(4500, 1, 0), 1.5f);
    }
}