using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{

    public float currentTime = 0f;
    public float startingTime = 30f;

    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        countdownText.text = currentTime.ToString("Timer: " + "0" + " Sec");

        if(currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene("GameLoseScene");
        }
    }
}
