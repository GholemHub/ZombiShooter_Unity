using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class playerHealth : MonoBehaviour
{
    [SerializeField] Text countHealthText;

    public static playerHealth instance;
    private void Awake()
    {
        instance = this;
    }
    public int currentHealth;
    public int maxHealth; 
    public GameObject deathMenuUI;
    public GameObject UI;
    public GameObject canvasJS;
    public TMPro.TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        countHealthText.text = currentHealth.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
//		if(collision.gameObject.CompareTag("FirstAid"))
//        {

////            Debug.Log(collision.gameObject.name);
//            if(currentHealth < 100)
//            {
//                currentHealth += 20;
//                Destroy(collision.gameObject);
//            }else{

//            }

            

//        }
	}


    // Update is called once per frame
    void Update()
    {
        //countHealthText.text = maxHealth.ToString();
        countHealthText.text = currentHealth.ToString();
        if(currentHealth<=0)
        {
            die();
            
        }
    }
    void die()
    {
        List<aidKit> temp = new List<aidKit>();
        temp = GameObject.FindObjectsOfType<aidKit>().ToList();

        foreach (aidKit d in temp)
        {
            Destroy(d);
        }
        List<dropBullet> temp1 = new List<dropBullet>();
        temp1 = GameObject.FindObjectsOfType<dropBullet>().ToList();

        foreach (dropBullet d in temp1)
        {
            Destroy(d);
        }
        //SceneManager.LoadScene("SampleScene");
        //Destroy(gameObject);

        Time.timeScale = 0f;
        gameObject.SetActive(false);
        UI.SetActive(false);
        canvasJS.SetActive(false);
        deathMenuUI.SetActive(true); 
        score.enabled = false;
        score.SetText("SCORE: " + statistics.instance.scoreInt.ToString());
        score.ForceMeshUpdate(true);
        score.enabled = true;


    }

}
