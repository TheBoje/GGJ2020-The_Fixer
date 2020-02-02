using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

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
    [SerializeField] private CinemachineSmoothPath chemin3;
    [SerializeField] private CinemachineSmoothPath chemin4;

    [SerializeField] private CinemachineDollyCart dolly;

    [SerializeField] private Bridge vase;

    [SerializeField] private Transform generalLight;
    [SerializeField] private Transform playerLight;

    [SerializeField] private Lever bathroomCollider;


    [SerializeField] private Lever elecSwitch;
    [SerializeField] private SpamPoint chaudiere;


    [SerializeField] private Transform BGMTransform;



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

    private void Start()
    {
        elecSwitch.enabled = false;
        chaudiere.enabled = false;
        bathroomCollider.enabled = false;
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
                GetComponent<AudioSource>().Play();
                generalLight.GetComponent<Light>().intensity = 0.25f;
                bathroomCollider.enabled = false;
                BGMTransform.gameObject.SetActive(false);
                StartCoroutine(WaitTime(1f, 14));
                break;
            case 14:
                playerLight.gameObject.SetActive(true);
                state = 15;
                break;
            case 15:
                dP.Read(5);
                state = 16;
                break;
            case 16:
                if (!dP.reading)
                {
                    state = 17;
                }
                break;
            case 17:
                player.canMove = true;
                if (bathroomCollider.state)
                {
                    state = 18;
                }
                break;
            case 18:
                Destroy(bathroomCollider.transform.parent.gameObject);
                Destroy(cache2.gameObject);
                elecSwitch.enabled = true;
                state = 19;
                break;
            case 19:
                if (elecSwitch.state)
                {
                    state = 20;
                }
                break;
            case 20:
                playerLight.gameObject.SetActive(false);
                generalLight.GetComponent<Light>().intensity = 1.25f;
                BGMTransform.gameObject.SetActive(true);
                player.canMove = false;
                dP.Read(6);
                state = 21;
                break;
            case 21:
                if (!dP.reading)
                {
                    state = 22;
                }
                break;
            case 22:
                player.canMove = true;
                chaudiere.enabled = true;
                state = 23;
                break;
            case 23:
                if (chaudiere.state)
                {
                    state = 24;
                }
                break;
            case 24:

                player.canMove = false;
                dolly.m_Path = chemin3;

                player.folowTransform = dolly.transform;
                player.folowAPoint = true;

                dolly.m_Speed = player.speed;
                StartCoroutine(WaitTime(PathDistance(chemin3) / dolly.m_Speed + 4, 25));
                break;
            case 25:
                player.folowTransform = null;
                player.folowAPoint = false;
                dP.Read(7);
                state = 26;
                break;
            case 26:
                if (!dP.reading)
                {
                    state = 27;
                }
                break;
            case 27:
                player.canMove = false;
                dolly.m_Path = chemin4;

                player.folowTransform = dolly.transform;
                player.folowAPoint = true;

                dolly.m_Speed = player.speed;
                StartCoroutine(WaitTime(PathDistance(chemin4) / dolly.m_Speed + 1, 28));
                break;
            case 28:
                //LOad level
                SceneManager.LoadScene(4);
                break;
            default:
                break;
        }
        
    }

    
}
