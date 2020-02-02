using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_2Holder : MonoBehaviour
{

    [SerializeField] private DialoguePlayer dP;

    private int _state;

    // Start is called before the first frame update
    void Start()
    {
        _state = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case 0 :
                dP.Read(0);



            default:
                break;
        }
    }
}
