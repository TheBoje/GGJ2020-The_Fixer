using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashState : MonoBehaviour
{
    [SerializeField] private int minTime = 1; // Variable du temps minimal
    [SerializeField] private int maxTime = 3; // Variable du temps maximal
    [SerializeField] private int minNum = 5; // Variable du nombre minimal
    [SerializeField] private int maxNum = 10; // Variable du nombre maximal

    [SerializeField] private int length;
    [SerializeField] private List<int> keys;
    [SerializeField] private List<int> timings;

    public void Interact()
    {
        length = Random.Range(minNum, maxNum);
        keys = new List<int>() { Random.Range(1, 4) };
        timings = new List<int>() { Random.Range(minTime, maxTime + 1) };
        int r;
        for (int i = 0; i < length -1; i++)
        {
            r = Random.Range(1, 4);
            keys.Add(r);
        }
        for (int i = 0; i < length; i++)
        {
            r = Random.Range(minTime, maxTime + 1);
            timings.Add(r);
        }
        GameObject.Find("Game Manager").GetComponent<GameScriptMG1>().StartQTE(gameObject, keys, timings);
    }
}
