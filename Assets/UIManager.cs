using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    public static UIManager instance;

    public bool isGamePause = true;
    // Start is called before the first frame update
    void Start()
    {
        ShowPauseMenu(true);
        Time.timeScale = 0;
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
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
        }
        else
        {
            Time.timeScale = 1;
            ShowPauseMenu(false);
        }
    }

    void ShowPauseMenu(bool isActive)
    {
        pausePanel.SetActive(isActive);
    }

    //private void Exit()
    //{

    //}

}
