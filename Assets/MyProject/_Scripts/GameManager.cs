using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    [SerializeField] private string scene;

    public void GameOver() // pausa o jogo
    {
        Time.timeScale = 0f;  
        gameOverPanel.SetActive(true);
    }

    public void RetryGame()  //Volta do zero na gamepay
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void GoToMenu()  // nome da sua cena de menu
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);   
    }
}
