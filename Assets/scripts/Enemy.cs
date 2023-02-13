using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public GameObject blood;
	public static Enemy instance;
    private void Awake()
    {
		instance = this;
    }
    public int health = 100;
	public GameObject deathEffect;
	public GameObject player;
	public bool kicked = false;
	public int damage;
	public int scoreForDeath;
	public GameObject itemBullets;
	public GameObject itemAid;
	private void Start()
	{
		
		

		damage = 10;
		scoreForDeath = 10;
		player = GameObject.FindGameObjectWithTag("Player");
	}
	public void TakeDamage(int damage)
	{
		Instantiate(blood, transform.position, Quaternion.identity);
		health -= damage;

		SoundManagerScript.PlayerSound("SpiderHit");
		if (health <= 0)
		{

			Die();
			//Destroy(gameObject);
		}
	}

	void Die()
	{
		SoundManagerScript.PlayerSound("ZombiHit");
		//Instantiate(deathEffect, transform.position, Quaternion.identity);
		statistics.instance.scoreInt += scoreForDeath;
		statistics.instance.score.text = statistics.instance.scoreInt.ToString();

		DropItem();
		
		Destroy(gameObject);

		
	}
	void DropItem()
    {
		int rand = Random.Range(1, 3);
		Debug.Log("RAND" + rand);
		if (rand == 1)
		{
			if (itemBullets != null)
				if (itemBullets.GetComponent<dropBullet>() != null)
				{
					itemBullets.GetComponent<dropBullet>().count = Random.Range(0, 11);
					Instantiate(itemBullets, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
				}
		}
		else if (rand == 2)
		{
			if (itemAid != null)
				if (itemAid.GetComponent<aidKit>() != null)
				{
					itemAid.GetComponent<aidKit>().hp = Random.Range(15, 25);
					Instantiate(itemAid, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
				}
		}
		else
		{

		}

	}
	private void OnDestroy()
    {
		
		//else

	}
    private void FixedUpdate()
	{
		if (kicked)
		{
			///player.GetComponent<Rigidbody2D>().AddForce(transform.right * 20, ForceMode2D.Impulse);

		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Debug.Log("enemy collide with player");
			playerHealth.instance.currentHealth -= damage;
			kicked = true;


		}
	}
}
