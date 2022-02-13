using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class ComboText : MonoBehaviour
{
    [SerializeField]
    TextMeshPro text;
    public void DisplayCombo(string val)
    {
        transform.localPosition = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 10f);
        
        transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(-30f, 30f));

        text.text = val;

        StartCoroutine(WaitAndHide());
    }

    IEnumerator WaitAndHide()
    {
        yield return new WaitForSeconds(0.6f);
        text.text = "";
    }
}
