using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DonDesLoad : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        GameObject[] g = GameObject.FindGameObjectsWithTag("BGM");
        if (SceneManager.GetActiveScene().buildIndex == 1 || g.Length > 1)
        {
            Destroy(this.gameObject);
        }
        
    }
}
