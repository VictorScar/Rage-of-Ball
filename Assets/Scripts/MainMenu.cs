using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject recordMenu;
    public GameObject mainMenu;
    public GameObject namePanel;
    private string messange;
    public Text gameMessange;
    private static string[] recordes = new string [5];
    private static int countString =0;
    public static bool isNamed = false;
    private string enterName;
    public static string playerName;
    public Text record1;
    public Text record2;
    public Text record3;
    public Text record4;
    public Text record5;
    public Text textPlayer;
    public Text inputText;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        textPlayer.text = playerName;



        if (State.state == State.GameState.victory)
        {

            messange = "Вы выиграли!";
            mainMenu.SetActive(false);
            recordMenu.SetActive(true);
            gameMessange.text = messange;
            gameMessange.color = Color.green;
            if (countString > 4)
            {
                countString = 0;
            }

            recordes[countString] = State.totalTime;
            countString++;
           
           
        }
        else if (State.state == State.GameState.defeat)
        {
            messange = "Вы проиграли!";
            mainMenu.SetActive(false);
            recordMenu.SetActive(true);
            gameMessange.text = messange;
            gameMessange.color = Color.red;
        }
        else
        {
            messange = "";
            gameMessange.text = messange;
        }
        record1.text = recordes[0];
        record2.text = recordes[1];
        record3.text = recordes[2];
        record4.text = recordes[3];
        record5.text = recordes[4];
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            recordMenu.SetActive(false);
            mainMenu.SetActive(true);
           
        }
        if (!isNamed)
        {
            Registration();
        }

        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        State.state = State.GameState.none;
    }

    public void OpenRecordes()
    {
        recordMenu.SetActive(true);
       
    }

   private void Registration()
    {
        namePanel.SetActive(true);
        enterName = inputText.text;
        if (Input.GetKey(KeyCode.Return))
        {
            playerName = inputText.text;
            isNamed = true;
            namePanel.SetActive(false);
            textPlayer.text = playerName;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
   
}
