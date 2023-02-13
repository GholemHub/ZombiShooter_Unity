using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class statistics : MonoBehaviour,ISaveable
{
    #region singleton
    public static statistics instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion
    public Text score;
    public int scoreInt;
    public int bulletsCount;
    public int currentRecord;
    [Header("UI")]
    public Text bulletText;
    // Start is called before the first frame update
    void Start()
    {
        bulletsCount = 100;

        LoadJsonData(this);
        score.text = scoreInt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        bulletText.text = bulletsCount.ToString();
        //score.text = "score:"+  scoreInt.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("itemDrop"))
        {
            SoundManagerScript.PlayerSound("CollectItems");
            bulletsCount += collision.gameObject.GetComponent<dropBullet>().count;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("firstAid"))
        {
            if (playerHealth.instance.currentHealth <= 200)
            {
                SoundManagerScript.PlayerSound("CollectItems");
                playerHealth.instance.currentHealth += collision.gameObject.GetComponent<aidKit>().hp;

                Destroy(collision.gameObject);
            }
        }
    }
    public void PopulateSaveData(SaveData sd)
    {
        sd.score = scoreInt;
    }
    public void LoadFromSaveData(SaveData sd)
    {
        currentRecord = sd.score;
    }
    public void SaveJsonData(statistics s)
    {
        SaveData sd = new SaveData();
        s.PopulateSaveData(sd);

        if (FileManager.WriteToFile("SaveData.dat", sd.toJson()))
        {
            Debug.Log("succesful save");
        }

    }
    public void LoadJsonData(statistics s)
    {
        if (FileManager.LoadFromFile("SaveData.dat", out var json))
        {
            SaveData sd = new SaveData();

            sd.LoadFromJson(json);

            s.LoadFromSaveData(sd);
            Debug.Log("Load complete");
        }
    }
    private void OnApplicationQuit()
    {
        SaveJsonData(this);

    }
}
