using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Level;
    public TowerState State;

    public int upgrade;
    
    public Transform target;

    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        // 대상 오브젝트가 죽거나 파괴된 경우
        if (target == null || target.gameObject.activeSelf == false) Destroy(gameObject);
        
        transform.position = 
            Vector3.MoveTowards(
                transform.position,
                target.position,
                moveSpeed * Time.deltaTime
            );
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var damage = collision.gameObject.GetComponent<Enemy>();
            damage.Hit(State, Level);
            Destroy(gameObject);
        }
    }
}
