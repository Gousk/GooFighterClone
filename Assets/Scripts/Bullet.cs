using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject player;
    Shooter shooterS;
    GameObject slider;
    Score scoreS;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shooterS = player.GetComponent<Shooter>();
        slider = GameObject.FindWithTag("LevelBar");
        scoreS = slider.GetComponent<Score>(); 

        Destroy(gameObject, 0.41f);   
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "DestroyedEnemy")
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            scoreS.score+=10;
            Destroy(other.gameObject, 0f);
            shooterS.destroyList.Remove(other.gameObject);
            Destroy(gameObject, 0f);
        }    
    }
}
