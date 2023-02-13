using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTimer : MonoBehaviour
{
    public static CountTimer instance;
    private void Awake()
    {
        instance = this;
    }
    float currentTime = 0;
    float startingTime = 5;

    public bool timeOut = false;

    [SerializeField] Text countDownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!timeOut)
        {
            currentTime -= 1 * Time.deltaTime;
            countDownText.text = currentTime.ToString("0");
            if (currentTime < 0)
            {
                currentTime = 0;
                if (tempController.instance.thirdWave && currentTime <= 0)
                {
                    //countDownText.text = "now just be careful";
                }
                else
                    countDownText.text = " ";
                if (tempController.instance.firstWave )
                {
                    tempController.instance.secondWave = true;
                    currentTime = 5f;
                    StartCoroutine(wait());
                }
                 else if (tempController.instance.secondWave && currentTime <=0)
                {
                    tempController.instance.thirdWave = true;
                    currentTime = 5f;
                    
                    StartCoroutine(wait());
                }
                
            }
        }
        else if(timeOut )
        {
           
        }
    }
    IEnumerator wait()
    {
        timeOut = true;
        yield return new WaitForSeconds(10f);
       
        timeOut = false;
    }
}
