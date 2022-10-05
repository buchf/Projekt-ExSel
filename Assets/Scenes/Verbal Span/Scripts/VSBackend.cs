using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class VSBackend : MonoBehaviour
{
    public List<GameObject> sequenzList = new List<GameObject>();
    public List<GameObject> clickedList = new List<GameObject>();

    public static Stopwatch timer = new Stopwatch();


    public int listCompareVar;
    public static int expPhase = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void ClearLists()
    {


        if (SceneSwitch.reverseVS == true)
        {
            CompareListsReverse();
        }
        else
        {
            CompareLists();
        }

        Debug.Log("Compare: " + listCompareVar);
        sequenzList.Clear();
        clickedList.Clear();
    }

    public void CompareLists()
    {
        int trial;
        if (expPhase == 0)
        {
            trial = VSPractice.currentTrial;
        }
        else
        {
            trial = VSTest.currentTrial;
        }
        
        int x = clickedList.Count;
        int y = sequenzList.Count;
        string[] crespList = { "0", "0", "0", "0", "0", "0", "0", "0" };
        string[] respList = { "0", "0", "0", "0", "0", "0", "0", "0" };

        listCompareVar = 1;

        for (int i = 0; i < x; i++)
        {
            crespList[i] = sequenzList[i].gameObject.name;
            respList[i] = clickedList[i].gameObject.name;
        }

        if (x != y)
        {
            listCompareVar = 0;
        }

        for (int i = 0; i < x; i++)
        {
            if (clickedList[i] == sequenzList[i])
            {
                //accuracyCounter++;
            }


            if (clickedList[i] != sequenzList[i])
            {
                listCompareVar = 0;
            }
        }
        if (listCompareVar == 0) VSTest.wrongCounter++;
        if (listCompareVar == 1) VSTest.accuracy++;
        WriteInDataSaver(expPhase, trial, y, crespList[0], crespList[1], crespList[2], crespList[3], crespList[4], crespList[5], crespList[6], crespList[7], respList[0], respList[1], respList[2], respList[3], respList[4], respList[5], respList[6], respList[7], listCompareVar);
    }

    public void CompareListsReverse()
    {
        int trial;
        if (expPhase == 0)
        {
            trial = VSPractice.currentTrial;
        }
        else
        {
            trial = VSTest.currentTrial;
        }
        int x = clickedList.Count;
        int y = sequenzList.Count;
        string[] crespList = { "0", "0", "0", "0", "0", "0", "0", "0" };
        string[] respList = { "0", "0", "0", "0", "0", "0", "0", "0" };

        int j = sequenzList.Count - 1;
        listCompareVar = 1;

        for (int i = 0; i < x; i++)
        {
            crespList[i] = sequenzList[y-1-i].gameObject.name;
            respList[i] = clickedList[i].gameObject.name;
        }

        if (x != y)
        {
            listCompareVar = 0;
        }

        for (int i = 0; i < x; i++)
        {
            if (clickedList[i] == sequenzList[j])
            {

            }


            if (clickedList[i] != sequenzList[j])
            {
                listCompareVar = 0;
            }
            j--;
        }

        if (listCompareVar == 0) VSTest.wrongCounter++;
        if (listCompareVar == 1) VSTest.accuracy++;
        WriteInDataSaver(expPhase, trial, y, crespList[0], crespList[1], crespList[2], crespList[3], crespList[4], crespList[5], crespList[6], crespList[7], respList[0], respList[1], respList[2], respList[3], respList[4], respList[5], respList[6], respList[7], listCompareVar);
    }
    private void WriteInDataSaver(int phase, int trial, int sequenzlenght, string crespOne, string crespTwo, string crespThree, string crespFour, string crespFive, string crespSix,
        string crespSeven, string crespEight, string respOne, string respTwo, string respThree, string respFour, string respFive, string respSix, string respSeven, string respEight, int accuracy)
    {
        if (sequenzlenght == 1)
        {
            if (phase == 0) VSData.MeasurePracticeSequenzOne(phase, trial, sequenzlenght, crespOne, respOne, accuracy);
            if (phase == 1) VSData.MeasureSequenzOne(phase, trial, sequenzlenght, crespOne, respOne, accuracy);
        }
        if (sequenzlenght == 2)
        {
            if (phase == 0) VSData.MeasurePracticeSequenzTwo(phase, trial, sequenzlenght, crespOne, crespTwo, respOne, respTwo, accuracy);
            if (phase == 1) VSData.MeasureSequenzTwo(phase, trial, sequenzlenght, crespOne, crespTwo, respOne, respTwo, accuracy);
        }
        if (sequenzlenght == 3) VSData.MeasureSequenzThree(phase, trial, sequenzlenght, crespOne, crespTwo, crespThree, respOne, respTwo, respThree, accuracy);
        if (sequenzlenght == 4) VSData.MeasureSequenzFour(phase, trial, sequenzlenght, crespOne, crespTwo, crespThree, crespFour, respOne, respTwo, respThree, respFour, accuracy);
        if (sequenzlenght == 5) VSData.MeasureSequenzFive(phase, trial, sequenzlenght, crespOne, crespTwo, crespThree, crespFour, crespFive, respOne, respTwo, respThree, respFour, respFive, accuracy);
        if (sequenzlenght == 6) VSData.MeasureSequenzSix(phase, trial, sequenzlenght, crespOne, crespTwo, crespThree, crespFour, crespFive, crespSix, respOne, respTwo, respThree, respFour, respFive, respSix, accuracy);
        if (sequenzlenght == 7) VSData.MeasureSequenzSeven(phase, trial, sequenzlenght, crespOne, crespTwo, crespThree, crespFour, crespFive, crespSix, crespSeven, respOne, respTwo, respThree, respFour, respFive, respSix, respSeven, accuracy);
        if (sequenzlenght == 8) VSData.MeasureSequenzEight(phase, trial, sequenzlenght, crespOne, crespTwo, crespThree, crespFour, crespFive, crespSix, crespSeven, crespEight, respOne, respTwo, respThree, respFour, respFive, respSix, respSeven, respEight, accuracy);
    }
}
