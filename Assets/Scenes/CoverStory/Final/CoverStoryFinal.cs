using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoverStoryFinal : MonoBehaviour
{

    public AudioSource coverStory06mp3;

    // Start is called before the first frame update
    void Start()
    {
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
}
