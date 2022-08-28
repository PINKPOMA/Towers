using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IceTower : Tower
{
    private Collider iceCol;
    void Start()
    {
        iceCol = GetComponent<Collider>();
        StartCoroutine("IceAttack");
    }

    IEnumerator IceAttack()
    {
        iceCol.enabled = false;
        yield return new WaitForSeconds(2f);
        iceCol.enabled = true;
        yield return new WaitForSeconds(2f);
        StartCoroutine("IceAttack");
    }
}