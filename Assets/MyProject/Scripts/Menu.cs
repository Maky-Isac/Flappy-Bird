using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    [SerializeField] private string sceneGame;
    public void Play()
    {
        SceneManager.LoadScene(sceneGame);
        Debug.Log("Vem para Play");
    }
}
