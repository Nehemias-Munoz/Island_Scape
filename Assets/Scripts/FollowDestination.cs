using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDestination : MonoBehaviour
{
  [SerializeField] GameObject[] destinationPoints;
  [SerializeField] Transform destination;
  public float speed = 5.0f; 
    // Start is called before the first frame update
    void Start()
    {
        destinationPoints = GameObject.FindGameObjectsWithTag("WP");
        destination = GameObject.FindGameObjectWithTag("Player").transform;

        destination = destinationPoints[Random.Range(0, destinationPoints.Length)].transform;
    }

    // Update is called once per frame
    void Update()
    {
        float space = speed* Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,destination.position,space);
        Vector3 targetDirection = destination.position - transform.position;
        if (targetDirection.magnitude < 0.1f)
        {
            destination = destinationPoints[Random.Range(0, destinationPoints.Length)].transform;
        }
    }
}
