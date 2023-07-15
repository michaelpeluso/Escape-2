using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;


public class MixingPotManager : MonoBehaviour
{   
    public List<GameObject> correctSolutionList;
    public List<GameObject> solutionList;
    private GameObject solutionMesh;
    [Range(0, 1)] public float pouringThreshhold;
    
    public GameObject current;
    public int maxPreviousAttempts = 7;
    private string currentSolution;
    private bool isDrinking;

    public GameObject PlayerHeadTrigger;
    public GameObject XROrigin;

    void Start()
    {
        //correctSolutionList = new List<GameObject>();
        solutionList = new List<GameObject>();
        solutionMesh = transform.GetChild(0).gameObject;
        solutionMesh.SetActive(false);
        XROrigin = GameObject.Find("XR Origin");
        isDrinking = false;
    }

    void Update()
    {
        EmptyMix();
    }

    private void OnTriggerStay(Collider other) {
        GameObject flask = other.gameObject;
        if (flask.GetComponent<FlaskManager>() != null) {
            if (Vector3.Dot(flask.transform.up, Vector3.down) > pouringThreshhold) {
                AddSolution(flask);
            }   
        }

        if (other.gameObject == PlayerHeadTrigger) {
            isDrinking = true;
        }
        else {
            isDrinking = false;
        }
    }

    private void EmptyMix() {
        if (Vector3.Dot(transform.forward, Vector3.down) > pouringThreshhold) {

            if (CompareLists() && isDrinking) {
                GameWon();
            }
            else if (!CompareLists() && isDrinking) {
                Debug.Log("wrong solution");
                //DrinkWrongSolution();
            }

            currentSolution = "";

            solutionList.Clear();
            solutionMesh.SetActive(false);
        }
    }

    void AddSolution(GameObject flask) {
        FlaskManager fm = flask.GetComponent<FlaskManager>();
        solutionMesh.GetComponent<Renderer>().material.color = fm.color;

        if (solutionList.Count == 0) {
            solutionMesh.SetActive(true);
        }

        if (!solutionList.Contains(flask)) {
            solutionList.Add(flask);
            currentSolution = currentSolution + "\n" + fm.ChemFormula;
            current.GetComponent<TextMeshProUGUI>().text = "Current Solution" + "\n" + currentSolution;
        }
    }

    bool CompareLists() {
        if (solutionList.OrderBy(go => go.name).SequenceEqual(correctSolutionList.OrderBy(go => go.name))) {
            return true;
        }
        else {
            return false;
        }
    }
    
    void DrinkWrongSolution() {
        XROrigin.GetComponent<ShrinkManager>().IncreaseShrinkSpeed();
    }

    void GameWon() {
        Debug.Log("Game Won");
        current.GetComponent<TextMeshProUGUI>().text = "CONGRATULATIONS!!!" + "\n" + "You solved the mystery!";
        XROrigin.GetComponent<ShrinkManager>().StopAllCoroutines();
        
        IEnumerator WaitAndExecute()
        {
            yield return new WaitForSeconds(10f);
            SceneManager.LoadScene(0);
        }
        StartCoroutine(WaitAndExecute());
    }
}
