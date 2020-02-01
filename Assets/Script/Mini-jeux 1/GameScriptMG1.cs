using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScriptMG1 : MonoBehaviour
{
    /*
    public void Wait(float seconds)
    {
        StartCoroutine(_wait(seconds));
    }
    IEnumerator _wait(float time)
    {
        Debug.Log("TIME : " + time);
        yield return new WaitForSeconds(time);
    }
    */

    public void StartQTE(GameObject GO, List<int> keys, List<int> timings)
    {
        Debug.Log("QTE FUNCTION");
        GameObject.Find("Player").GetComponent<PlayerTrash>().isInteracting = false;
        Destroy(GO);
    }
}
