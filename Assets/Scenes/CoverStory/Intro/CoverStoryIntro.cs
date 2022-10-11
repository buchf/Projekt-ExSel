using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoverStoryIntro : MonoBehaviour
{
    [SerializeField] List<AudioSource> audioFiles = new List<AudioSource>();
    [SerializeField] List<GameObject> backgrounds = new List<GameObject>();

    int current = 0;
    void Start()
    {
        current = 0;
        audioFiles[current].Play();
        backgrounds[current].SetActive(true);
    }

    void Update()
    {
        if (!audioFiles[current].isPlaying)
        {
            current++;
            if (current == 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 28);
            }
            else
            {

                audioFiles[current].Play();
                backgrounds[current - 1].SetActive(false);
                backgrounds[current].SetActive(true);

            }
        }
    }
}
