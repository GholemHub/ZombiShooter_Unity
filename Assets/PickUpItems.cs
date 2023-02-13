using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{

    public Rigidbody2D rb;

    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(collision.gameObject.name);
            
            Destroy(gameObject);
        }
	}
}
