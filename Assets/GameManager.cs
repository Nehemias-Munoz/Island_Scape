using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
    #region  Variables
    [Header("Level Prefabs")]
    [SerializeField] private GameObject[] barrelModels;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject shipModel;
    [SerializeField] private GameObject shipVariantModel;
    [SerializeField] private GameObject enemyModel;
    public static GameManager instance;
    
    [Header("Level Settings")]
    [SerializeField] private int numberOfBarrels = 30;
    [SerializeField] private int difficult = 1;
    private int level = 1;

    public int Level
    {
        get => level;
        set
        {
            level = value;
            UIManager.instance.UpdateLevelUI(level);
        }
        
    }
    
    [Header("Enemy Settings")]
    public float enemySpeed;
    private int position;
    
    [Header("Player Settings")]
    private int playerLives;
    public int PlayerLives {
        get{
            return playerLives;
        }
        set{
            playerLives = value;
            UIManager.instance.UpdateHealtUI(playerLives);
            if(playerLives <=0){
               UIManager.instance.ShowGameOverScene();
            }
        }
    }
    Vector3 respawnPoint;
    Vector3 respawnPosition;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
          instance = this;
        }

        GenerateLevel();
        respawnPosition = new Vector3(0, 5, 0);
        player.transform.position = respawnPosition;
        PlayerLives = 3;
        StartCoroutine(SpawnEnemys(position));

    }

    void Update()
    {
        if (player.transform.position.y < -0.4f)
        {
            Dead();
        }
    }

    void GenerateLevel()
    {
        numberOfBarrels += level;
        Instantiate(barrelModels[0], new Vector3(0, 1, 0), Quaternion.identity);
        for (int i = 1; i < numberOfBarrels; i++)
        {
            Instantiate(barrelModels[0], new Vector3(Random.Range(-4,4),1,i*2.0F), Quaternion.Euler(0,Random.Range(-10,10), 0));

            if ( i == numberOfBarrels / 2)
            {
              Vector3 respawnBarrelPoint;
                respawnPoint = new Vector3(4,10,i*2.0F);
                respawnBarrelPoint= new Vector3(4,1.1f,i*2.0F);
                Instantiate(barrelModels[1],respawnBarrelPoint,Quaternion.Euler(0,Random.Range(-10,10), 0));
                Instantiate(shipVariantModel, new Vector3(40, 7.0f, i), Quaternion.Euler(0,180,0));
                Instantiate(shipVariantModel, new Vector3(-40, 7.0f, i), Quaternion.identity);
            }
            if (i == numberOfBarrels-1)
            {
                Instantiate(shipModel, new Vector3(0, 5, i *2.3f), Quaternion.Euler(0,90,0));
                position = i;
            }
        }
        
    }

    public void NextLevel(){
        SceneManager.LoadScene("NextLevelScene");
        Level += 1;
    }
    public void ChangeRespawnPosition(){
      respawnPosition = respawnPoint;
    }

    IEnumerator SpawnEnemys(int i)
    {
        Instantiate(enemyModel,new Vector3(Random.Range(-10,10),20,i * 2.5f),Quaternion.identity);
        yield return new WaitForSeconds(20.0f);
    }


    void Dead(){
        PlayerLives-=1;
        player.transform.position = respawnPosition; 
    }

}
