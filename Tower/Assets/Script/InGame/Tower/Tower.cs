using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private int damage;
    [SerializeField] private int price;
    [SerializeField] private float delay;
    [SerializeField] private List<GameObject> colliderEnemys;

    private void Start()
    {
        StartCoroutine("Attack");
    }

    public IEnumerator Attack()
    {
        if (colliderEnemys.Count > 0)
        {
            GameObject target = colliderEnemys[0];
            if (target != null)
            {   
                var towerBullet = Instantiate(bullet, transform.position, Quaternion.identity,transform);
                towerBullet.GetComponent<Lamp>().targetPosition = (target.transform.position - transform.position).normalized;
                towerBullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
        }
        yield return new WaitForSeconds(delay);
        StartCoroutine("Attack");
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Enemy"))
            colliderEnemys.Add(collision.gameObject);
    }
    private void OnTriggerExit(Collider collision)
    {
        foreach (GameObject go in colliderEnemys)
        {
            if (go == collision.gameObject)
            {
                colliderEnemys.Remove(go);
                break;
            }
        }
    }
}
