using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimalSelector : MonoBehaviour
{
    public TextMesh cow;
    public TextMesh chicken;
    public TextMesh pig;
    public TextMesh Outro;

    public GameObject cowImage;
    public GameObject chickenImage;
    public GameObject pigImage;

    public Button button;
    public AudioSource GoNoGo_02;

    private int exit;
    void Start()
    {
        exit = 0;
        button.interactable = false;
        GoNoGo_02.Play();
        //GoNoGo.trial++;
        SelectText(GoNoGo.trial);
    }

    private void Update()
    {
        if (!GoNoGo_02.isPlaying)
        {
            button.interactable = true;
        }
    }
    public void NextTrial()
    {
        if(GoNoGo.trial == 5) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 128);
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void SelectText(int trial)
    {
        switch (trial)
        {
            case 2:
                cow.gameObject.SetActive(true);
                chicken.gameObject.SetActive(false);
                pig.gameObject.SetActive(false);
                cowImage.gameObject.SetActive(true);
                chickenImage.gameObject.SetActive(false);
                pigImage.gameObject.SetActive(false);
                Outro.gameObject.SetActive(false);
                break;
            case 3:
                cow.gameObject.SetActive(true);
                chicken.gameObject.SetActive(false);
                pig.gameObject.SetActive(false);
                cowImage.gameObject.SetActive(true);
                chickenImage.gameObject.SetActive(false);
                pigImage.gameObject.SetActive(false);
                Outro.gameObject.SetActive(false);
                break;
            case 4:
                cow.gameObject.SetActive(true);
                chicken.gameObject.SetActive(false);
                pig.gameObject.SetActive(false);
                cowImage.gameObject.SetActive(true);
                chickenImage.gameObject.SetActive(false);
                pigImage.gameObject.SetActive(false);
                Outro.gameObject.SetActive(false);
                break;
            case 5:
                cow.gameObject.SetActive(true);
                chicken.gameObject.SetActive(false);
                pig.gameObject.SetActive(false);
                cowImage.gameObject.SetActive(true);
                chickenImage.gameObject.SetActive(false);
                pigImage.gameObject.SetActive(false);
                Outro.gameObject.SetActive(false);
                break;
        }
    }

    public void ExitButton()
    {
        exit++;
        if (exit == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
