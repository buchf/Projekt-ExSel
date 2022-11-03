using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Linq;


public class WCST_Data : MonoBehaviour
{
    public static string VPN;
    static string fileName;
    public static string filePath;

    int cresp = 0;
    int gesamtpunktzahl = 0;
    int preservationErrors = 0;
    int errors = 0;

    public static StringBuilder timePointsts = new StringBuilder();
    public static StringBuilder overall = new StringBuilder();
    public static StringBuilder header = new StringBuilder();
    public static StringBuilder practice = new StringBuilder();
    public static StringBuilder test = new StringBuilder();
    public static List<StringBuilder> results = new List<StringBuilder>();

    private void Start()
    {
        cresp = WCST_Play.cresp;
        gesamtpunktzahl = WCST_Play.gesamtpunktzahl;
        preservationErrors = WCST_Play.gesamtPreservation;
        errors = WCST_Play.gesamtError;

        fileName = "VPN" + VPN + "_WCST.csv";
        fileName = checkFilename(fileName);
        filePath = Path.Combine(Application.persistentDataPath, fileName);

        timePointsts.Append(VPN + ",Total score:," + cresp.ToString() + ",Date:," + System.DateTime.Now.ToString("dd/MM/yyyy") + ",Time:," + System.DateTime.Now.ToString("HH:mm:ss") + "\n\n");

        overall.Append("Task:,WCST\nTotal Score:," + cresp + "\nTotal errors:," + errors + "\nTotal perseveration errors:," + preservationErrors + "\nCategories completed:," + gesamtpunktzahl + "\n\n");

        header.Append("VP_ID,Correct response,RT (in ms),Block,Trial,Experimental condition,Temporal block,Stimulus presented,Correct Target1,Correct Target2,Correct Target3,Subject response, Sorting Catergory,Trial Type\n");

        results.Add(timePointsts);
        results.Add(overall);

        results.Add(header);
        results.Add(practice);
        results.Add(test);

        File.WriteAllText(filePath, ListToString(results));
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
    public string checkFilename(string fileName)
    {
        int i = 1;
        while (File.Exists(Path.Combine(Application.persistentDataPath, fileName)))
        {
            fileName = "VPN" + VPN  + "_WCST" + "(" + i + ")" + ".csv";
            i++;
        }
        return fileName;
    }

    public static void MeasurePractice(int phase, int blockNum, int trialNum, int trialType, string sortingCategory, string stimulus,int corrResOne, int corrResTwo, int corrResThree, int subRes, float timer, string accuracy)
    {
        practice.AppendFormat(VPN + ",{0},{1},{2},{3},Practice,{4},{5},{6},{7},{8},{9},{10},{11}\n", accuracy, timer, blockNum - 1, trialNum, blockNum, stimulus, corrResOne, corrResTwo, corrResThree, subRes, sortingCategory, trialType);
    }
    public static void MeasureTest(int phase, int blockNum, int trialNum, int trialType, string sortingCategory, string stimulus, int corrResOne, int corrResTwo, int corrResThree, int subRes, float timer, string accuracy)
    {
        test.AppendFormat(VPN + ",{0},{1},{2},{3},Test,{4},{5},{6},{7},{8},{9},{10},{11}\n", accuracy, timer, blockNum -1, trialNum, blockNum ,stimulus, corrResOne, corrResTwo, corrResThree, subRes, sortingCategory, trialType);
    }
}
