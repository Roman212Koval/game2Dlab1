using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; //Работа с интерфейсами
using UnityEngine.SceneManagement; //Работа со сценами
using UnityEngine.Audio; //Работа с аудио
using UnityEngine;

public class Menu : MonoBehaviour
{
    public int level = 1;
    public AudioSource audioClick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            //ShowHideMenu();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Вихід з гри");
    }

    public void StartGame()
    {
        switch (level)
        {
            case 1:                
                SceneManager.LoadScene("SampleScene");
                break;

            case 2:                
                SceneManager.LoadScene("SampleScene2");
                break;

            case 3:
                SceneManager.LoadScene("SampleScene3");
                break;
        }
        ResumeGame();
    }

    public void LevelUp(int lev)
    {
        level = lev + 1;
        StartGame();
    }

    public void ShowHideMenu()
    {
       
        SceneManager.LoadScene("Menu");
        //GetComponent<MainMenu>().enabled = isOpened; //Включение или отключение Canvas. Ещё тут можно использовать метод SetActive()
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void audioClickM()
    {
        audioClick.Play();
    }
}
