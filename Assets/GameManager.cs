using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject[] barrelModels;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject shipModel;
    [SerializeField] private GameObject shipVariantModel;
    [SerializeField] private GameObject enemyModel;
    public static GameManager instance;
    bool touchRespawnPoint = false;
    Vector3 respawnPoint;
    Vector3 respawnPosition;
    private int numberOfBarrels = 30;
     
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
          instance = this;
        }

        respawnPosition = new Vector3(0, 3, 0);
        GenerateLevel();
        player.transform.position = respawnPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -0.4f)
        {
            player.transform.position = respawnPosition; 
        }
    }


    void GenerateLevel()
    {
        Instantiate(barrelModels[0], new Vector3(0, 1, 0), Quaternion.identity);
        for (int i = 0; i < numberOfBarrels; i++)
        {
            Instantiate(barrelModels[0], new Vector3(Random.Range(-4,4),1,i*2.0F), Quaternion.Euler(0,Random.Range(-10,10), 0));

            if ( i == numberOfBarrels / 2)
            {
              Vector3 respawnBarrelPoint;
                respawnPoint = new Vector3(4,10,i*2.0F);
                respawnBarrelPoint= new Vector3(4,1.1f,i*2.0F);
                Instantiate(barrelModels[1],respawnBarrelPoint,Quaternion.Euler(0,Random.Range(-10,10), 0));
                Instantiate(shipVariantModel, new Vector3(60, 3, i), Quaternion.Euler(0,180,0));
                Instantiate(shipVariantModel, new Vector3(-60, 3, i), Quaternion.identity);
            }
            if (i == numberOfBarrels-1)
            {
                Instantiate(shipModel, new Vector3(0, 3, i *2.3f), Quaternion.Euler(0,90,0));
                StartCoroutine(SpawnEnemys(i));
            }
        }
        
    }

    //Todo: fix respawnPoint
    public void ChangeRespawnPosition(){
      respawnPosition = respawnPoint;
    }

    IEnumerator SpawnEnemys(int i)
    {
        Instantiate(enemyModel,new Vector3(Random.Range(-10,10),20,i * 2.5f),Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(2.5f,3.5f));
    }

     
}
