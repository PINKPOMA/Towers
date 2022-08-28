using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

enum ItemName
{
    Heal,
    AreaDeal,
    GoldDropUp,
    EnemyStop
}
public class item : MonoBehaviour
{
    public bool[] itemArray = new [] {true, true, true, true};
    public GameObject[] itemimgArray;
    public void Update()
    {
        if (itemArray[(int)ItemName.Heal])
        {
            itemimgArray[(int)ItemName.Heal].SetActive(true);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                itemimgArray[(int)ItemName.Heal].SetActive(false);
                //GameManager.instance.타워 hp += 15;
                itemArray[(int)ItemName.Heal] = false;
            }
        }
        if (itemArray[(int)ItemName.AreaDeal])
        {
            itemimgArray[(int)ItemName.AreaDeal].SetActive(true);
            if (Input.GetKeyDown(KeyCode.W))
            {
                //GameManager.instance.타워 hp += 15;
                itemArray[(int)ItemName.AreaDeal] = false;
                itemimgArray[(int)ItemName.AreaDeal].SetActive(false);
            }
        }
        if (itemArray[(int)ItemName.GoldDropUp])
        {
            itemimgArray[(int)ItemName.GoldDropUp].SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                //GameManager.instance.타워 hp += 15;
                itemArray[(int)ItemName.GoldDropUp] = false;
                itemimgArray[(int)ItemName.GoldDropUp].SetActive(false);
            }
        }
        if (itemArray[(int)ItemName.EnemyStop])
        {
            
            itemimgArray[(int)ItemName.EnemyStop].SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                itemimgArray[(int)ItemName.EnemyStop].SetActive(false);
                //GameManager.instance.타워 hp += 15;
                itemArray[(int)ItemName.EnemyStop] = false;
            }
        }
    }
}
