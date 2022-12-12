using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleScript : MonoBehaviour
{
    public Toggle corsiTog;
    public Toggle verbalTog;
    public Toggle goNoGoTog;


    private void Update()
    {
        ToggleCorsi();
        ToggleVerbalSpan();
        ToggleGoNoGo();
    }

    public void ToggleCorsi()
    {
        if (corsiTog.isOn)
        {
            SceneSwitch.reverse = true;
        }
        else
        {
            SceneSwitch.reverse = false;
        }
    }

    public void ToggleVerbalSpan()
    {
        if (verbalTog.isOn)
        {
            SceneSwitch.reverseVS = true;
        }
        else
        {
            SceneSwitch.reverseVS = false;
        }
    }

    public void ToggleGoNoGo()
    {
        if (goNoGoTog.isOn)
        {
            SceneSwitch.goNoGo = true;
        }
        else
        {
            SceneSwitch.goNoGo = false;
        }
    }
}
