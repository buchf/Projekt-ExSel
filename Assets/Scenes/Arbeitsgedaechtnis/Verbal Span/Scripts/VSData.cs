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

    public static StringBuilder timePointsts = new StringBuilder();
    public static StringBuilder overall = new StringBuilder();

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
    int i = 1;

    public static double totalTime;

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


        timePointsts.Append(VPN + ",Total score:," + VSTest.accuracy.ToString() + ",Date:," + System.DateTime.Now.ToString("dd/MM/yyyy") + ",Time:," + System.DateTime.Now.ToString("HH:mm:ss") + "\n\n");

        if (SceneSwitch.reverseVS == true)
        {
            overall.Append("Task:,Verbal Span reverse\nCorrect Sequences:," + VSTest.accuracy.ToString() + "\nPresented sequences:," + VSTest.presentedTasks.ToString() + "\nTotal time (in ms):," + totalTime.ToString("0", System.Globalization.CultureInfo.InvariantCulture) + "\n\n\n");
        }
        else
        {
            overall.Append("Task:,Verbal Span\nCorrect Sequences:," + VSTest.accuracy.ToString() + "\nPresented sequences:," + VSTest.presentedTasks.ToString() + "\nTotal time (in ms):," + totalTime + "\n\n\n");
        }
        

        header.Append("VP_ID,Correct response,RT (in ms), Block (i.e. sequence length),Trial,Target1,Target2,Target3,Target4,Target5,Target6,Target7,Target8,RESP1,RESP2,RESP3,RESP4,RESP5,RESP6,RESP7,RESP8\n");

        results.Add(timePointsts);
        results.Add(overall);
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
    /*
    public static void MeasurePracticeSequenzOne(int phase, int trial, int length, string crespOne, string respOne, int accuracy, double reaction)
    {
        practiceOne.AppendFormat(VPN + ",{0},{1},{2},{3},,,,,,,,{4},,,,,,,,{5}\n", accuracy, reaction, trial, length, crespOne, respOne, accuracy);
    }
    public static void MeasurePracticeSequenzTwo(int phase, int trial, int length, string crespOne, string crespTwo, string respOne, string respTwo, int accuracy, double reaction)
    {
        practiceTwo.AppendFormat(VPN + ",{0},{1},{2},{3},{4},,,,,,,{5},{6},,,,,,,{7}\n", phase, trial, length, crespOne, crespTwo, respOne, respTwo, accuracy);
    } */

    public static void MeasureSequenzOne(int phase, int trial, int length, string crespOne, string respOne, int accuracy, double reaction)
    {
        testOne.AppendFormat(VPN + ",{0},0,{1},{2},{3},,,,,,,,{4}\n", accuracy, length, trial, crespOne, respOne);
    }
    public static void MeasureSequenzTwo(int phase, int trial, int length, string crespOne, string crespTwo, string respOne, string respTwo, int accuracy, double reaction)
    {
        testTwo.AppendFormat(VPN + ",{0},{1},{2},{3},{4},{5},,,,,,,{6},{7}\n", accuracy, reaction.ToString("0", System.Globalization.CultureInfo.InvariantCulture), length, trial, crespOne,crespTwo, respOne, respTwo);
    }
    public static void MeasureSequenzThree(int phase, int trial, int length, string crespOne, string crespTwo, string crespThree, string respOne, string respTwo, string respThree, int accuracy, double reaction)
    {
        testThree.AppendFormat(VPN + ",{0},{1},{2},{3},{4},{5},{6},,,,,,{7},{8},{9}\n", accuracy, reaction.ToString("0", System.Globalization.CultureInfo.InvariantCulture), length, trial, crespOne, crespTwo, crespThree, respOne, respTwo, respThree);
    }
    public static void MeasureSequenzFour(int phase, int trial, int length, string crespOne, string crespTwo, string crespThree,string crespFour, string respOne, string respTwo, string respThree,string respFour, int accuracy, double reaction)
    {
        testFour.AppendFormat(VPN + ",{0},{1},{2},{3},{4},{5},{6},{7},,,,,{8},{9},{10},{11}\n", accuracy, reaction.ToString("0", System.Globalization.CultureInfo.InvariantCulture), length, trial, crespOne, crespTwo, crespThree, crespFour,respOne, respTwo, respThree, respFour);
    }
    public static void MeasureSequenzFive(int phase, int trial, int length, string crespOne, string crespTwo, string crespThree, string crespFour, string crespFive, string respOne, string respTwo, string respThree, 
        string respFour, string respFive, int accuracy, double reaction)
    {
        testFive.AppendFormat(VPN + ",{0},{1},{2},{3},{4},{5},{6},{7},{8},,,,{9},{10},{11},{12},{13}\n", accuracy, reaction.ToString("0", System.Globalization.CultureInfo.InvariantCulture), length, trial, crespOne, crespTwo, crespThree, crespFour,crespFive, respOne, respTwo, respThree, respFour, respFive);
    }
    public static void MeasureSequenzSix(int phase, int trial, int length, string crespOne, string crespTwo, string crespThree, string crespFour, string crespFive, string crespSix, string respOne, string respTwo, string respThree,
        string respFour, string respFive, string respSix, int accuracy, double reaction)
    {
        testSix.AppendFormat(VPN + ",{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},,,{10},{11},{12},{13},{14},{15}\n", accuracy, reaction.ToString("0", System.Globalization.CultureInfo.InvariantCulture), length, trial, crespOne, crespTwo, crespThree, crespFour, crespFive, crespSix,
            respOne, respTwo, respThree, respFour, respFive, respSix);
    }
    public static void MeasureSequenzSeven(int phase, int trial, int length, string crespOne, string crespTwo, string crespThree, string crespFour, string crespFive, string crespSix, string crespSeven, string respOne, string respTwo, string respThree,
        string respFour, string respFive, string respSix, string respSeven, int accuracy, double reaction)
    {
        testSeven.AppendFormat(VPN + ",{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},,{11},{12},{13},{14},{15},{16},{17}\n", accuracy, reaction.ToString("0", System.Globalization.CultureInfo.InvariantCulture), length, trial, crespOne, crespTwo, crespThree, crespFour, crespFive, crespSix, crespSeven,
            respOne, respTwo, respThree, respFour, respFive, respSix, respSeven);
    }
    public static void MeasureSequenzEight(int phase, int trial, int length, string crespOne, string crespTwo, string crespThree, string crespFour, string crespFive, string crespSix, string crespSeven, string crespEight,string respOne, string respTwo, string respThree,
        string respFour, string respFive, string respSix, string respSeven, string respEight, int accuracy, double reaction)
    {
        testEigth.AppendFormat(VPN + ",{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19}\n", accuracy, reaction.ToString("0", System.Globalization.CultureInfo.InvariantCulture), length, trial, crespOne, crespTwo, crespThree, crespFour, crespFive, crespSix, crespSeven,
            crespEight, respOne, respTwo, respThree, respFour, respFive, respSix, respSeven, respEight);
    }
}
