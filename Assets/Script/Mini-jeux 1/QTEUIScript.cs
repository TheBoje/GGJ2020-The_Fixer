using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEUIScript : MonoBehaviour
{
    [SerializeField] private Text Default_Num1;         // Ensemble des Text de l'UI ("1", "2" et "3")
    [SerializeField] private Text Default_Num2;
    [SerializeField] private Text Default_Num3;
    [SerializeField] private int sum_succes = 0;        // int de vérification de la boucle de jeu, si = -1, break de la boucle
    private KeyCode key1 = KeyCode.Keypad1;             // Inputs pour le QTE, à modifier éventuellement par Fire[1..3]
    private KeyCode key2 = KeyCode.Keypad2;
    private KeyCode key3 = KeyCode.Keypad3;
    [SerializeField] private AudioSource LooseAudio;    // Sources audio
    [SerializeField] private AudioSource WinAudio;
    [SerializeField] private GameObject focusItem;      // Item trash qui est à l'origine de l'intéraction
    [SerializeField] private GameObject particuleGreen; // Particules systemes pour les 3 cas (green = réussite, red = misstype, yellow = timeout)
    [SerializeField] private GameObject particuleRed;
    [SerializeField] private GameObject particuleYellow;

    private void Start()
    {
        Default_Num1.color = new Color(1, 1, 1, 0); // Rend transparent les numéros à l'initialisation du Script
        Default_Num2.color = new Color(1, 1, 1, 0);
        Default_Num3.color = new Color(1, 1, 1, 0);
    }

    public void PlayQTEStart(List<int> keys, List<int> timings, GameObject GO) // Fonction appelée par GameScriptMG1 pour lancer le QTE
    {
        focusItem = GO;                         // On associe le trash avec lequel on est en interaction
        StartCoroutine(PlayQTE(keys, timings)); // On lance la main fonction du QTE
    }
    IEnumerator PlayQTE(List<int> keys, List<int> timings)  // Coroutine main, Entrée : liste des valeurs et liste des temps entre chaque valeurs.
    {                                                       // On utilise une Coroutine pour pouvoir Wait() sans bloquer tout le jeu
        for (int i = 0; i < keys.Count; i++)                // Pour chaque élément de la liste des valeurs, on appelle MoveUICanvas() et on attend timings[i] secs. On vérifie que "sum_succes != -1", condition de sortie prématurée
        {
            if (sum_succes != -1)   // Condition de sortie prématurée / défaite
            {
                MoveUICanvas(keys[i]);
                yield return new WaitForSeconds((float)timings[i]);
            }
            else
            {
                break; // Break de la boucle FOR si la cond sum_succes != -1 n'est plus vérifiée.
            }
        }   // On détermine dans quel cas de sortie on est : réussite ou echec du QTE
        if (sum_succes == -1)
        {
            QTEFail(focusItem); 
        }
        else
        {
            QTEWin(focusItem);
            Destroy(focusItem);
        }
        GameObject.Find("Player").GetComponent<PlayerTrash>().isInteracting = false;    // Fin de la main boucle, on réautorise le joueur à intéragir et à se déplacer (cf PlayerTrash.cs et PlayerMovement.cs)
        GameObject.Find("Player").GetComponent<PlayerMovement>().canMove = true;
    }
    public void MoveUICanvas(int id) // On convertit la valeur de la liste keys en keycode
    {
        switch (id) 
        {
            case 1:
                MoveUICanvas_aux(Default_Num1, key1, key2, key3); // def MoveUICanvas_aux(Text, Key d'activation, Autres keys), On veut fait apparaitre / disparaitre le text, et listen les inputs sur les keycodes listés
                break;
            case 2:
                MoveUICanvas_aux(Default_Num2, key2, key1, key3);
                break;
            case 3:
                MoveUICanvas_aux(Default_Num3, key3, key1, key2);
                break;
            default:
                Debug.LogError("Erreur instanciation MoveUICanvas() from QTEUIScript, id unknown");
                break;
        }
    }
    public void MoveUICanvas_aux(Text image, KeyCode key1, KeyCode key2, KeyCode key3)
    {
        StartCoroutine(FadeImage(false, image, key1, key2, key3)); // Appelle la Coroutine de FadeIn / FadeOut du text et vérification des inputs
    }
    IEnumerator FadeImage(bool fadeAway, Text txt, KeyCode key1, KeyCode key2, KeyCode key3) // fadeAway = true -> FadeOut, fadeAway = false -> FadeIn
    {
        float time = Time.deltaTime / 2; // Permet de controler la vitesse de Fade (In et Out)

        if (fadeAway) // FadeOut
        {
            for (float i = 1; i >= 0; i -= time) // Décrémentation de l'alpha du txt
            {
                if (Input.GetKey(key1)) // Si on press la Key1, alors on cache le txt, on lance les particules green et on mets le petit sound gentil, puis on sort de la boucle FOR
                {
                    txt.color = new Color(1, 1, 1, 0);
                    GoodButton(txt);
                    SoundButton(txt);
                    break;
                }
                else if (Input.GetKey(key2) || Input.GetKey(key3)) // Vérification de mauvais input, alors on cache le txt, on -1 sum_succes, et on lance les particules red
                {
                    txt.color = new Color(1, 1, 1, 0);
                    sum_succes = -1;
                    Badbutton(txt);
                    break;
                }
                else if (i < 0.05f) // Fade away, donc -1 sum_succes, cache le txt et lance les particules yellow
                {
                    sum_succes = -1;
                    txt.color = new Color(1, 1, 1, 0);
                    Overtime(txt);
                    break;
                }
                txt.color = new Color(1, 1, 1, i); // Application du FadeOut au txt
                yield return null;
            }
        }
        else    // FadeIn
        {
            for (float i = 0; i <= 1; i += time) // Identique à la boucle de FadeOut
            {
                if (Input.GetKey(key1))
                {
                    txt.color = new Color(1, 1, 1, 0);
                    GoodButton(txt);
                    SoundButton(txt);
                    break;
                }
                else if (Input.GetKey(key2) || Input.GetKey(key3))
                {
                    sum_succes = -1;
                    txt.color = new Color(1, 1, 1, 0);
                    Badbutton(txt);
                    break; 
                }
                txt.color = new Color(1, 1, 1, i);
                if (i > 0.95f) // Au lieu de finir quand le FadeIn a fini, on relance mais en FadeOut
                {
                    StartCoroutine(FadeImage(true, txt, key1, key2, key3));
                    break;
                }
                yield return null;
            }
        }
    }

    private void QTEFail(GameObject GO) // Lancement de l'audio + reset de sum_succes
    {
        LooseAudio.Play(); 
        sum_succes = 0;
    }
    private void QTEWin(GameObject GO) // Lancement de l'audio + reset de sum_succe
    {
        WinAudio.Play();
        sum_succes = 0;
    }
    private void SoundButton(Text txt) // Lance l'audio du txt
    {
        txt.GetComponent<AudioSource>().Play();
    }
    private void Overtime(Text txt)
    {
        Vector3 temp = txt.GetComponent<RectTransform>().transform.position;    // récupère la position du txt 
        particuleYellow.transform.position = temp + new Vector3(0f, 0f, -5f);   // positionne les particules sur le txt + offset pour ne pas être derriere 
        particuleYellow.GetComponent<ParticleSystem>().Play();                  // Lance les particules
    }
    private void GoodButton(Text txt) // Voir Overtime() 
    {
        Vector3 temp = txt.GetComponent<RectTransform>().transform.position;
        particuleGreen.transform.position = temp + new Vector3(0f, 0f, -5f);
        particuleGreen.GetComponent<ParticleSystem>().Play();
    }
    private void Badbutton(Text txt) // Voir Overtime()
    {
        Vector3 temp = txt.GetComponent<RectTransform>().transform.position;
        particuleRed.transform.position = temp + new Vector3(0f, 0f, -5f);
        particuleRed.GetComponent<ParticleSystem>().Play();
        Debug.Log("Bad bouton");
    }
}
