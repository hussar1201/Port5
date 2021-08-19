using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text[] arr_UI_Text;
    private int score;
    public GameObject Menu_GameOver;
    public GameObject[] Menu_Option;
    public bool flag_menu_opened
    {
        get;
        private set;
    }


    private static UIManager m_instance;
    public static UIManager instance
    {
        get
        {
            if (m_instance == null) m_instance = FindObjectOfType<UIManager>();

            return m_instance;
        }
        private set { }
    }

    private void Awake()
    {
        if (instance != this) Destroy(this);
        score = 0;
        flag_menu_opened = false;

    }


    public void UploadScore(int add)
    {
        score += add;
        arr_UI_Text[0].text = "Score: " + score;
    }

    public void ChangePlayerHP(int hp)
    {

        arr_UI_Text[1].text = "HP: " + hp;
    }


    public void SelectMenu()
    {

        flag_menu_opened = !flag_menu_opened;

        foreach (GameObject tmp in Menu_Option)
        {
            tmp.gameObject.SetActive(flag_menu_opened);
            tmp.gameObject.SetActive(flag_menu_opened);
        }

    }

    public void ActiveGameOverMenu()
    {
        Menu_GameOver.gameObject.SetActive(true);
    }




}
