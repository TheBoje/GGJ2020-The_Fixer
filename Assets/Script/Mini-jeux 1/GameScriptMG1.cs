using System.Collections.Generic;
using UnityEngine;

public class GameScriptMG1 : MonoBehaviour
{
    [SerializeField] private GameObject QTECanvas;
    public void StartQTE(GameObject GO, List<int> keys, List<int> timings) // Fonction qui récupère les 2 listes de keys & timings pour le QTE
    {
        QTECanvas.GetComponent<QTEUIScript>().PlayQTEStart(keys, timings, GO);
    }
}
