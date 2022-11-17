using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{ 
    private GameObject player;
  float closenessThreshoold = 0.5f;
  float closeness;
  Vector3 direction;
  private string playerTag = "Player";
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(playerTag);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        closeness = direction.magnitude;
        direction = player.transform.position - transform.position;
        //movimiento
        transform.position += direction * (Time.deltaTime * GameManager.instance.enemySpeed);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Choque");
        Destroy(gameObject);
    }
}
