using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Shooter shooterS;
    GameObject target;
    GameObject slider;
    Score scoreS;
    GameObject player; 
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("Slider");
        scoreS = slider.GetComponent<Score>();
        target = GameObject.Find("characterMedium");
        player = GameObject.Find("Player"); 
        shooterS = player.GetComponent<Shooter>();   
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.RotateAround(target.transform.position, Vector3.up, 160 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.name == "Enemy")
        {
            scoreS.score+=10;
            other.GetComponent<MeshRenderer>().enabled = false;
            Destroy(other.gameObject, 0f);
            shooterS.destroyList.Remove(other.gameObject);
        }   
    }
}
