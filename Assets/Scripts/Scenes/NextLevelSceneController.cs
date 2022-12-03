
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevelSceneController : MonoBehaviour
{
    // Update is called once per frame
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
