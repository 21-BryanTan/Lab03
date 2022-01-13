using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasketMovementScript2 : MonoBehaviour
{
    public GameObject ScoreText;

    public GameObject TimerText;

    public float speed;

    private int score;

    public AudioClip[] audioClipArray;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.GetComponent<Text>().text = "Score: " + score;

        source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

      float horizontalInput = Input.GetAxis("Horizontal");

      transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

      ScoreText.GetComponent<Text>().text = "Score: " + score;

        if(score >= 100)
        {
            SceneManager.LoadScene("GameWinScene");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Healthy"))
        {
            Destroy(other.gameObject);
            score += 10;
            source.PlayOneShot(audioClipArray[0], 0.2f);
            print("Healthy food collected!");
        }
        else if(other.gameObject.CompareTag("Unhealthy"))
        {
            Destroy(other.gameObject);
            source.PlayOneShot(audioClipArray[1], 0.2f);
            SceneManager.LoadScene("GameLoseScene");
            print("Unhealthy food collected!");
        }
    }
}
