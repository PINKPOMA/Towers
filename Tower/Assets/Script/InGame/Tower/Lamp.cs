using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Vector3 targetPosition = Vector3.zero;
    public int upgrade;
    
    void Update()
    {
        transform.Translate(targetPosition * Time.deltaTime * 100f);
        float distance = Vector3.Distance(transform.position, transform.parent.position);
        if (distance > 50f)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var damage = collision.gameObject.GetComponent<Enemy>();
            damage.hp -= upgrade * 10;
        }
    }
}
