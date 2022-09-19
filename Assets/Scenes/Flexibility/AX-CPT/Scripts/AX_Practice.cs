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
    int buff = 0;
    public string cueProbe;

    bool enableTask;
    private void Start()
    {
        enableTask = false;
        trialNum = 1;
        buff = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(timer.Elapsed.Seconds > 5)
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
    }

    private void NextTrial(int trial)
    {
        CurrentTrial(trial);
    }
    private void Compare(string s)
    {
        timer.Stop();
        if((s == "L" && cueProbe == "AX") || (s == "D" && cueProbe != "AX"))
        {
            Debug.Log("True");
            StartCoroutine(CorrectAnimation());
            buff = 0;
            trialNum++;
        }
        else
        {
            Debug.Log("False");
            StartCoroutine(InCorrectAnimation());
            if(buff == 1)
            {
                trialNum++;
                buff = 0;
            }
            else
            {
                buff++;
            }
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
    IEnumerator TaskAnimation(GameObject first, GameObject second)
    {
        cueProbe = first.name + second.name;
        currentFirst = first;
        currentSecond = second;
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
}
