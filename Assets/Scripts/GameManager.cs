using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject briffingPanel;
    private bool gameIsPause;
    //Основной скрипт для управления игровым процесом. Запускает игровой таймер, считывает значения статических переменных,
    //сообщающих о состоянии игры (достиг ли персонаж финиша или упал) и на основе их значений запускает соответствующий метод (победа, поражение)

    void Start()
    {
        Briffing();
        GetComponent<Timer>().timerActive=true;
        gameIsPause = false;
        State.state = State.GameState.none;
        //ContinuestGame();
       
    }
    private void Update()
    {
               
        if (State.finishing)
        {
            Victory();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
           Pause();
        }
        if (State.falling)
        {
            Defeate();
        }

    }

    
    public void Victory()
    {
       
        GetComponent<Timer>().timerActive = false;
        State.state = State.GameState.victory;
        State.totalTime = GetComponent<Timer>().time;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Pause()
    {
        gameIsPause = !gameIsPause;
        if (gameIsPause)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0.0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
          pausePanel.SetActive(false);
          ContinuestGame();

        }
    }

    public void Defeate()
    {
        GetComponent<Timer>().timerActive = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        State.state = State.GameState.defeat;
    }

    public void Briffing()
    {
        briffingPanel.SetActive(true);
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ContinuestGame ()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        Time.timeScale = 1.0f;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
