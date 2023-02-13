using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class dropBullet : MonoBehaviour
{
    public int count;

    private void Start()
    {
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
    private void OnApplicationQuit()
    {
        //List<dropBullet> temp = new List<dropBullet>();
        //temp = GameObject.FindObjectsOfType<dropBullet>().ToList();

        //foreach(dropBullet d in temp)
        //{
        //    Destroy(d);
        //}
      //  Destroy(gameObject);
    }
}
