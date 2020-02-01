using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScriptMG1 : MonoBehaviour
{
    public void Wait(float seconds)
    {
        StartCoroutine(_wait(seconds));
    }
    IEnumerator _wait(float time)
    {
        yield return new WaitForSeconds(time);
    }


    public void StartQTE(GameObject GO, int[,] list)
    {
        for (int i = 0; i < list.GetLength(0); i++)
        {
            Debug.Log(list[i, 0]);
            Wait(list[i, 1]);
            Debug.Log("Waited " + list[i, 1]);
        }
        GameObject.Find("Player").GetComponent<PlayerTrash>().isInteracting = false;
    }
}
