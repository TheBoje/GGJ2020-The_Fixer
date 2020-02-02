using System.Collections.Generic;
using UnityEngine;

public class TrashState : MonoBehaviour
{
    [SerializeField] private int minTime = 2;   // Variable du temps minimal
    [SerializeField] private int maxTime = 2;   // Variable du temps maximal
    [SerializeField] private int minNum = 5;    // Variable du nombre de touches minimal
    [SerializeField] private int maxNum = 10;   // Variable du nombre de touches maximal

    [SerializeField] private int length;        // Taille des listes
    [SerializeField] private List<int> keys;    // Init tableaux keys
    [SerializeField] private List<int> timings; // Init tableaux timings

    public void Interact()      // Fonction appelée par PlayerTrash.cs lorsqu'un element tag "trash" + "Use" key down 
    {
        length = Random.Range(minNum, maxNum);              // Génération de la longueure des tableaux
        keys = new List<int>() { Random.Range(1, 4) };      // Initialisation de la liste keys (+ premier element, parce que sinon ça ne marche pas)
        timings = new List<int>() { Random.Range(minTime, maxTime + 1) };   // Comme au dessus
        int r;                                              // Initialisation de la variable de random
        for (int i = 0; i < length - 1; i++)
        {
            r = Random.Range(1, 4);                         // Touches sont [1;4[ donc {1, 2, 3}, remplacer 4 par n + 1 pour avoir n touches dans le QTE
            keys.Add(r);                                    // Ajout de la touche dans liste keys
        }
        for (int i = 0; i < length; i++)
        {
            r = Random.Range(minTime, maxTime + 1);         // Durée d'attente du QTE entre i et i + 1 est déterminé par timings[i] tq [minTime, maxTime], 
            timings.Add(r);                                 // Ajout de la durée dans liste timings
                                                            // Le dernier élément de timings ne doit pas être interpréter, ou alors comme un 0f, mais c'est chiant de l'implémenter ici alors au pire ou fais comme si c'était pas un probleme
        }
        GameObject.Find("Game Manager").GetComponent<GameScriptMG1>().StartQTE(gameObject, keys, timings);
                                                            // On call la fonction dans le game manager "StartQTE" qui mets en place l'UI pour le QTE. Contient le gameObject cet élément, et les deux listes
    }
}
