using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CanionFire : MonoBehaviour
{
    private bool isGunLoaded = true;
    [SerializeField] private GameObject bulletModel;

    [Header("Audio stuff")] 
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip shootSound;
    
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
        PlaySound();
        newBullet = Instantiate(bulletModel, aim.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().AddForce(aim.forward * shootForce);
        Destroy(newBullet,2);
        
    }
    IEnumerator ReloadCanion()
    {
        yield return new WaitForSeconds(Random.Range(2.5f,3.5f));
        isGunLoaded = true;
    }

    void PlaySound()
    {
        _audioSource.PlayOneShot(shootSound);
    }
   
}
