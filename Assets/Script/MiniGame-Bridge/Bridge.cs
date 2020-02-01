using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Bridge : MonoBehaviour
{

    [SerializeField] private Image progressBar;
    [SerializeField] private GameObject playerInventory;
    [SerializeField] private GameObject bridge;
    [SerializeField] private GameObject particules;

    [SerializeField] private float time;
    [SerializeField] private const float timeStamp = .25f;

    [SerializeField] private const short _nbRepairMax = 3;  // Nombre de réparation à effectuer
    [SerializeField] private short _nbRepair;               // Nombre de réparations encore nécessaire
    [SerializeField] private bool _state;                   // Etat du pont (false = détruit, true = reconstruit)
    [SerializeField] private bool isPlayerPresent;

    private const float MAX_FILLED_BAR = 1.0f, MIN_FILLED_BAR = 0.0f, RADIUS = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        _nbRepair = _nbRepairMax;
        _state = false;
        isPlayerPresent = false;
        particules.SetActive(false);
        particules.GetComponent<ParticleSystem>().playbackSpeed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - time > timeStamp)
        {
            particules.SetActive(false);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(!_state)
            {
                foreach (Transform child in playerInventory.transform)
                {
                    if (child.tag == "BridgePart")
                    {
                        progressBar.enabled = true;

                        // On appuis sur E tant que la barre de progression n'est pas fini
                        if(progressBar.fillAmount < MAX_FILLED_BAR && Input.GetKeyDown(KeyCode.E))
                        {
                            Debug.Log("YO");
                            progressBar.fillAmount += 0.25f; // On remplie la barre au fur et à mesure
                            time = Time.time;
                            particules.SetActive(true);
                        }



                        // Dés que la barre est full
                        if(progressBar.fillAmount >= MAX_FILLED_BAR)
                        {
                            _nbRepair--;
                            child.GetComponent<BridgeParts>().DestroyPart(); // on détruit le morceau de pont
                            progressBar.enabled = false; // on enlève la barre de progression
                            progressBar.fillAmount = MIN_FILLED_BAR; // on la rempli au minimum
                        }
                        
                        // Le pont est réparé, on peut passer
                        if (_nbRepair == 0)
                        {
                            _state = true;
                            bridge.GetComponent<BoxCollider2D>().enabled = false;
                        }
                    }
                }
            }
        }
    }

/*
    private void DetectPlayer()
    {
        RaycastHit2D[] around = Physics2D.CircleCastAll(transform.position, RADIUS, Vector3.up);
        bool detect = false;
        foreach (RaycastHit2D hit in around)
        {
            if (hit.transform.tag == "Player")
            {
                detect = true;
            }
        }
        isPlayerPresent = detect;
    }*/

    public void OnTriggerExit2D(Collider2D collision)
    {
        // si le joueur s'en va, on rénitialise la barre de progression
        if(collision.tag == "Player")
        {
            progressBar.enabled = false;
            progressBar.fillAmount = MIN_FILLED_BAR;
        }
    }

    public short nbRepair
    {
        get { return _nbRepair; }
    }

    public bool state
    {
        get { return _state; }
    }
}
