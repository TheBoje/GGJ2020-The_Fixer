using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Transform bgm;
    // Start is called before the first frame update
    public void PlayGame() // Launch the fisrt level
    {
        Destroy(bgm.gameObject);
        Debug.Log("Destroy BGM");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Credits() //Open the credits
    {
        SceneManager.LoadScene("Credits");
    }

    public void Options() //Open the Options menu
    {
        SceneManager.LoadScene("Options");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
