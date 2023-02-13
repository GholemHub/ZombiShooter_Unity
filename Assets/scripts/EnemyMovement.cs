using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyMovement : MonoBehaviour
{

    //public AIPath aIPath;
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float rotate = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

       if (GameObject.Find("player") != null) 
            player = GameObject.Find("player").transform;
        //Stashed changes
        rb = this.GetComponent<Rigidbody2D>();
    

      player = GameObject.Find("player").transform;
       rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle + rotate;
            direction.Normalize();
            movement = direction;
        }
    }

   

    private void FixedUpdate(){
       moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction){
       rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
