using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates
{

    public class EnemySpawner : MonoBehaviour
    {

        public Transform target;
        public GameObject orcPrefab, trollPrefab;
        public int minAmount = 0, maxAmount = 20;
        public float spawnRate = 1f;


        delegate void SpawnFunc(int amount);
        private List<SpawnFunc> enemies = new List<SpawnFunc>();

        

        void Awake()
        {
            enemies.Add(SpawnOrc);
            enemies.Add(SpawnTroll);
        }

        void SpawnTroll(int amount)
        {
            Instantiate(trollPrefab, target);
        }

        void SpawnOrc(int amount)
        {
            Instantiate(orcPrefab, target);
        }

        
        void Update()
        {
           
        }
    }
}
