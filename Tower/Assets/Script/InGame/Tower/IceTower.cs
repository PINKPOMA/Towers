using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IceTower : Tower
{
    private Collider iceCol;
    
    void Start()
    {
        State = TowerState.Slow;
        iceCol = GetComponent<Collider>();
        StartCoroutine(IceAttack());
    }

    private IEnumerator IceAttack()
    {
        while (true)
        {
            iceCol.enabled = false;
            yield return new WaitForSeconds(GameManager.Instance.GetCanonDate(State, level).AttackDelay);
            iceCol.enabled = true;
            yield return new WaitForSeconds(GameManager.Instance.GetCanonDate(State, level).AttackDelay);
        }
    }
}
