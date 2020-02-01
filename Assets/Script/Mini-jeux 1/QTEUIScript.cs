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
    [SerializeField] private GameObject Instance;
    [SerializeField] private List<int> debug_keys;
    [SerializeField] private List<int> debug_timings;


    private void Start()
    {
        Default_Num1.color = new Color(1, 1, 1, 0);
        Default_Num2.color = new Color(1, 1, 1, 0);
        Default_Num3.color = new Color(1, 1, 1, 0);
    }
    public void MoveUICanvas(int id) // Il faut instancier les images à partir des Default_..., les faire fadeIn, puis les faire slide jusqu'a Expected_..., et vérifier si l'utilisateur appuie ou non sur les touches qui faut
    {
        switch (id) // Juste pour débug, fais fadein puis fadeout les images, mais des fois plusieurs apparaissent (TODO : A DEBUG)
        {
            case 1:
                StartCoroutine(FadeImage(false, Default_Num1));
                StartCoroutine(FadeImage(true, Default_Num1));
                break;
            case 2:
                StartCoroutine(FadeImage(false, Default_Num2));
                StartCoroutine(FadeImage(true, Default_Num2));
                break;
            case 3:
                StartCoroutine(FadeImage(false, Default_Num3));
                StartCoroutine(FadeImage(true, Default_Num3));
                break;
            default:
                Debug.LogError("Erreur instanciation MoveUICanvas() from QTEUIScript, id unknown");
                break;
        }
    }

    IEnumerator FadeImage(bool fadeAway, Image img) // fadeAway = true -> FadeOut, fadeAway = false -> FadeIn
    {
        if (fadeAway)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        else
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
    IEnumerator PlayQTE(List<int> keys, List<int> timings)  // Coroutine main, Distribue les valeurs dans le switch
    {
        debug_keys = keys;      // Temp pour débug les doublons
        debug_timings = timings;
        for (int i = 0; i < keys.Count; i++)
        {
            MoveUICanvas(keys[i]);
            yield return new WaitForSeconds(timings[i]);
        }
        GameObject.Find("Player").GetComponent<PlayerTrash>().isInteracting = false;
    }

    public void PlayQTEStart(List<int> keys, List<int> timings) // Permet de lancer la coroutine, parce que ça ne voulait pas marcher depuis un fichier externe
    {
        StartCoroutine(PlayQTE(keys, timings));
    }



}
