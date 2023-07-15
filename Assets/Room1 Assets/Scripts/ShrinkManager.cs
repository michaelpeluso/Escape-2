using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShrinkManager : MonoBehaviour
{
    public float targetSize = 0.5f;
    public float initialShrinkSpeed = 0.1f; //0.0008333 = 10 minutes    0.0006944 = 12 minutes
    public GameObject whiteboard;

    void Start()
    {
        StartCoroutine(ShrinkOverTime(gameObject, targetSize, initialShrinkSpeed));
    }

    IEnumerator ShrinkOverTime(GameObject obj, float targetSize, float shrinkSpeed)
    {
        while (obj.transform.localScale.x > targetSize && obj.transform.localScale.y > targetSize && obj.transform.localScale.z > targetSize)
        {
            obj.transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
            yield return null;
        }

        obj.transform.localScale = Vector3.one * targetSize;
        GameLost();
    }

    public void IncreaseShrinkSpeed()
    {
        StopCoroutine("ShrinkOverTime");
        StartCoroutine(ShrinkOverTime(gameObject, targetSize, initialShrinkSpeed));
        Debug.Log(initialShrinkSpeed);
    }

    public void GameLost() {
        Debug.Log("Game Lost");
        whiteboard.GetComponent<TextMeshProUGUI>().text = "You ran out of time!" + "\n" + "You are too small!";
        
        IEnumerator WaitAndExecute()
        {
            yield return new WaitForSeconds(10f);
            SceneManager.LoadScene(0);
        }
        StartCoroutine(WaitAndExecute());
    }
}
