using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Generics
{
    public class GenricsTest : MonoBehaviour
    {
        public float spawnRadius = 50f;
        public GameObject prefab;
        public GameObject prefab2;
        public int spawnAmount = 20;
        public CustomList<GameObject> gameObjects = new CustomList<GameObject>();


        void Start()
        {

            gameObjects.Add(prefab);
            if (gameObjects.Contains(prefab)) 
            {
                print("this item is in the list :)))))");
            }
            
            gameObjects.Clear();

            if (gameObjects.Contains(prefab2))
            {
                print("this is a different item in the list now");
            }

            /* 
               for (int i = 0; i < spawnAmount; i++)
            {
                GameObject clone = Instantiate(prefab);
                Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
                clone.transform.position = randomPos;
                gameObjects[0] = new GameObject();

            }
             */

        }



    }
}
