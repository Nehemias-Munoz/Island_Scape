using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneController : MonoBehaviour
{
    [SerializeField] private TMP_Text secondText;
    private int secondCounter;
    private bool setActive;
    private int SecondCounter{
        get => secondCounter;
        set{
            secondCounter = value;
            UpdateSecondUI(secondCounter);
            if (secondCounter <= 0)
            {
                SceneManager.LoadScene("GameplayScene");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        setActive = true;
        gameObject.SetActive(setActive);
        SecondCounter = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (setActive)
        {
            StartCoroutine(ResetLevel());
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("GamePlayScene");
        }

        if(Input.GetKeyDown(KeyCode.E)){
            Application.Quit();
        }
        
    }
    private void UpdateSecondUI(int value){
        secondText.text =value.ToString();
    }

    IEnumerator ResetLevel(){
        yield return new WaitForSeconds(10f);
        SecondCounter -=1;
    }
}
