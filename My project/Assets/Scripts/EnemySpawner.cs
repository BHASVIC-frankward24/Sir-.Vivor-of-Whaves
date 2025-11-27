using System.Collections;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject monsterReference;

    private int randomIndex;

    private GameObject spawnedMonster;  


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnMonsters());
        PlayerPrefs.SetString("Original", "False");
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0, 3));

             spawnedMonster = Instantiate(monsterReference);

            int X = Random.Range(-21, 21);
            int Y = Random.Range(-9, 9);

            spawnedMonster.GetComponent<EnemyMovement>().VelocityMultiplier = 7;
            spawnedMonster.GetComponent<EnemyMovement>().Original = false;
            spawnedMonster.transform.position = new UnityEngine.Vector3(X, Y, -1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
