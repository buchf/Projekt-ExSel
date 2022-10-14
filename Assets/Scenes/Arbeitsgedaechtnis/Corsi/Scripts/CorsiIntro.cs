using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CorsiIntro : MonoBehaviour
{
    public AudioSource Corsi_01;
    int exit;
    void Start()
    {
        Corsi_01.Play();
        exit = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!Corsi_01.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
    }
    public void ExitButton()
    {
        exit++;
        if (exit == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 7);
        }
    }
}
