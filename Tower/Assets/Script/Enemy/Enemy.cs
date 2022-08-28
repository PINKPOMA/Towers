using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] public float hp;

    private Transform _target;
    private int pointsIndex;
    private int[] moveIndex;
    
    void Start()
    {
        _target = WayPoint.Waypoints[0];
        if (Random.Range(0, 2) != 0)
            moveIndex = new[] {0,1, 2, 3, 4, 1, 2, 5, 6};
        else
            moveIndex = new[] {0,4, 3, 2, 1, 4, 3, 2, 1, 4, 3, 5, 6};
    }

    void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);
        
        if(Vector3.Distance(transform.position,_target.position)<=0.4f)
        {
            GetNextWaypoint();
        }   
    }
    
    private void GetNextWaypoint()
    {
        pointsIndex++;
        var wayPointIndex = moveIndex[pointsIndex];
        _target = WayPoint.Waypoints[wayPointIndex];
    }

  

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ice"))
            speed = 10;
    }
}
