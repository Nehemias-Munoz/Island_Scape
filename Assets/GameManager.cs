using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject barrelModel;
    [SerializeField] private GameObject player;

    private int numberOfBarrels = 10;
    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = new Vector3(0, 2, 0);
        GenerateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void GenerateLevel()
    {
        Instantiate(barrelModel, new Vector3(0, 1, 0), Quaternion.identity);
        for (int i = 0; i < numberOfBarrels; i++)
        {
            Instantiate(barrelModel, new Vector3(Random.Range(1,4),Random.Range(1,2),i), Quaternion.identity);
           
        }
    }
}
