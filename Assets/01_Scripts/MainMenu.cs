using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScenePong"); // Aseg�rate de que la escena del juego se llame "GameScene"

    }
    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu"); // Aseg�rate de que la escena del juego se llame "GameScene"

    }

}

