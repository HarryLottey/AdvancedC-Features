using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates
{

    public class EnemySpawner : MonoBehaviour
    {

        public Transform target;
        public Transform spawnLocation;
        public GameObject orcPrefab, trollPrefab;
        public int minAmount = 1, maxAmount = 20;
        public float spawnRate = 1f;
        


        delegate void SpawnFunc(int amount);
        private List<SpawnFunc> enemies = new List<SpawnFunc>();

        
        
        
        void Awake()
        {
            enemies.Add(SpawnOrc);
            enemies.Add(SpawnTroll);
        }

        private void Start()
        {
            
            StartCoroutine(Spawn());
            
        }

        void SpawnOrc(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Instantiate(orcPrefab, spawnLocation); // Temp spawn location, make random
            }
            
        }

        void SpawnTroll(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Instantiate(trollPrefab, spawnLocation);
            }
           
        }

        IEnumerator Spawn()
        {
            int randAmount = Random.Range(minAmount, maxAmount); // Determine quantity of enemies to be spawned
            int randType = Random.Range(0, 2); // Determine which enemy is spawned
            enemies[randType](randAmount); // Call enemy type, then amount
            yield return new WaitForSeconds(spawnRate);
            StartCoroutine(Spawn()); // Loop
        }
    }
}
