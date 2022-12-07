using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeSceneController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("GameplayScene");
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            Application.Quit(); 
        }

    }
}
