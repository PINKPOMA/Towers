using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IceTower : Tower
{
    private Collider iceCol;
    void Start()
    {
        State = CanonState.Slow;
        iceCol = GetComponent<Collider>();
        StartCoroutine(IceAttack());
    }

    private IEnumerator IceAttack()
    {
        while (true)
        {
            iceCol.enabled = false;
            yield return new WaitForSeconds(2f);
            iceCol.enabled = true;
            yield return new WaitForSeconds(2f);
        }
    }
}
