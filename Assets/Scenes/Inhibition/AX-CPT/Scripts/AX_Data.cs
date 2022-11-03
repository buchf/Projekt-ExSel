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


    public static StringBuilder timePointsts = new StringBuilder();
    public static StringBuilder header = new StringBuilder();
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


        accuracyPercentage = hits / (hits + misses + errors) * 100;

        fileName = "VPN" + VPN + "_AX-CPT.csv";
        fileName = checkFilename(fileName);
        filePath = Path.Combine(Application.persistentDataPath, fileName);

        timePointsts.Append(VPN + ",Total score:," + hits.ToString() + ",Date:," + System.DateTime.Now.ToString("dd/MM/yyyy") + ",Time:," + System.DateTime.Now.ToString("HH:mm:ss") + "\n\n");

        overall.Append("Task:,AX-CPT\nHits: " + hits + "\nMisses:," + misses + "\nErrors:," + errors + "\nPercent correct:," + accuracyPercentage.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "%\n\n");

        header.Append("VP_ID,Correct Response,RT (in ms),Block,Trial,Cue Stimulus,Probe Stimulus,Correct Click,Subject response,Trial Type\n");

        results.Add(timePointsts);
        results.Add(overall);
        results.Add(header);
        
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
            fileName = "VPN" + VPN + "_AX-CPT" + "(" + i + ")" + ".csv";
            i++;
        }
        return fileName;
    }

    
    public static void MeasureTest( int blockNum, int trialNum, string cue, string probe, string correctResponse, string response, string trialType, float time, int accuracy)
    {
        test.AppendFormat(VPN + ",{0},{1},{2},{3},{4},{5},{6},{7},{8}\n", accuracy, time, blockNum - 1, trialNum,cue,probe, correctResponse, response, trialType);
    }
}
