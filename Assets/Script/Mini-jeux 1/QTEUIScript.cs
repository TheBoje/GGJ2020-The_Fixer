using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEUIScript : MonoBehaviour
{
    [SerializeField] private Text Default_Num1;
    [SerializeField] private Text Default_Num2;
    [SerializeField] private Text Default_Num3;
    [SerializeField] private int sum_succes = 0;
    [SerializeField] private Image UICanvas;
    private KeyCode key1 = KeyCode.Keypad1;
    private KeyCode key2 = KeyCode.Keypad2;
    private KeyCode key3 = KeyCode.Keypad3;
    [SerializeField] private AudioSource LooseAudio;
    [SerializeField] private AudioSource WinAudio;
    [SerializeField] private GameObject focusItem;
    [SerializeField] private GameObject particuleGreen;
    [SerializeField] private GameObject particuleRed;
    [SerializeField] private GameObject particuleYellow;

    private void Start()
    {
        Default_Num1.color = new Color(1, 1, 1, 0);
        Default_Num2.color = new Color(1, 1, 1, 0);
        Default_Num3.color = new Color(1, 1, 1, 0);
    }

    public void MoveUICanvas_aux(Text image, KeyCode key1, KeyCode key2, KeyCode key3)
    {
        StartCoroutine(FadeImage(false, image, key1, key2, key3));
    }

    public void MoveUICanvas(int id) // Trop dur a faire bouger, on va verifier les touches qui fade
    {
        switch (id)
        {
            case 1:
                MoveUICanvas_aux(Default_Num1, key1, key2, key3);
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

    IEnumerator FadeImage(bool fadeAway, Text img, KeyCode key1, KeyCode key2, KeyCode key3) // fadeAway = true -> FadeOut, fadeAway = false -> FadeIn
    {
        float time = Time.deltaTime / 2;

        if (fadeAway)
        {
            for (float i = 1; i >= 0; i -= time)
            {
                if (Input.GetKey(key1))
                {
                    img.color = new Color(1, 1, 1, 0);
                    GoodButton(img);
                    SoundButton(img);
                    sum_succes += 1;
                    break;
                }
                else if (Input.GetKey(key2) || Input.GetKey(key3))
                {
                    img.color = new Color(1, 1, 1, 0);
                    sum_succes = -1;
                    Badbutton(img);
                    break;
                }
                else if (i < 0.05f)
                {
                    sum_succes = -1;
                    img.color = new Color(1, 1, 1, 0);
                    Overtime(img);
                    break;
                }
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        else
        {
            for (float i = 0; i <= 1; i += time)
            {
                if (Input.GetKey(key1))
                {
                    img.color = new Color(1, 1, 1, 0);
                    sum_succes += 1;
                    GoodButton(img);
                    SoundButton(img);
                    break;
                }
                else if (Input.GetKey(key2) || Input.GetKey(key3))
                {
                    sum_succes = -1;
                    img.color = new Color(1, 1, 1, 0);
                    Badbutton(img);
                    break; 
                }
                img.color = new Color(1, 1, 1, i);
                if (i > 0.95f)
                {
                    StartCoroutine(FadeImage(true, img, key1, key2, key3));
                    break;
                }
                yield return null;
            }
        }
    }

    IEnumerator PlayQTE(List<int> keys, List<int> timings)  // Coroutine main, Distribue les valeurs dans le switch
    {
        //UICanvas.color = new Color(UICanvas.color.r, UICanvas.color.g, UICanvas.color.b, 255f);
        for (int i = 0; i < keys.Count; i++)
        {
            if (sum_succes != -1)
            {
                MoveUICanvas(keys[i]);
                yield return new WaitForSeconds((float)timings[i]);
            }
            else
            {
                break;
            }
        }
        if (sum_succes == -1)
        {
            QTEFail(focusItem);
        }
        else
        {
            QTEWin(focusItem);
            Destroy(focusItem);
        }
        GameObject.Find("Player").GetComponent<PlayerTrash>().isInteracting = false;
        GameObject.Find("Player").GetComponent<PlayerMovement>().canMove = true;
    }

    public void PlayQTEStart(List<int> keys, List<int> timings, GameObject GO) // Permet de lancer la coroutine, parce que ça ne voulait pas marcher depuis un fichier externe
    {
        focusItem = GO;
        StartCoroutine(PlayQTE(keys, timings));
    }

    private void QTEFail(GameObject GO)
    {
        LooseAudio.Play();
        //UICanvas.color = new Color(UICanvas.color.r, UICanvas.color.g, UICanvas.color.b, 0f);
        sum_succes = 0;
    }
     private void QTEWin(GameObject GO)
    {
        WinAudio.Play();
        //UICanvas.color = new Color(UICanvas.color.r, UICanvas.color.g, UICanvas.color.b, 0f);
        sum_succes = 0;
    }

    private void SoundButton(Text img)
    {
        img.GetComponent<AudioSource>().Play();
    }
    private void Overtime(Text img)
    {
        Vector3 temp = img.GetComponent<RectTransform>().transform.position;
        particuleYellow.transform.position = temp + new Vector3(0f, 0f, -5f);
        particuleYellow.GetComponent<ParticleSystem>().Play();
        Debug.Log("Overtime");
    }

    private void GoodButton(Text img)
    {
        Vector3 temp = img.GetComponent<RectTransform>().transform.position;
        particuleGreen.transform.position = temp + new Vector3(0f, 0f, -5f);
        particuleGreen.GetComponent<ParticleSystem>().Play();
    }

    private void Badbutton(Text img)
    {
        Vector3 temp = img.GetComponent<RectTransform>().transform.position;
        particuleRed.transform.position = temp + new Vector3(0f, 0f, -5f);
        particuleRed.GetComponent<ParticleSystem>().Play();
        Debug.Log("Bad bouton");
    }
}
