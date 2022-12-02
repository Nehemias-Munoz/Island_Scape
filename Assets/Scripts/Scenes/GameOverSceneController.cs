using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneController : MonoBehaviour
{
    [SerializeField] private TMP_Text secondText;
    private int secondCounter;
    public int SecondCounter{
        get => secondCounter;
        set{
            secondCounter = value;
            UpdateSecondUI(secondCounter);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SecondCounter = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            SceneManager.LoadScene("GamePlayScene");
        }

        if(Input.GetKeyDown(KeyCode.E)){
            Application.Quit();
        }
        
    }
    public void UpdateSecondUI(int value){
        secondText.text =value.ToString();
    }

    // IEnumerator ResetLevel(){
    //     SecondCounter -=1;
    //     yield return new WaitForSeconds(10);
    // }
}
