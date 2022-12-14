using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DefaultTower : Tower
{
    [SerializeField] private GameObject bullet;

    private const float minusY = 15f;
    
    private void Start()
    {
        State = TowerState.Default;
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        while (true)
        {
            var target = GetTarget();
            if (target == null)
            {
                yield return null;
                continue;
            }

            print("Shot");
            
            var towerBullet = Instantiate(bullet, transform.position, Quaternion.identity, gameObject.transform);
            var bulletScript = towerBullet.GetComponent<Bullet>();
            towerBullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            bulletScript.Level = level;
            bulletScript.State = State;
            bulletScript.target = target.gameObject.transform;


            yield return new WaitForSeconds(GameManager.Instance.GetCanonDate(State, level).AttackDelay);
        }
    }

    private Collider GetTarget()
    {
        var centerPosition = transform.position;
        centerPosition.y -= minusY;

        var col = Physics.OverlapSphere(centerPosition, GameManager.Instance.GetCanonDate(State, level).Range,
            1 << LayerMask.NameToLayer("Enemy"));
        if (col.Length == 0)
        {
            print("None Target");
            return null;
        }

        col.ToList().Sort((a, b) =>
        {
            var position = transform.position;
            var distanceA = Vector3.Distance(position, a.transform.position);
            var distanceB = Vector3.Distance(position, b.transform.position);
            return distanceA.CompareTo(distanceB);
        });

        return col.Take(1).ToList()[0];
    }
    
    private void OnDrawGizmos()
    {
        
        Gizmos.color = new Color(0.5f, 0.7f, 1, 0.5f);
        var towerPos = transform.position;
        towerPos.y = towerPos.y - minusY;
        var currentPosition = towerPos; 
        var position = new Vector2(currentPosition.x, currentPosition.y);
        Gizmos.DrawSphere(position, GameManager.Instance.GetCanonDate(State, level).Range);
    }
}
