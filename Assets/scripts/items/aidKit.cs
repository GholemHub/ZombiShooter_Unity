using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class aidKit : MonoBehaviour
{
    public int hp;


    private void Start()
    {
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        //SoundManagerScript.PlayerSound("CollectItems");
        yield return new WaitForSeconds(6f);
        Destroy(gameObject);
    }
    private void OnApplicationQuit()
    {
       // Destroy(gameObject);
        //List<aidKit> temp;
        //temp = FindObjectsOfType<aidKit>().ToList();
        
        //foreach (aidKit d in temp)
        //{
        //    Debug.Log("d" + d);
        //    Destroy(d);
        //}
    }
}
