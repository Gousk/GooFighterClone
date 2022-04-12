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
        Vector3 minScale = new Vector3(5F,5F,1F);
        Vector3 minusScale = new Vector3(0.5F,0.5F,0.2F);
        Vector3 bossMinScale = new Vector3(10F,10F,5F);
        
        if (other.tag == "DestroyedEnemy")
        {
            if (other.name == "Enemy")
            {
                other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                scoreS.score+=10;
                Destroy(other.gameObject, 0f);
                shooterS.destroyList.Remove(other.gameObject);
                Destroy(gameObject, 0f);
            }
            else if (other.name == "Goo")
            {
                other.transform.localScale = minScale;
                other.name = "Enemy";
            }
            else if (other.name == "Boss")
            {
                other.transform.localScale = other.transform.localScale - minusScale;
                if (other.transform.localScale.x < bossMinScale.x)
                {
                    scoreS.score+=30;
                    Destroy(other.gameObject, 0f);
                    shooterS.destroyList.Remove(other.gameObject);
                    Destroy(gameObject, 0f);    
                }
            }
        }    
    }
}
