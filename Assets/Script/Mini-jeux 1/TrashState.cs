using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashState : MonoBehaviour
{
    int state = 3; //States number initialized to 3
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterTheTrash(GameObject gameObject)
    {
        //If state is 0 then destroy the object
        if (state == 0)
        {
            Destroy(gameObject);
        }
        //else state is descrement
        else state--;
    }
}
