using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    public float timeLeft = 60f;
    public TextMeshProUGUI countdownText;
    public GameObject capsule;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        countdownText.text = "Time left: " + timeLeft.ToString();


        if (timeLeft <= 0)
        {
            // Code to execute when countdown reaches 0.
        }

        


        

        }
        public  void IncreaseTime()
    {
        timeLeft += 120;
    }
    }

   