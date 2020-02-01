using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashState : MonoBehaviour
{
    [SerializeField] private int minTime = 1; // Variable du temps minimal
    [SerializeField] private int maxTime = 3; // Variable du temps maximal
    [SerializeField] private int minNum = 5; // Variable du nombre minimal
    [SerializeField] private int maxNum = 10; // Variable du nombre maximal
    private int[,] array;

    public void Interact()
    {
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

        array[array.GetLength(0) - 1, 1] = 0;

        gameObject.GetComponent<GameScriptMG1>().StartQTE(this.gameObject, array);
    }
}
