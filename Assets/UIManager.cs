using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameInfo;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text secondText;
    public static UIManager instance;
    private int counter;
    public bool isGamePause = true;
    private int secondCounter;
    public int SecondCounter{
        get => secondCounter;
        set
        {
            secondCounter = value;
            UpdateSecondUI(secondCounter);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
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
            Exit(); 
        }

        SecondCounter += (int)Time.deltaTime;

    }

    public void Pause()
    {
        if (isGamePause)
        {
            Time.timeScale = 0;
            if(GameManager.instance.PlayerLives <=0){
                ShowGameOverScene();
                // StartCoroutine(ResetLevel());
            }else{
                ShowPauseMenu(true);
                if (counter > 0)
                {
                    ShowGameInfo(true);
                }
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

    public void UpdateHealtUI(int value){
        livesText.text = value.ToString();
    }

    public void UpdateSecondUI(int value)
    {
        secondText.text = value.ToString();
    }

    public void ShowGameOverScene(){
        SceneManager.LoadScene("GameOverScene");
    }

    private void Exit()
    {
        Application.Quit();
    }

}
