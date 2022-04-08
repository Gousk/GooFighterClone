using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class Shooterv2 : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    Vector3 lerping;
    GameObject a;
    
    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        //a.transform.position = lerping;    
    }     

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Enemy")
        {
            StartCoroutine(Shooting(other));
        }               
    }

    public IEnumerator Shooting(Collider other)
    { 
        yield return new WaitForSeconds(1f);
        
        Vector3 spawnPos = new Vector3(transform.position.x,transform.position.y + 2f,transform.position.z);
        a = Instantiate(bulletPrefab, spawnPos, Quaternion.identity) as GameObject;
        a.transform.DOMove(other.gameObject.transform.position, 0.6f);
        
        //lerping = Vector3.Lerp(gameObject.transform.position, other.transform.position, 1f);
    }
}
