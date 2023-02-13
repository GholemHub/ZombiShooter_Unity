using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public GameObject gitEffect;
    public int damage = 30;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        //столкнулся ли он с врагом? теги на каждом обьекте есть    
        if (collision.gameObject.CompareTag("enemy"))
        {
            GameObject effect = Instantiate(gitEffect, transform.position, Quaternion.identity);

            //Destroy(gameObject);


            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(enemy.damage);
            }
           // Debug.Log(collision.gameObject.name);
            Destroy(effect, 1f);
            Destroy(gameObject);

        }
        else if(collision.gameObject.CompareTag("Map"))
        {
           // Debug.Log("map collided")
                
            GameObject effect = Instantiate(gitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
            Destroy(gameObject);
        }
        else
        {
            GameObject effect = Instantiate(gitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
            Destroy(gameObject);

        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
     
       
    }
    //nado pridumat kuda postavit esli nie bylo collida
    IEnumerator waitIfNotCollided()
    {
        yield return new WaitForSeconds(4);
        Destroy(this);
    }
}
