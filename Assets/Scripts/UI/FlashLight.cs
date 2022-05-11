using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject SpotLight;

    public Vector3 worldPosition;
    Plane plane = new Plane(Vector3.up, 0);
    /*
    private void Start()
    {
        Input.mousePosition = new Vector3(Screen.height / 2, Screen.width / 2);
    }*/
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        SpotLight.transform.position = Camera.main.ScreenToWorldPoint(mousePos);


        /*float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
            SpotLight.transform.position = worldPosition;*/
        
    }
}