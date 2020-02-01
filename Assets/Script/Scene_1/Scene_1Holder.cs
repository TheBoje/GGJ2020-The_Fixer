using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Scene_1Holder : MonoBehaviour
{
    [SerializeField] private DialoguePlayer dP;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private float minRay = 1.5f;
    [SerializeField] private SpriteRenderer cache1;
    [SerializeField] private SpriteRenderer cache2;


    [SerializeField] private Vector3 spacePointState1;

    [SerializeField] private CinemachineSmoothPath chemin1;
    [SerializeField] private CinemachineSmoothPath chemin2;

    [SerializeField] private CinemachineDollyCart dolly;

    [SerializeField] private Bridge vase;

    [SerializeField] private Transform generalLight;
    [SerializeField] private Transform playerLight;
    [SerializeField] private Lever bathroomCollider;

    public int state;

    private IEnumerator WaitTime(float time,int nextState)
    {
        yield return new WaitForSeconds(time);
        state = nextState;
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

    private void Update()
    {
        switch (state)
        {
            case 0:
                StartCoroutine(WaitTime(1.0f,1));
                Color tmp = cache1.color;
                tmp.a = Mathf.Lerp(tmp.a, 0, 0.1f);
                cache1.color = tmp;
                break;
            case 1:
                dolly.m_Path = chemin1;

                player.folowTransform = dolly.transform;
                player.folowAPoint = true;
                dolly.m_Speed = player.speed;
                
                StartCoroutine(WaitTime(PathDistance(chemin1)/dolly.m_Speed + 1,2));

                break;
            case 2:
                player.folowTransform = null;
                player.folowAPoint = false;
                state = 3;
                break;
            case 3:
                dP.Read(0);
                state = 4;
                break;
            case 4:
                if (!dP.reading)
                {
                    state = 5;
                }
                break;
            case 5:
                player.canMove = true;
                state = 6;
                break;
            case 6:
                if(vase.nbRepair < vase.nbRepairMax)
                {
                    dP.Read(1);
                    state = 7;
                }
                break;
            case 7:
                if (vase.state)
                {
                    state = 9;
                }
                break;
            case 8:
                dP.Read(2);
                state = 9;
                break;
            case 9:
                if (!dP.reading)
                {
                    state = 10;
                }
                break;
            case 10:
                player.canMove = false;
                dolly.m_Path = chemin2;

                player.folowTransform = dolly.transform;
                player.folowAPoint = true;

                dolly.m_Speed = player.speed;
                StartCoroutine(WaitTime(PathDistance(chemin2) / dolly.m_Speed + 1, 11));
                break;
            case 11:
                player.folowTransform = null;
                player.folowAPoint = false;
                dP.Read(2);
                state = 12;
                break;
            case 12:
                if (!dP.reading)
                {
                    state = 13;
                }
                break;
            case 13:
                generalLight.GetComponent<Light>().intensity = 0.5f;
                StartCoroutine(WaitTime(1f, 14));
                break;
            case 14:
                playerLight.gameObject.SetActive(true);
                state = 15;
                break;
            case 15:
                dP.Read(5);
                break;


            default:
                break;
        }
        
    }

    
}
