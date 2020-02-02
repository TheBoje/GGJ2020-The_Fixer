using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Scene_2Holder : MonoBehaviour
{

    [SerializeField] private DialoguePlayer dP;

    [SerializeField] private GameObject birdhouse;

    [SerializeField] private CinemachineDollyCart dolly;

    [SerializeField] private CinemachineSmoothPath chemin1;

    [SerializeField] private PlayerMovement player;
    [SerializeField] private float minRay = 1.5f;

    private int _state;

    private IEnumerator WaitTime(float time, int nextState)
    {
        yield return new WaitForSeconds(time);
        _state = nextState;
    }

    private float PathDistance(CinemachineSmoothPath cSP)
    {
        float distance = 0;
        for (int i = 1; i < cSP.m_Waypoints.Length; i++)
        {
            distance = Vector3.Distance(cSP.m_Waypoints[i - 1].position, cSP.m_Waypoints[i].position);
        }

        return distance;
    }

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
                dolly.m_Path = chemin1;

                player.folowTransform = dolly.transform;
                player.folowAPoint = true;
                dolly.m_Speed = player.speed;

                StartCoroutine(WaitTime(PathDistance(chemin1) / dolly.m_Speed + 6, 1));
                break;
            case 1 :
                player.folowTransform = null;
                player.folowAPoint = false;
                _state = 2;
                break;
            case 2:
                dP.Read(0);
                _state = 3;
                break;
            case 3:
                if (!dP.reading)
                {
                    player.canMove = true;
                    _state = 4;

                }
                break;
            case 4:
                if (birdhouse.GetComponent<TetrisLike>().state)
                {
                    _state = 3;
                }
                break;
            case 5:
                dP.Read(7);
                _state = 5;
                break;
            case 6:
                if (!dP.reading)
                    _state = 6;
                break;


            default:
                break;
        }
    }
}
