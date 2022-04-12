using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyv2 : MonoBehaviour
{
    public Transform target;
    
    Quaternion lastRotation;
    public float speed = 4f;

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.LookAt(target.transform.position);
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        transform.position = pos;
    } 
}
