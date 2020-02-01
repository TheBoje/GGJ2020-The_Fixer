using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEUIScript : MonoBehaviour
{
    [SerializeField] private Image Default_Num1;
    [SerializeField] private Image Default_Num2;
    [SerializeField] private Image Default_Num3;
    [SerializeField] private Image Target_Line;
    [SerializeField] private GameObject Expected_Num1;
    [SerializeField] private GameObject Expected_Num2;
    [SerializeField] private GameObject Expected_Num3; 

    private void moveUICanvas(int id)
    {
        Debug.Log("Moving Canvas " + id);
    }

    private void QTEFadeIn()
    {

    }

    public void PlayQTEStart(List<int> keys, List<int> timings)
    {
        Debug.Log("Starting Coroutine");
        StartCoroutine(PlayQTE(keys, timings));
    }

    IEnumerator PlayQTE(List<int> keys, List<int> timings)
    {
        for (int i = 0; i < keys.Count; i++)
        {
            moveUICanvas(keys[i]);
            yield return new WaitForSeconds(timings[i]);
        }
    }


}
