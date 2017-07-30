using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Generics
{
    public class GenricsTest : MonoBehaviour
    {
        public float spawnRadius = 50f;
        public GameObject prefab;
        public int spawnAmount = 20;
        public CustomList<GameObject> gameObjects = new CustomList<GameObject>();


        void Start()
        {

            gameObjects.Add(prefab);
            gameObjects.Contains(prefab);
            gameObjects.Clear();

            for (int i = 0; i < spawnAmount; i++)
            {
                GameObject clone = Instantiate(prefab);
                Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
                clone.transform.position = randomPos;
                gameObjects[0] = new GameObject();

            }
            
            

        }



    }
}
