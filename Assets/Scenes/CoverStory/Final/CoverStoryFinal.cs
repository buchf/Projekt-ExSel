using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoverStoryFinal : MonoBehaviour
{

    public AudioSource coverStory06mp3;
    private int exit;
    // Start is called before the first frame update
    void Start()
    {
        exit = 0;
        coverStory06mp3.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!coverStory06mp3.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 30);
        }
    }
    public void ExitButton()
    {
        exit++;
        if (exit == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 30);
        }
    }
}
