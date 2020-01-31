using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashState : MonoBehaviour
{
    [SerializeField] public int state; //Variable etat
    // Start is called before the first frame update
    void Start()
    {
        state = 3; //Initialisation de l'etat a 3
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterTheTrash(GameObject gameObject)
    {
        //Si l'etat est a zero alors l'objet est detruit
        if (state == 0)
        {
            Destroy(gameObject);
        }
        //Sinon on decremente l'etat
        else state--;
    }
}
