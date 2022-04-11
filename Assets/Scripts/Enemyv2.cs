using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyv2 : MonoBehaviour
{
    public Transform target;
    public float speed = 4f;
    Rigidbody rig;
    Quaternion lastRotation;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.LookAt(target.transform.position);
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        rig.MovePosition(pos);
    } 
}
