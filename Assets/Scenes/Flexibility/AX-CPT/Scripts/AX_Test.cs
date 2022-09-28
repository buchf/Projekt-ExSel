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
    public GameObject continueText;
    public GameObject continueButton;
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

    public int blockNum;
    public AudioSource Ax_CPT_04mp3;
    public AudioSource Ax_CPT_05mp3;
    public int wrongTask;

    public string response;
    public static int hits;
    public static int misses;
    public static int errors;

    private void Start()
    {
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
        if (timer.ElapsedMilliseconds >= 3500)
        {
            Compare("0");
        }
    }

    public void PressButton(GameObject button)
    {
        if (button.name == "greenDot")
        {
            Compare("L");
        }
        if (button.name == "redDot")
        {
            Compare("D");
        }
    }
    private void CurrentTrial(int trial)
    {
        if (trial == 1)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 2)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 3)
        {
            StartCoroutine(TaskAnimation(B,Y));
        }
        if (trial == 4)
        {
            StartCoroutine(TaskAnimation(A, X));
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
            StartCoroutine(TaskAnimation(B, X));
        }
        if (trial == 11)
        {
            StartCoroutine(TaskAnimation(A, Y));
        }
        if (trial == 12)
        {
            StartCoroutine(TaskAnimation(A, X));
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
            StartCoroutine(TaskAnimation(A, Y));
        }
        if (trial == 16)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 17)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 18)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 19)
        {
            StartCoroutine(TaskAnimation(B, Y));
        }
        if (trial == 20)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 21)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 22)
        {
            StartCoroutine(TaskAnimation(B, Y));
        }
        if (trial == 23)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 24)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 25)
        {
            StartCoroutine(TaskAnimation(A, Y));
        }
        if (trial == 26)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 27)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 28)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 29)
        {
            StartCoroutine(TaskAnimation(B, X));
        }
        if (trial == 30)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 31 && blockNum == 2)
        {
            Ax_CPT_05mp3.Play();
            continueButton.SetActive(true);
            continueText.SetActive(true);
            DespawnOld();
            // hier block num erhoehen und audio abspielen + continue button einfuegen
            // buff variable in der if abfrage! bzw block als buff var nehmen
        }
        // Block 2
        if (trial == 31 && blockNum == 3)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 32)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 33)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 34)
        {
            StartCoroutine(TaskAnimation(A, Y));
        }
        if (trial == 35)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 36)
        {
            StartCoroutine(TaskAnimation(B, X));
        }
        if (trial == 37)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 38)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 39)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 40)
        {
            StartCoroutine(TaskAnimation(B, X));
        }
        if (trial == 41)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 42)
        {
            StartCoroutine(TaskAnimation(A, Y));
        }
        if (trial == 43)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 44)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 45)
        {
            StartCoroutine(TaskAnimation(B, Y));
        }
        if (trial == 46)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 47)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 48)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 49)
        {
            StartCoroutine(TaskAnimation(B, Y));
        }
        if (trial == 50)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 51)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 52)
        {
            StartCoroutine(TaskAnimation(B, X));
        }
        if (trial == 53)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 54)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 55)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 56)
        {
            StartCoroutine(TaskAnimation(A, Y));
        }
        if (trial == 57)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 58)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 59)
        {
            StartCoroutine(TaskAnimation(B, Y));
        }
        if (trial == 60)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 61 && blockNum == 3)
        {
            Ax_CPT_05mp3.Play();
            continueButton.SetActive(true);
            continueText.SetActive(true);
            DespawnOld();
            // hier block num erhoehen und audio abspielen + continue button einfuegen
            // buff variable in der if abfrage! bzw block als buff var nehmen
        }
        if (trial == 61 && blockNum ==4)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 62)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 63)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 64)
        {
            StartCoroutine(TaskAnimation(B, X));
        }
        if (trial == 65)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 66)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 66)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 67)
        {
            StartCoroutine(TaskAnimation(A, Y));
        }
        if (trial == 68)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 69)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 70)
        {
            StartCoroutine(TaskAnimation(B, X));
        }
        if (trial == 71)
        {
            StartCoroutine(TaskAnimation(B, X));
        }
        if (trial == 72)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 73)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 74)
        {
            StartCoroutine(TaskAnimation(B, Y));
        }
        if (trial == 75)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 76)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 77)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 78)
        {
            StartCoroutine(TaskAnimation(A, Y));
        }
        if (trial == 79)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 80)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 81)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 82)
        {
            StartCoroutine(TaskAnimation(A, Y));
        }
        if (trial == 83)
        {
            StartCoroutine(TaskAnimation(B, Y));
        }
        if (trial == 84)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 85)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 86)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 87)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 88)
        {
            StartCoroutine(TaskAnimation(B, Y));
        }
        if (trial == 89)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 90)
        {
            StartCoroutine(TaskAnimation(A, X));
        }
        if (trial == 91)
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
            cresp = "L";
        }
        else
        {
            cresp = "D";
        }

        timer.Stop();
        if ((s == "L" && cueProbe == "AX") || (s == "D" && cueProbe != "AX"))
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void WriteInDataSaver(int blockNumber,int trial, string cue, string probe, string cresp, string subResp, int trialType, float time, int accuracy)
    {
        AX_Data.MeasureTest(1, blockNumber, trial, cue, probe, cresp, subResp, trialType, time, accuracy);
    }
}
