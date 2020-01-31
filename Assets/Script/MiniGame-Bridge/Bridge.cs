using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{

    [SerializeField] private GameObject playerInventory;
    [SerializeField] private GameObject bridge;

    [SerializeField] private const short _nbRepairMax = 3;  // Nombre de réparation à effectuer
    [SerializeField] private short _nbRepair;               // Nombre de réparations encore nécessaire
    [SerializeField] private bool _state;                   // Etat du pont (false = détruit, true = reconstruit)

    // Start is called before the first frame update
    void Start()
    {
        _nbRepair = _nbRepairMax;
        _state = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            foreach (Transform child in playerInventory.transform)
            {
                if(child.tag == "BridgePart")
                {
                    _nbRepair--;
                    child.GetComponent<BridgeParts>().DestroyPart();

                    if (_nbRepair == 0)
                    {
                        _state = true;
                        bridge.GetComponent<BoxCollider2D>().enabled = false;
                    }
                }
            }
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
