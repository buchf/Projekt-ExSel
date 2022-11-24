using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;

/**
 * Singleton. Coordinates global data exchange.
 * Attach it once (eg. Main Camera)
 **/
public class Experiment : MonoBehaviour
{


    public bool TestMode { get; private set; }

    
    // Start is called before the first frame update
    void Start()
    {
        SetUIStatus(false);
    }

    public void OnVPNChanged(string vpn)
    {
        int parsedNum;
        bool valid = int.TryParse(vpn, out parsedNum);
        if (valid)
        {
            SetUIStatus(true);
        }
        else
            SetUIStatus(false);
    }

    public void SetUIStatus(bool active)
    {
        GameObject[] lockables = GameObject.FindGameObjectsWithTag("Lockable");
        var lockableButtons = from l in lockables where l.GetComponent<Button>() != null select l;
        foreach (var button in lockableButtons)
        {
            button.GetComponent<Button>().interactable = active;
            var c = button.GetComponent<Image>().color;
            if (active)
                c.a = 1.0f;
            else
                c.a = 0.5f;
            button.GetComponent<Image>().color = c;
        }
    }       
}
