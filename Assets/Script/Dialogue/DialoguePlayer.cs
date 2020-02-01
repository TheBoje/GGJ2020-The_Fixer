using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePlayer : MonoBehaviour
{
    [SerializeField]private List<Dialogue> dialogues;

    [SerializeField]private bool screenUI;

    [SerializeField] private Transform uiTranform;
    [SerializeField] private Transform buttonTranform;

    [SerializeField] private Text textTransform;
    [SerializeField] private Text textOption1;
    [SerializeField] private Text textOption2;

    private bool playing;
    public bool reading;
    private bool option1;
    private bool option2;


    /**
     * @brief Fonction qui sera appelé par les boutons de l'interface afin de choisir l'option1 ou 2 dans des dialogue à choix multiple
     * @param option: vaut "option1" ou "option2"
     */
    public void GetButtonInput(string option)
    {
        option1 = option == "option1";
        option2 = option == "option2";
    }

    private void Start()
    {
        buttonTranform.gameObject.SetActive(false);
    }
    /**
     * @brief la fonction qui va être appelé quadn on veux jouer un dialogue dans une scene
     * @param indice : définie quel dialogue de dialogues on lance
     */
    public void Read(int indice)
    {
        if (reading)
            return;
        Debug.Log("Start Reading...");
        screenUI = true;
        reading = true;
        StartCoroutine(DialogueAnim(indice));

    }

    /**
     * @brief Routine qui anime le text toute les content.speed secondes. Prend en compte le rich text
     * @param le dialogue à lire
     */
    private IEnumerator TextAnim(Dialogue content)
    {
        playing = true;
        textTransform.text = "";
        string text = content.text;
        float speedText = content.speed;
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '<' && text[i + 1] != ' ')
            {
                for (; text[i] != '>'; i++)
                    textTransform.text += text[i];
                textTransform.text += '>';
            }
            else
            {
                textTransform.text += text[i];
            }

            if (Input.GetButton("Fire1"))
            {
                yield return new WaitForSeconds(0f);
            }
            else
            {
                yield return new WaitForSeconds(speedText);
            }
        }
        playing = false;
    }

    /**
     * @brief Routine qui parcours le dialogue jusqu'à la fin
     * @param indice définie quel dialogue de dialogues on lance
     */
    private IEnumerator DialogueAnim(int indice)
    {
        //Waitunitl permet d'attendre le temps qu'une condition soit validée. Ici que la boite de dialogue soit active afin d'éviter les erreurs
        yield return new WaitUntil(() => (uiTranform.gameObject.activeInHierarchy));

        Dialogue dialogue = dialogues[indice];
        while(dialogue != null)
        {
            StartCoroutine(TextAnim(dialogue));
            if (dialogue.choose)
            {
                //Si c'est un dialogue à choix on active les bouton de l'interface, on le nomme comme il faut et on attend l'appui d'un des boutons
                textOption1.text = dialogue.textChoix1;
                textOption2.text = dialogue.textChoix2;
                buttonTranform.gameObject.SetActive(true);
                //option1 et option2 ne sont modifié que par les button et l'appel de la fonction GetButtonInput
                yield return new WaitUntil(() => (!playing) && (option1 || option2));
                if (option1)
                {
                    dialogue = dialogue.nextOption_1;
                    option1 = false;
                }
                else if (option2)
                {
                    dialogue = dialogue.nextOption_2;
                    option2 = false;

                }
                buttonTranform.gameObject.SetActive(false);

            }
            else
            {
                yield return new WaitUntil(() => (!playing) && (Input.GetButtonDown("Fire1")));
                dialogue = dialogue.nextOption_1;
            }

        }
        screenUI = false;
        reading = false;
    }

    private void OnGUI()
    {
        uiTranform.gameObject.SetActive(screenUI);
    }

}
