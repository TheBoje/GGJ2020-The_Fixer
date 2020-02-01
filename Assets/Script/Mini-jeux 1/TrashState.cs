using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashState : MonoBehaviour
{
    [SerializeField] private int minTime; // Variable du temps minimal
    [SerializeField] private int maxTime; // Variable du temps maximal
    [SerializeField] private int minNum; // Variable du nombre minimal
    [SerializeField] private int maxNum; // Variable du nombre maximal
    private int[,] array;

    public void Interact()
    {
        minTime = 1;
        maxTime = 3;
        minNum = 5;
        maxNum = 10;
        array = new int[Random.Range(minNum, maxNum + 1), 2];

        for (int i = 0; i < array.GetLength(0); i++)
        {
            int random = Random.Range(1, 4);

            array[i, 0] = random;
        }

        for (int i = 0; i < array.GetLength(0) - 1; i++)
        {
            int random = Random.Range(minTime, maxTime + 1);

            array[i, 1] = random;
        }

        array[array.GetLength(0), 1] = 0;

        gameObject.GetComponent<GameScriptMG1>().StartQTE(this.gameObject, array);
    }
}
