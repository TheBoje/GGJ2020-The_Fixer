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
                break;
            case 1 :
                dP.Read(1);
                break;
            case 2 :
                dP.Read(2);
                break;
            case 3 :
                dP.Read(3);
                break;
            case 4 :
                dP.Read(4);
                break;
            case 5 :
                dP.Read(5);
                break;
            case 6 :
                dP.Read(6);
                break;
            case 7 :
                dP.Read(7);
                break;


            default:
                break;
        }
    }
}
