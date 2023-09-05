using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody sphereRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        sphereRigidbody = GetComponent<Rigidbody>();
        sphereRigidbody.velocity = transform.forward * speed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.Die();
            }
        }
        else if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
