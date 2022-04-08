using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float time = 10f;
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPoition = player.transform.position;
        Vector3 firstPosition = gameObject.transform.position;
        Vector3 GoalPos = new Vector3(playerPoition.x,0,playerPoition.z);
        transform.position = Vector3.Lerp(firstPosition, GoalPos, time * Time.deltaTime);   
    }
}
