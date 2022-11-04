using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{

    [SerializeField] private float damage = 1f;
    [SerializeField] private float range = 150;
    [SerializeField] private Transform bullet;

    [SerializeField]
    private Camera playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }   
    }


    // ReSharper disable Unity.PerformanceAnalysis
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
