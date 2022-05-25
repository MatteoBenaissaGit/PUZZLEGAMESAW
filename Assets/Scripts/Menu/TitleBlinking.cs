using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBlinking : MonoBehaviour
{
    public GameObject letter;

    private void Start()
    {
        StartCoroutine(Blink2());
        
    }
    IEnumerator Blink2()
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
        letter.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
        letter.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
        letter.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
        letter.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
        letter.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
        letter.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(Random.Range(1, 5));
        StartCoroutine(Blink2());
    }
}
