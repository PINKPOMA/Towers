using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
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
        // 총알의 이동 속도가 많이 수상함
        transform.position = 
            Vector3.MoveTowards(
                transform.position,
                target.position,
                moveSpeed * Time.deltaTime
            );
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var damage = collision.gameObject.GetComponent<Enemy>();
            damage.hp -= upgrade * 10;
            Destroy(gameObject);
        }
    }
}
