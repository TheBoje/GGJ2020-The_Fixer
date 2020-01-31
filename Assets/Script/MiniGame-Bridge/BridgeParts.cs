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
        Debug.Log("YO");

        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            //transform.position = player.transform.position;
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.transform.parent = playerInventory.transform;
        }
    }

    public void DestroyPart()
    {
        Destroy(gameObject);
    }
}
