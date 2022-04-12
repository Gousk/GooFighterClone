using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    public List <GameObject> destroyList = new List<GameObject>();
    public bool coroutineActive = false;
    public float fireRate = 0.9f;

    // Update is called once per frame
    void Update()
    {
        if (destroyList.Any() == true)
        {      
            if (coroutineActive == false)
            {
                StartCoroutine(Shootingv2());   
            }
        }
    }     

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Enemy")
        {
            other.tag = "DestroyedEnemy";
            destroyList.Add(other.gameObject);            
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "DestroyedEnemy")
        {
            other.tag = "Enemy";
            destroyList.Remove(other.gameObject);            
        }  
    }

    public IEnumerator Shootingv2()
    {
        for (int i = 0; i < destroyList.Count; i++)
        {
            coroutineActive = true;
            
            Vector3 spawnPos = new Vector3(transform.position.x,transform.position.y + 2f,transform.position.z);
            GameObject a = Instantiate(bulletPrefab, spawnPos, Quaternion.identity) as GameObject;

            a.transform.DOMove(destroyList.First().gameObject.transform.position, 0.3f);

            yield return new WaitForSeconds(fireRate);
            coroutineActive = false;    
        }
    }                
}
