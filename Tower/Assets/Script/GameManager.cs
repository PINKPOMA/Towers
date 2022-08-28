using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    
    #region Define_Canon_Informations
    
    public class CanonInformation
    {
        [field: SerializeField] public float Damage { get; set; }
        [field: SerializeField] public float AttackDelay { get; set; }
        [field: SerializeField] public float Cost { get; set; }
        [field: SerializeField] public float Range { get; set; } = 1;
        [field: SerializeField] public float Extra { get; set; } = 0;
    }
    #endregion
    
    public int gold;

    private RaycastHit hit;
    
    public void Start()
    {
        gold = 100;
    }

    private void Update()
    {
    }
}
