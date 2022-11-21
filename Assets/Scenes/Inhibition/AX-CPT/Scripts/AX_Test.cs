using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Diagnostics;
using Debug = UnityEngine.Debug;


public class AX_Test : MonoBehaviour
{
    [SerializeField] List<GameObject> introUI = new List<GameObject>();
    public GameObject continueButton;
    public GameObject correct;
    public GameObject incorrect;

    public GameObject fixCross;
    public GameObject redDot;
    public GameObject greenDot;

    public GameObject Brille;
    public GameObject Hut;
    public GameObject Buch;
    public GameObject Besen;

    public static Stopwatch timer = new Stopwatch();

    private GameObject currentFirst;
    private GameObject currentSecond;

    public int trialNum;
    public string trialType;
    public string cueProbe;
    string cresp;
    bool enableTask;

    public int blockNum;
    public AudioSource Ax_CPT_04mp3;
    public AudioSource Ax_CPT_05mp3;
    public int wrongTask;

    public string response;
    public static int hits;
    public static int misses;
    public static int errors;

    private int exit;

    private void Start()
    {
        exit = 0;
        hits = 0;
        errors = 0;
        misses = 0;
        blockNum = 1;
        wrongTask = 0;
        enableTask = false;
        trialNum = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer.ElapsedMilliseconds >= 1000)
        {
            timer.Stop();
            Compare("0");
        }
    }

    public void PressButton(GameObject button)
    {
        if (button.name == "greenDot")
        {
            Compare("Gruen");
        }
        if (button.name == "redDot")
        {
            Compare("Rot");
        }
    }
    private void CurrentTrial(int trial)
    {
        if (trial == 1)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 2)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 3)
        {
            StartCoroutine(TaskAnimation(Hut,Besen));
        }
        if (trial == 4)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 5)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 6)
        {
            StartCoroutine(TaskAnimation(Hut, Buch));
        }
        if (trial == 7)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 8)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 9)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 10)
        {
            StartCoroutine(TaskAnimation(Hut, Buch));
        }
        if (trial == 11)
        {
            StartCoroutine(TaskAnimation(Brille, Besen));
        }
        if (trial == 12)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 13)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 14)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 15)
        {
            StartCoroutine(TaskAnimation(Brille, Besen));
        }
        if (trial == 16)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 17)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 18)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 19)
        {
            StartCoroutine(TaskAnimation(Hut, Besen));
        }
        if (trial == 20)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 21)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 22)
        {
            StartCoroutine(TaskAnimation(Hut, Besen));
        }
        if (trial == 23)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 24)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 25)
        {
            StartCoroutine(TaskAnimation(Brille, Besen));
        }
        if (trial == 26)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 27)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 28)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 29)
        {
            StartCoroutine(TaskAnimation(Hut, Buch));
        }
        if (trial == 30)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 31 && blockNum == 2)
        {
            Ax_CPT_05mp3.Play();
            continueButton.SetActive(true);
            DespawnOld();
            // hier block num erhoehen und audio abspielen + continue button einfuegen
            // buff variable in der if abfrage! bzw block als buff var nehmen
        }
        // Block 2
        if (trial == 31 && blockNum == 3)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 32)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 33)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 34)
        {
            StartCoroutine(TaskAnimation(Brille, Besen));
        }
        if (trial == 35)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 36)
        {
            StartCoroutine(TaskAnimation(Hut, Buch));
        }
        if (trial == 37)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 38)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 39)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 40)
        {
            StartCoroutine(TaskAnimation(Hut, Buch));
        }
        if (trial == 41)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 42)
        {
            StartCoroutine(TaskAnimation(Brille, Besen));
        }
        if (trial == 43)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 44)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 45)
        {
            StartCoroutine(TaskAnimation(Hut, Besen));
        }
        if (trial == 46)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 47)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 48)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 49)
        {
            StartCoroutine(TaskAnimation(Hut, Besen));
        }
        if (trial == 50)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 51)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 52)
        {
            StartCoroutine(TaskAnimation(Hut, Buch));
        }
        if (trial == 53)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 54)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 55)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 56)
        {
            StartCoroutine(TaskAnimation(Brille, Besen));
        }
        if (trial == 57)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 58)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 59)
        {
            StartCoroutine(TaskAnimation(Hut, Besen));
        }
        if (trial == 60)
        {
            StartCoroutine(TaskAnimation(Brille, Buch));
        }
        if (trial == 61 && blockNum == 3)
        {
            Debug.Log("Finish");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    private void NextTrial(int trial)
    {
        CurrentTrial(trial);
    }
    private void Compare(string s)
    {
        response = s;
        if (cueProbe == "AX")
        {
            cresp = "Gruen";
        }
        else
        {
            cresp = "Rot";
        }

        timer.Stop();
        if ((s == "Gruen" && cueProbe == "AX") || (s == "Rot" && cueProbe != "AX"))
        {
            Debug.Log("True");
            WriteInDataSaver(blockNum, trialNum, currentFirst.name, currentSecond.name, cresp, s, trialType, timer.ElapsedMilliseconds, 1);
            StartCoroutine(CorrectAnimation());
            trialNum++;
        }
        else
        {
            Debug.Log("False");
            WriteInDataSaver(blockNum, trialNum, currentFirst.name, currentSecond.name, cresp, s, trialType, timer.ElapsedMilliseconds, 0);
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
        hits++;
        DespawnOld();
        correct.SetActive(true);
        yield return new WaitForSeconds(.5f);
        correct.SetActive(false);
        NextTrial(trialNum);
    }
    IEnumerator InCorrectAnimation()
    {
        if(response == "0")
        {
            misses++;
        }
        else
        {
            errors++;
        }
        DespawnOld();
        incorrect.SetActive(true);
        yield return new WaitForSeconds(.5f);
        incorrect.SetActive(false);
        NextTrial(trialNum);
    }
    private void SetTrialType()
    {
        if (cueProbe == "AX") trialType = "AX";
        if (cueProbe == "AY") trialType = "AY";
        if (cueProbe == "BX") trialType = "BX";
        if (cueProbe == "BY") trialType = "BY";
    }
    IEnumerator TaskAnimation(GameObject first, GameObject second)
    {

        if (first.name == "Brille" && second.name == "Buch") cueProbe = "AX";
        if (first.name == "Brille" && second.name == "Besen") cueProbe = "AY";
        if (first.name == "Hut" && second.name == "Buch") cueProbe = "BX";
        if (first.name == "Hut" && second.name == "Besen") cueProbe = "BY";
        //cueProbe = first.name + second.name;
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
    public void StartGame()
    {
        foreach (var i in introUI)
        {
            i.SetActive(false);
        }
        blockNum++;
        CurrentTrial(trialNum);
    }
    public void BackToIntro()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void GoToOutro()
    {
        exit++;
        if (exit == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
    void WriteInDataSaver(int blockNumber,int trial, string cue, string probe, string cresp, string subResp, string trialType, float time, int accuracy)
    {
        AX_Data.MeasureTest(blockNumber, trial, cue, probe, cresp, subResp, trialType, time, accuracy);
    }
}
