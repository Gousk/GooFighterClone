using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;
    List<GameObject> enemies = new List<GameObject>();
    List<Transform> spawnPoints = new List<Transform>();
    GameObject spawnPointObject;
    bool coroutineActive = false;
    // Start is called before the first frame update
    void Start()
    {
        spawnPointObject = gameObject;

        enemies.Add(enemy1);
        enemies.Add(enemy2);
        enemies.Add(enemy3);    
    }

    // Update is called once per frame
    void Update()
    { 
        if (true)
        {      
            if (coroutineActive == false)
            {
                StartCoroutine(spawnRandom());   
            }
        }      
    }

    public IEnumerator spawnRandom() 
    {
        int j =0;
        coroutineActive = true;
        for (int i = 0; i < spawnPointObject.transform.childCount-1; i++)
        { 
            GameObject a = Instantiate(enemies[j], spawnPointObject.transform.GetChild(i)) as GameObject;
            a.name = "Enemy";
            if (j == 2)
            {
                j = 0;
            }
            else 
            {
                j=+1;
            }     
        }
        yield return new WaitForSeconds(10f);
        coroutineActive = false; 
    }
}
