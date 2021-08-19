using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pos_Camera;
    private static GameManager m_instance;
    public bool flag_gameover
    {
        get;
        private set;
    }

    public static GameManager instance
    {
        get
        {
            if (m_instance == null) m_instance = FindObjectOfType<GameManager>();

            return m_instance;
        }
        private set { }
    }

    private void Awake()
    {
        if (instance != this) Destroy(this);
        flag_gameover = false;
    }

    public void GameOver()
    {
        flag_gameover = true;
        UIManager.instance.ActiveGameOverMenu();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
