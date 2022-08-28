using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTower : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject[] towers;
    public GameObject buyTower;
    
    private RaycastHit hit;
    private GameObject hitObject;
    private bool isClickSite;
    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Buy"))
                {
                    hitObject = hit.collider.gameObject;
                    isClickSite = true;
                    buyTower.SetActive(true);
                    mainCamera.transform.position = new Vector3(0,180,-20);
                }
            }
        }
    }

    public void DeafultTower()
    {
        if (GameManager.Instance.gold >= 40)
        {
            switch (hitObject.name)
            {
                case "Asite":
                    Instantiate(towers[0], new Vector3(-68, 11, 35), Quaternion.identity);
                    break;
                case "Bsite":
                    Instantiate(towers[0], new Vector3(68,11,35), Quaternion.identity);
                    break;
                case "Csite":
                    Instantiate(towers[0], new Vector3(0,11,0), Quaternion.identity);
                    break;
                case "Dsite":
                    Instantiate(towers[0], new Vector3(-68, 11, -35), Quaternion.identity);
                    break;
                case "Esite":
                    Instantiate(towers[0], new Vector3(68, 11, -35), Quaternion.identity);
                    break;
            }
            hitObject.SetActive(false);
            buyTower.SetActive(false);
            mainCamera.transform.position = new Vector3(0,150,-21.3999996f);
        }
    }
    public void IceTower()
    {
        if (GameManager.Instance.gold >= 40)
        {
            switch (hitObject.name)
            {
                case "Asite":
                    Instantiate(towers[2], new Vector3(-68, 11, 35), Quaternion.identity);
                    break;
                case "Bsite":
                    Instantiate(towers[2], new Vector3(68,11,35), Quaternion.identity);
                    break;
                case "Csite":
                    Instantiate(towers[2], new Vector3(0,11,0), Quaternion.identity);
                    break;
                case "Dsite":
                    Instantiate(towers[2], new Vector3(-68, 11, -35), Quaternion.identity);
                    break;
                case "Esite":
                    Instantiate(towers[2], new Vector3(68, 11, -35), Quaternion.identity);
                    break;
            }
            hitObject.SetActive(false);
            buyTower.SetActive(false);
            mainCamera.transform.position = new Vector3(0,150,-21.3999996f);
        }
    }
    public void AreaTower()
    {
        if (GameManager.Instance.gold >= 40)
        {
            switch (hitObject.name)
            {
                case "Asite":
                    Instantiate(towers[1], new Vector3(-68, 11, 35), Quaternion.identity);
                    break;
                case "Bsite":
                    Instantiate(towers[1], new Vector3(68,11,35), Quaternion.identity);
                    break;
                case "Csite":
                    Instantiate(towers[1], new Vector3(0,11,0), Quaternion.identity);
                    break;
                case "Dsite":
                    Instantiate(towers[1], new Vector3(-68, 11, -35), Quaternion.identity);
                    break;
                case "Esite":
                    Instantiate(towers[1], new Vector3(68, 11, -35), Quaternion.identity);
                    break;
            }
            hitObject.SetActive(false);
            buyTower.SetActive(false);
            mainCamera.transform.position = new Vector3(0,150,-21.3999996f);
        }
    }
}
