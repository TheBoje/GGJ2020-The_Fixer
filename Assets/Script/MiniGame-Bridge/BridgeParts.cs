using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeParts : MonoBehaviour
{

    public GameObject player;
    [SerializeField] GameObject playerInventory;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("YO");

        if (collision.tag == "Player")
        {

            bool isFull = false;

            foreach (Transform item in playerInventory.transform)
                isFull = true;
            if(!isFull)
            {
                //transform.position = player.transform.position; // l'objet vient se mettre sur le personnage
                this.GetComponent<SpriteRenderer>().enabled = false; // On désactive son rendu
                this.GetComponent<BoxCollider2D>().enabled = false; // On désactive son collider
                this.transform.parent = playerInventory.transform; // On l'envois en tant que fils de inventory
            }
        }
    }

    public void DestroyPart()
    {
        Destroy(gameObject);
    }
}
