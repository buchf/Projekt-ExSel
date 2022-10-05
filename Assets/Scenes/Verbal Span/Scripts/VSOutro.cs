using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VSOutro : MonoBehaviour
{
    public AudioSource VerbalSP_10mp3;
    // Start is called before the first frame update
    void Start()
    {
        VerbalSP_10mp3.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!VerbalSP_10mp3.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 27);
        }
    }
}
