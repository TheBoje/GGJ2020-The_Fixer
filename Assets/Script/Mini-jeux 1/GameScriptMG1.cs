using System.Collections.Generic;
using UnityEngine;

public class GameScriptMG1 : MonoBehaviour
{
    [SerializeField] private GameObject QTECanvas;
    public void StartQTE(GameObject GO, List<int> keys, List<int> timings) // Fonction qui récupère les 2 listes de keys & timings pour le QTE
    {
        QTECanvas.GetComponent<QTEUIScript>().PlayQTEStart(keys, timings);
        GameObject.Find("Player").GetComponent<PlayerTrash>().isInteracting = false;    // isInteracting permet au player de ne pas spam l'interaction QTE, donc il faut la reset une fois que l'action est terminée (ratée ou réussite).
        Destroy(GO);    // Destruction de la case un fois que le QTE est fini ( faire condition victoire / défaite)
    }
}
