using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Define_Canon_Informations

public enum CanonState
{
    None = -1,
    Default = 0,
    MultiShot = 1,
    Laser = 2,
    Slow = 3,
}

public class CanonInformation
{
    [field: SerializeField] public float Damage { get; set; }
    [field: SerializeField] public float AttackDelay { get; set; }
    
    [field: SerializeField] public float Cost { get; set; }
    [field: SerializeField] public float Range { get; set; } = 45;
    [field: SerializeField] public float Extra { get; set; } = 0;
}
#endregion


public class GameManager : Singleton<GameManager>
{
    public int gold = 0;

    private RaycastHit hit;
    
    #region Define_Canon_Informations
    
    public CanonInformation[][] CanonData = 
    {
        new CanonInformation[] // Default Canon
        {
            new CanonInformation {Damage = 3, AttackDelay = 2, Cost = 10}, // Level 1
            new CanonInformation {Damage = 5, AttackDelay = 1.5f, Cost = 20}, // Level 2
            new CanonInformation {Damage = 7, AttackDelay = 1, Cost = 30}, // Level 3
        },
        new CanonInformation[] // Multi Shot Canon
        {
            // Extra : Count of Multi Target
            new CanonInformation {Damage = 2, AttackDelay = 2, Cost = 20, Extra = 3}, // Level 1
            new CanonInformation {Damage = 3, AttackDelay = 2, Cost = 100, Extra = 6}, // Level 2
            new CanonInformation {Damage = 4, AttackDelay = 2, Cost = 200, Extra = 10}, // Level 3
        },
        new CanonInformation[] // Laser Canon
        {
            new CanonInformation {Damage = 2, AttackDelay = 2, Cost = 20, Range = 1}, // Level 1
            new CanonInformation {Damage = 4, AttackDelay = 2, Cost = 25, Range = 1.5f}, // Level 2
            new CanonInformation {Damage = 5, AttackDelay = 1, Cost = 30, Range = 2}, // Level 3
        },
        new CanonInformation[] // Slow Canon
        {
            // Extra : Slow Down Enemy Speed Percent for 5 Seconds
            new CanonInformation {Damage = 3, AttackDelay = 1, Cost = 20, Range = 1, Extra = 10}, // Level 1
            new CanonInformation {Damage = 3, AttackDelay = 1, Cost = 50, Range = 1.5f, Extra = 20}, // Level 2
            new CanonInformation {Damage = 3, AttackDelay = 1, Cost = 70, Range = 2, Extra = 40}, // Level 3
        }
    };

    public CanonInformation GetCanonDate(CanonState state, int level) => CanonData[(int) state][level];
    #endregion
    
    public void Start()
    {
        gold = 100;
    }

    public void EndSign()
    {
        
    }
    private void Update()
    {
    }
}
