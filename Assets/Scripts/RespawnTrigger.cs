using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
      GameManager.instance.ChangeRespawnPosition();   
        print("Respawn");
    }
}
