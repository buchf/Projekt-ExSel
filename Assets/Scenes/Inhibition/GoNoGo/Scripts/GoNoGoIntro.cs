using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNoGoIntro : MonoBehaviour
{
    public AudioSource GoNoGo_03;
    private int exit;

    void Start()
    {
        Debug.Log(SceneSwitch.goNoGoSpeed);
        exit = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (!GoNoGo_03.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void ExitButton()
    {
        exit++;
        if (exit == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 11);
        }
    }
}
