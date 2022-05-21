using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    private bool _canBlink;
    private bool _count;

    private void Start()
    {
        Cursor.visible = false;
        StartCoroutine(Blink());
    }
    private void Update()
    {
        FollowCursor();
    }

    public void FollowCursor()
    {
        Vector3 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.y = 7.5f;
        transform.position = mouseWorldPosition;
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(6);
        
    }
    IEnumerator Blink()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<Light>().intensity = 0;
        yield return new WaitForSeconds(0.2f);
        GetComponent<Light>().intensity = 100;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Light>().intensity = 0; 
        yield return new WaitForSeconds(0.05f);
        GetComponent<Light>().intensity = 100;
        yield return new WaitForSeconds(0.2f);
        GetComponent<Light>().intensity = 0;
        yield return new WaitForSeconds(0.7f);
        GetComponent<Light>().intensity = 100;
        yield return new WaitForSeconds(6);
        StartCoroutine(Blink());
    }
}