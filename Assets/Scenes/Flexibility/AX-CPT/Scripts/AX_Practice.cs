using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Diagnostics;
using Debug = UnityEngine.Debug;


public class AX_Practice : MonoBehaviour
{
    [SerializeField] List<GameObject> introUI = new List<GameObject>();
    public GameObject correct;
    public GameObject incorrect;

    public GameObject fixCross;
    public GameObject redDot;
    public GameObject greenDot;

    public GameObject A;
    public GameObject B;
    public GameObject X;
    public GameObject Y;

    public static Stopwatch timer = new Stopwatch();

    private GameObject currentFirst;
    private GameObject currentSecond;

    public int trialNum;
    public int trialType;
    public string cueProbe;
    string cresp;
    bool enableTask;

    public int wrongTask;
    private void Start()
    {
        wrongTask = 0;
        enableTask = false;
        trialNum = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if(timer.Elapsed.Seconds >= 5)
        {
            Compare("0");
        }

        if (Input.GetKeyDown("d") && enableTask)
        {
            Compare("D");
        }

        if (Input.GetKeyDown("l") && enableTask)
        {
            Compare("L");
        }
    }

    private void CurrentTrial(int trial)
    {
        if(trial == 1)
        {
            StartCoroutine(TaskAnimation(A,X));
        }
        if (trial == 2)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 3)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 4)
        {
            StartCoroutine(TaskAnimation(A, Y));
        }
        if (trial == 5)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 6)
        {
            StartCoroutine(TaskAnimation(B, X));
        }
        if (trial == 7)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 8)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 9)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 10)
        {
            StartCoroutine(TaskAnimation(A, Y));
        }
        if (trial == 11)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 12)
        {
            StartCoroutine(TaskAnimation(B, Y));
        }
        if (trial == 13)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 14)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 15)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 16)
        {
            StartCoroutine(TaskAnimation(B, X));
        }
        if (trial == 17)
        {
            StartCoroutine(TaskAnimation(B, Y));
        }
        if (trial == 18)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 19)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 20)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if(trial == 21)
        {
            if(wrongTask >=5 )
            {
                //clear practice Data and reload the practice scene
                AX_Data.practice.Clear();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                Debug.Log("Next Scene");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    private void NextTrial(int trial)
    {
        CurrentTrial(trial);
    }
    private void Compare(string s)
    {
        if (cueProbe == "AX")
        {
            cresp = "L";
        }
        else
        {
            cresp = "D"; 
        }

        timer.Stop();
        if((s == "L" && cueProbe == "AX") || (s == "D" && cueProbe != "AX"))
        {
            Debug.Log("True");
            WriteInDataSaver(trialNum, currentFirst.name, currentSecond.name, cresp, s, trialType, timer.ElapsedMilliseconds, 1);
            StartCoroutine(CorrectAnimation());
            trialNum++;
        }
        else
        {
            Debug.Log("False");
            WriteInDataSaver(trialNum, currentFirst.name, currentSecond.name, cresp, s, trialType, timer.ElapsedMilliseconds, 0);
            StartCoroutine(InCorrectAnimation());
            wrongTask++;
            trialNum++;
        }
        enableTask = false;
        timer.Reset();
    }

    private void DespawnOld()
    {
        currentSecond.SetActive(false);
        redDot.SetActive(false);
        greenDot.SetActive(false);

    }
    IEnumerator CorrectAnimation()
    {
        DespawnOld();
        correct.SetActive(true);
        yield return new WaitForSeconds(.5f);
        correct.SetActive(false);
        NextTrial(trialNum);
    }
    IEnumerator InCorrectAnimation()
    {
        DespawnOld();
        incorrect.SetActive(true);
        yield return new WaitForSeconds(.5f);
        incorrect.SetActive(false);
        NextTrial(trialNum);
    }
    private void SetTrialType()
    {
        if (cueProbe == "AX") trialType = 1;
        if (cueProbe == "AY") trialType = 2;
        if (cueProbe == "BX") trialType = 3;
        if (cueProbe == "BY") trialType = 4;
    }
    IEnumerator TaskAnimation(GameObject first, GameObject second)
    {
        cueProbe = first.name + second.name;
        currentFirst = first;
        currentSecond = second;
        SetTrialType();
        yield return new WaitForSeconds(0.5f);
        fixCross.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        fixCross.SetActive(false);
        first.SetActive(true);
        yield return new WaitForSeconds(1f);
        first.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        second.SetActive(true);
        greenDot.SetActive(true);
        redDot.SetActive(true);
        timer.Start();
        enableTask = true;
    }
    public void StartPractice()
    {
        foreach(var i in introUI)
        {
            i.SetActive(false);
        }
        CurrentTrial(trialNum);
    }
    public void BackToIntro()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    void WriteInDataSaver(int trial, string cue, string probe, string cresp, string subResp, int trialType, float time, int accuracy)
    {
        AX_Data.MeasurePractice(0,1,trial,cue,probe,cresp,subResp,trialType, time, accuracy);
    }
}
