using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
public void ReturnToMenu() //Return to the main menu on button click
    {
        SceneManager.LoadScene("Menu");
    }

}
