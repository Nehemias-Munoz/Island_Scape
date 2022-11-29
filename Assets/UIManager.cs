using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameInfo;
    public static UIManager instance;
    private int counter;

    public bool isGamePause = true;
    // Start is called before the first frame update
    void Start()
    {
        ShowPauseMenu(true);
        Time.timeScale = 0;
        counter = 0;
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            counter += 1;
            isGamePause = !isGamePause;
            Pause();
        }
        if(Input.GetKeyDown(KeyCode.E) && isGamePause)
        {
            print("Salir");
        }

    }

    public void Pause()
    {
        if (isGamePause)
        {
            Time.timeScale = 0;
            ShowPauseMenu(true);
            if (counter > 0)
            {
                ShowGameInfo(true);
            }
        }
        else
        {
            Time.timeScale = 1;
            ShowPauseMenu(false);
            ShowGameInfo(false);
        }
    }

    void ShowPauseMenu(bool isActive)
    {
        pausePanel.SetActive(isActive);
    }

    void ShowGameInfo(bool isActive){
        gameInfo.SetActive(isActive);
    }

    //private void Exit()
    //{

    //}

}
