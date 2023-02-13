using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{

    public GameObject firePoint1;
    public GameObject bullet = null;
    public GameObject bullet2 = null;
    public GameObject bullet3 = null;
    Joystick shootJoystick;
    public float force1 = 20f;

    private void Start()
    {
        firePoint1 = GameObject.FindGameObjectWithTag("firepoint");
    }

    void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && statistics.instance.bulletsCount > 0)
        {
            shoot();
        }
        else if (Input.touchCount>0 && Input.touches[0].phase==TouchPhase.Began && statistics.instance.bulletsCount > 0)
        {
            shoot();
        }
    }


    void shoot()
    {

        SoundManagerScript.PlayerSound("fire");

        if (tempController.instance.firstWave)
        {
            GameObject bulletG = Instantiate(bullet, firePoint1.transform.position, firePoint1.transform.rotation);
            statistics.instance.bulletsCount -= 1;
            Rigidbody2D rb = bulletG.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint1.transform.right * force1, ForceMode2D.Impulse);
        }
        if (tempController.instance.secondWave)
        {
            GameObject bulletG = Instantiate(bullet2, firePoint1.transform.position, firePoint1.transform.rotation);
            statistics.instance.bulletsCount -= 1;
            Rigidbody2D rb = bulletG.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint1.transform.right * force1, ForceMode2D.Impulse);
        }
        if (tempController.instance.thirdWave)
        {
            GameObject bulletG = Instantiate(bullet3, firePoint1.transform.position, firePoint1.transform.rotation);
            statistics.instance.bulletsCount -= 1;
            Rigidbody2D rb = bulletG.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint1.transform.right * force1, ForceMode2D.Impulse);
        }
    }
}
