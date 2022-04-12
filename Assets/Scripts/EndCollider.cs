using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadScene(){
       SceneManager.LoadScene("Level1"); 
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "DestroyedEnemy")
        {
            transform.GetComponentInParent<CharController>().enabled = false;
            Invoke("LoadScene", 1f);
        }
    }
}
