using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AX_Intro : MonoBehaviour
{
    [SerializeField] List<AudioSource> audioFiles = new List<AudioSource>();
    [SerializeField] List<GameObject> backgrounds = new List<GameObject>();

    public GameObject book;
    public GameObject glasses;
    public GameObject greenDot;
    public GameObject redDot;

    public int current = 0;
    void Start()
    {        
        current = 0;
        audioFiles[current].Play();
        backgrounds[current].SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioFiles[current].isPlaying)
        {
            current++;
            if (current == 2)
            {
                StartCoroutine(TrialAnimation());
            }
            else
            {
                if (current == 3)
                {
                    Debug.Log("fertig!");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

    IEnumerator TrialAnimation()
    {
        audioFiles[current].Play();
        backgrounds[current - 1].SetActive(false);
        backgrounds[current].SetActive(true);
        yield return new WaitForSeconds(5f);
        glasses.SetActive(true);
        yield return new WaitForSeconds(6f);
        book.SetActive(true);
        glasses.SetActive(false);
        greenDot.SetActive(true);
        redDot.SetActive(true);
    }
}
