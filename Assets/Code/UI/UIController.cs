using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        UIEventDispatcher.Instance.ButtonStartPress();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
