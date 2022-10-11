using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Linq;

public class VSData : MonoBehaviour
{
    public static string VPN;
    static string fileName;
    public static string filePath;
    public static List<StringBuilder> results = new List<StringBuilder>();


    public static StringBuilder header = new StringBuilder();
    public static StringBuilder practice = new StringBuilder();

    public static StringBuilder practiceOne = new StringBuilder();
    public static StringBuilder practiceTwo = new StringBuilder();
    public static StringBuilder testOne = new StringBuilder();
    public static StringBuilder testTwo = new StringBuilder();
    public static StringBuilder testThree = new StringBuilder();
    public static StringBuilder testFour = new StringBuilder();
    public static StringBuilder testFive = new StringBuilder();
    public static StringBuilder testSix = new StringBuilder();
    public static StringBuilder testSeven = new StringBuilder();
    public static StringBuilder testEigth = new StringBuilder();
    public static StringBuilder totalTask = new StringBuilder();
    int i = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneSwitch.reverseVS == true)
        {
            fileName = "VPN" + VPN + "_VerbalSP_backwards.csv";
            fileName = checkFilenameReverse(fileName);
        }
        else
        {
            fileName = "VPN" + VPN + "_VerbalSP_forward.csv";
            fileName = checkFilename(fileName);
        }

        filePath = Path.Combine(Application.persistentDataPath, fileName);

        header.Append("Participant's ID," + "Date," + "Time" + "\n" + VPN + "," + System.DateTime.Now.ToString("dd/MM/yyyy") + "," + System.DateTime.Now.ToString("HH:mm:ss") + "\n\n");
        header.Append("Experimental Phase, Trial Number, Span Length, CRESP1,CRESP2,CRESP3,CRESP4,CRESP5,CRESP6,CRESP7,CRESP8,RESP1,RESP2,RESP3,RESP4,RESP5,RESP6,RESP7,RESP8,Reaction accuracy\n");

        results.Add(header);
        results.Add(practiceOne);
        results.Add(practiceTwo);
        results.Add(testOne);
        results.Add(testTwo);
        results.Add(testThree);
        results.Add(testFour);
        results.Add(testFive);
        results.Add(testSix);
        results.Add(testSeven);
        results.Add(testEigth);
        totalTask.Append("\n\nTotal numbers of correct sequences: " + VSTest.accuracy.ToString());
        results.Add(totalTask);
        File.WriteAllText(filePath, ListToString(results));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string checkFilename(string fileName)
    {
        while (File.Exists(Path.Combine(Application.persistentDataPath, fileName)))
        {
            fileName = "VPN" + VPN + "(" + i + ")" + "_VerbalSP_forward.csv";
            i++;
        }
        return fileName;
    }
    public string checkFilenameReverse(string fileName)
    {
        while (File.Exists(Path.Combine(Application.persistentDataPath, fileName)))
        {
            fileName = "VPN" + VPN + "(" + i + ")" + "_VerbalSP_backwards.csv";
            i++;
        }
        return fileName;
    }
    private string ListToString(List<StringBuilder> results)
    {
        string x = "";
        foreach (var element in results)
        {
            x = x + element.ToString();
        }

        return x;
    }

    public static void MeasurePracticeSequenzOne(int phase, int trial, int length, string crespOne, string respOne, int accuracy)
    {
        practiceOne.AppendFormat("{0},{1},{2},{3},,,,,,,,{4},,,,,,,,{5}\n", phase, trial, length, crespOne, respOne, accuracy);
    }
    public static void MeasurePracticeSequenzTwo(int phase, int trial, int length, string crespOne, string crespTwo, string respOne, string respTwo, int accuracy)
    {
        practiceTwo.AppendFormat("{0},{1},{2},{3},{4},,,,,,,{5},{6},,,,,,,{7}\n", phase, trial, length, crespOne, crespTwo, respOne, respTwo, accuracy);
    }
    public static void MeasureSequenzOne(int phase, int trial, int length, string crespOne, string respOne, int accuracy)
    {
        testOne.AppendFormat("{0},{1},{2},{3},,,,,,,,{4},,,,,,,,{5}\n", phase, trial, length, crespOne, respOne, accuracy);
    }
    public static void MeasureSequenzTwo(int phase, int trial, int length, string crespOne, string crespTwo, string respOne, string respTwo, int accuracy)
    {
        testTwo.AppendFormat("{0},{1},{2},{3},{4},,,,,,,{5},{6},,,,,,,{7}\n", phase, trial, length, crespOne,crespTwo, respOne, respTwo, accuracy);
    }
    public static void MeasureSequenzThree(int phase, int trial, int length, string crespOne, string crespTwo, string crespThree, string respOne, string respTwo, string respThree, int accuracy)
    {
        testThree.AppendFormat("{0},{1},{2},{3},{4},{5},,,,,,{6},{7},{8},,,,,,{9}\n", phase, trial, length, crespOne, crespTwo, crespThree, respOne, respTwo, respThree , accuracy);
    }
    public static void MeasureSequenzFour(int phase, int trial, int length, string crespOne, string crespTwo, string crespThree,string crespFour, string respOne, string respTwo, string respThree,string respFour, int accuracy)
    {
        testFour.AppendFormat("{0},{1},{2},{3},{4},{5},{6},,,,,{7},{8},{9},{10},,,,,{11}\n", phase, trial, length, crespOne, crespTwo, crespThree, crespFour,respOne, respTwo, respThree, respFour, accuracy);
    }
    public static void MeasureSequenzFive(int phase, int trial, int length, string crespOne, string crespTwo, string crespThree, string crespFour, string crespFive, string respOne, string respTwo, string respThree, 
        string respFour, string respFive, int accuracy)
    {
        testFive.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},,,,{8},{9},{10},{11},{12},,,,{13}\n", phase, trial, length, crespOne, crespTwo, crespThree, crespFour,crespFive, respOne, respTwo, respThree, respFour, respFive, accuracy);
    }
    public static void MeasureSequenzSix(int phase, int trial, int length, string crespOne, string crespTwo, string crespThree, string crespFour, string crespFive, string crespSix, string respOne, string respTwo, string respThree,
        string respFour, string respFive, string respSix, int accuracy)
    {
        testSix.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},,,{9},{10},{11},{12},{13},{14},,,{15}\n", phase, trial, length, crespOne, crespTwo, crespThree, crespFour, crespFive, crespSix,
            respOne, respTwo, respThree, respFour, respFive, respSix, accuracy);
    }
    public static void MeasureSequenzSeven(int phase, int trial, int length, string crespOne, string crespTwo, string crespThree, string crespFour, string crespFive, string crespSix, string crespSeven, string respOne, string respTwo, string respThree,
        string respFour, string respFive, string respSix, string respSeven, int accuracy)
    {
        testSeven.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},,{10},{11},{12},{13},{14},{15},{16},,{17}\n", phase, trial, length, crespOne, crespTwo, crespThree, crespFour, crespFive, crespSix, crespSeven,
            respOne, respTwo, respThree, respFour, respFive, respSix, respSeven, accuracy);
    }
    public static void MeasureSequenzEight(int phase, int trial, int length, string crespOne, string crespTwo, string crespThree, string crespFour, string crespFive, string crespSix, string crespSeven, string crespEight,string respOne, string respTwo, string respThree,
        string respFour, string respFive, string respSix, string respSeven, string respEight, int accuracy)
    {
        testEigth.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19}\n", phase, trial, length, crespOne, crespTwo, crespThree, crespFour, crespFive, crespSix, crespSeven,
            respOne, respTwo, respThree, respFour, respFive, respSix, respSeven, respEight, accuracy);
    }
}
