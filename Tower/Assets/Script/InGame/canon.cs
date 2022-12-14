
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public partial class Canon : MonoBehaviour
{
    private float _attackDelay = 0;
    [SerializeField] private GameObject[] canonObjects = new GameObject[4];
    [SerializeField] private TowerInformation information;
    
    public int Level { get; set; } = 1;
    public TowerState State { get; set; }
    
    public void UpdateCanonInformation(int level, TowerState newState)
    {
        Level = level;
        State = newState;
        if (newState != TowerState.Default)
        {
            information = GameManager.Instance.TowerData[(int) State][Level - 1];   
        }
        InitializeCanonObject();
    }
    
    private void InitializeCanonObject()
    {
        for (var i = 0; i < canonObjects.Length; i++)
        {
            if (State == TowerState.None) continue;
            canonObjects[i].SetActive(i == (int) State);
        }
    }

    private void Update()
    {
        _attackDelay += Time.deltaTime;
        
        if(State == TowerState.None) return;
        
        Attack();

    }
    
    private void Attack()
    {
        if(_attackDelay < information.AttackDelay) return;
        
        var col = Physics.OverlapSphere(transform.position, information.Range, LayerMask.NameToLayer("Enemy"));
        if(col.Length == 0) return;
        
        col.ToList().Sort((a, b) =>
        {
            var position = transform.position;
            var distanceA = Vector3.Distance(position, a.transform.position);
            var distanceB = Vector3.Distance(position, b.transform.position);
            return distanceA.CompareTo(distanceB);
        });
        
        var targetCount = State == TowerState.MultiShot ? (int) Mathf.Min(col.Length, information.Extra) : 1;
        var targets = col.Take(targetCount).ToList();
        foreach (var target in targets)
        {
            Shot(target.gameObject);
        }
    }

    private void Shot(GameObject target)
    {
        print("Attack Enemy");
    }

    
    private void OnDrawGizmos()
    {
        const float radius = 0.2f;
        Gizmos.color = new Color(0.5f, 0.7f, 1, 0.5f);
        var currentPosition = transform.position;
        var position = new Vector2(currentPosition.x, currentPosition.y);
        Gizmos.DrawSphere(position, radius);
    }
}