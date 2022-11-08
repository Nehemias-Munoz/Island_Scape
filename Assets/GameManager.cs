using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject barrelModel;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject shipModel;
    [SerializeField] private GameObject shipVariantModel;

    private int numberOfBarrels = 30;
    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
        player.transform.position = new Vector3(0, 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= -0.4f)
        {
            player.transform.position = new Vector3(0, 10, 0);
        }
    }


    void GenerateLevel()
    {
        Instantiate(barrelModel, new Vector3(0, 1, 0), Quaternion.identity);
        for (int i = 0; i < numberOfBarrels; i++)
        {
            Instantiate(barrelModel, new Vector3(Random.Range(-4,4),1,i*2.0F), Quaternion.Euler(0,Random.Range(-10,10), 0));

            if ( i == i / 2)
            {
                Instantiate(shipVariantModel, new Vector3(60, 3, i), Quaternion.Euler(0,180,0));
                Instantiate(shipVariantModel, new Vector3(-60, 3, i), Quaternion.identity);
            }
            if (i == numberOfBarrels-1)
            {
                Instantiate(shipModel, new Vector3(0, 3, i *2.3f), Quaternion.Euler(0,90,0));
            }
        }
        
    }
}
