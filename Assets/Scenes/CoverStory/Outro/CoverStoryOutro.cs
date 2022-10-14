using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoverStoryOutro : MonoBehaviour
{
    [SerializeField] List<AudioSource> audioFiles = new List<AudioSource>();
    [SerializeField] List<GameObject> backgrounds = new List<GameObject>();

    int current = 0;
    private int exit;
    void Start()
    {
        exit = 0;
        current = 0;
        audioFiles[current].Play();
        backgrounds[current].SetActive(true);
    }

    void Update()
    {
        if (!audioFiles[current].isPlaying)
        {
            current++;
            if (current == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 29);
            }
            else
            {

                audioFiles[current].Play();
                backgrounds[current - 1].SetActive(false);
                backgrounds[current].SetActive(true);

            }
        }
    }

    public void ExitButton()
    {
        exit++;
        if (exit == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 29);
        }
    }
}
