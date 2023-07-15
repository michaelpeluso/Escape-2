using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    public float timeLeft = 60f;
    public TextMeshProUGUI countdownText;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        countdownText.text = "Time left: " + Mathf.Round(timeLeft).ToString();

        if (timeLeft <= 0)
        {
            // Code to execute when countdown reaches 0.
        }
    }
}