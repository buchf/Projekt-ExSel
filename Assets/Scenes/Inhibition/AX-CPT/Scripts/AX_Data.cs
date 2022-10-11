using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Linq;
public class AX_Data : MonoBehaviour
{

    public static string VPN;
    static string fileName;
    public static string filePath;

    public static StringBuilder header = new StringBuilder();
    public static StringBuilder practice = new StringBuilder();
    public static StringBuilder test = new StringBuilder();
    public static StringBuilder overall = new StringBuilder();
    public static List<StringBuilder> results = new List<StringBuilder>();

    private float hits;
    private float misses;
    private float errors;
    public float accuracyPercentage = 0.0f;

    void Start()
    {
        hits = AX_Test.hits;
        misses = AX_Test.misses;
        errors = AX_Test.errors;

        fileName = "VPN" + VPN + "_AX-CPT.csv";
        fileName = checkFilename(fileName);
        filePath = Path.Combine(Application.persistentDataPath, fileName);

        header.Append("Participant's ID," + "Date," + "Time" + "\n" + VPN + "," + System.DateTime.Now.ToString("dd/MM/yyyy") + "," + System.DateTime.Now.ToString("HH:mm:ss") + "\n\n");
        header.Append("Experimental Phase,Block Number,Trial number,Cue Stimulus, Probe stimulus, Correct response, Subject response, Trial type, Reaction time (ms), Reaction Accuracy\n");

        results.Add(header);
        results.Add(practice);
        results.Add(test);
        accuracyPercentage = hits / (hits + misses + errors) * 100;
        overall.Append("\n,Hits: " + hits + "\n,Misses: " + misses + "\n,Errors: " + errors + "\n,Correct: " + accuracyPercentage.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "%");
        results.Add(overall);
        File.WriteAllText(filePath, ListToString(results));
    }

    public void Create()
    {
        Debug.Log("test");
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
            fileName = "VPN" + VPN + "_AX-CPT" + "(" + i + ")" + ".csv";
            i++;
        }
        return fileName;
    }

    public static void MeasurePractice(int phase, int blockNum, int trialNum, string cue, string probe, string correctResonse, string response, int trialType, float time, int accuracy)
    {
        practice.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}\n", phase, blockNum, trialNum, cue, probe, correctResonse, response, trialType, time, accuracy);
    }
    public static void MeasureTest(int phase, int blockNum, int trialNum, string cue, string probe, string correctResonse, string response, int trialType, float time, int accuracy)
    {
        test.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}\n", phase, blockNum, trialNum, cue, probe, correctResonse, response, trialType, time, accuracy);
    }
}
