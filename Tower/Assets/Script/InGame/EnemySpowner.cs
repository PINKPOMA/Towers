using System.Collections;
using UnityEngine;

public class EnemySpowner : MonoBehaviour
{
    public GameObject[] enemy;


    void Start()
    {
        StartCoroutine("StartWave");
    }
    
    IEnumerator StartWave()
    {
        for (int i = 0; i < 3; i++)
        {
            StartCoroutine("SpawnEnemy");
            yield return new WaitForSeconds(60f);
        }
    }

    IEnumerator SpawnEnemy()
    {
        var enemCount = Random.Range(3, 8);
        var dir = new Vector3(transform.position.x - 10, transform.position.y, transform.position.z);
        for (int i = 0; i < enemCount; i++)
        {
            Instantiate(enemy[0], dir, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}
