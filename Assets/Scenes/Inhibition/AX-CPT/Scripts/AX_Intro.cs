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
    public GameObject fixCross;

    private int exit;

    public int current = 0;
    void Start()
    {
        exit = 0;
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
        fixCross.SetActive(true);
        yield return new WaitForSeconds(5f);
        fixCross.SetActive(false);
        glasses.SetActive(true);
        yield return new WaitForSeconds(1f);
        glasses.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        book.SetActive(true);
        greenDot.SetActive(true);
        redDot.SetActive(true);
        yield return new WaitForSeconds(5f);
        book.SetActive(false);
        greenDot.SetActive(false);
        redDot.SetActive(false);
    }

    public void ExitButton()
    {
        exit++;
        if (exit == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 20);
        }
    }
}
