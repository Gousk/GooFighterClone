using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{  
    Animator charAnimator;
    [SerializeField] float rotationSpeed = 400f;
    [SerializeField] float characterSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Player")
        {
            charAnimator = transform.GetChild(0).GetComponent<Animator>();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        float moveVertical = Input.GetAxisRaw ("Vertical");
  
        Vector3 movementDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movementDirection.Normalize(); 
  
        transform.Translate (movementDirection * characterSpeed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (gameObject.tag == "Player")
        {
            if (charAnimator.GetBool("isWalking") == false)
            {
                if (moveHorizontal > 0 || moveVertical > 0)
                {
                    charAnimator.SetBool("isWalking", true);
                } 
            }

            if (moveHorizontal == 0 && moveVertical == 0)
            {
                charAnimator.SetBool("isWalking", false);
            }
        }   
    }
}
