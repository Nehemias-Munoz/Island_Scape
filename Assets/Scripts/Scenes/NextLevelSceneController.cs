
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevelSceneController : MonoBehaviour
{
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text levelText;

    private void Start()
    {
        livesText.text = GameManager.instance.PlayerLives.ToString();
        levelText.text = GameManager.instance.Level.ToString();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("GamePlayScene");
        }

        if(Input.GetKeyDown(KeyCode.E)){
            Application.Quit();
        }
        
    }
    
}
