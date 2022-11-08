using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CanionFire : MonoBehaviour
{
    private bool isGunLoaded = true;
    [SerializeField] private GameObject bulletModel;
    [FormerlySerializedAs("Aim")] [SerializeField] private Transform aim;
    private Transform player;
    private string playerTag = "Player";
    [SerializeField] private float shootForce = 1500f;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(playerTag).transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        if (isGunLoaded)
        {
            Shoot();
            isGunLoaded = false;
            StartCoroutine(ReloadCanion());
        }
    }

    void Shoot()
    {
        GameObject newBullet;
        newBullet = Instantiate(bulletModel, aim.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().AddForce(aim.forward * shootForce);
        Destroy(newBullet,2);
        
    }
    IEnumerator ReloadCanion()
    {
        yield return new WaitForSeconds(1.5f);
        isGunLoaded = true;
    }

   
}
