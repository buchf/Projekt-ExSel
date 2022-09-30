using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VSIntro : MonoBehaviour
{
    public AudioSource VS_01mp3;
    public AudioSource VS_02mp3;
    public AudioSource VS_03mp3;
    public AudioSource VS_04mp3;
    public AudioSource VS_05mp3;
    public AudioSource VS_06mp3;
    public AudioSource VS_07mp3;

    public GameObject panel;
    public GameObject pig;
    public GameObject key;
    public GameObject border1;
    public GameObject border2;

    int buff = 0;
    private void Start()
    {
        Debug.Log(SceneSwitch.reverseVS);
        buff = 0;
        VS_01mp3.Play();
    }
    private void Update()
    {
        if (!VS_01mp3.isPlaying && buff == 0)
        {
            VS_02mp3.Play();
            buff = 1;
        }
        if (!VS_02mp3.isPlaying && buff == 1)
        {
            VS_03mp3.Play();
            panel.SetActive(true);
            key.SetActive(true);
            buff = 2;
        }
        if (!VS_03mp3.isPlaying && buff == 2)
        {
            VS_04mp3.Play();
            key.SetActive(false);
            pig.SetActive(true);
            buff = 3;
        }
        if (!VS_04mp3.isPlaying && buff == 3)
        {
            key.SetActive(true);
            key.transform.position = new Vector2(750, 540);
            pig.transform.position = new Vector2(1170, 540);
            VS_05mp3.Play();
            buff = 4;
        }
        if (!VS_05mp3.isPlaying && buff == 4)
        {
            VS_06mp3.Play();
            border1.transform.position = new Vector2(750,540);
            border1.SetActive(true);
            buff = 5;
        }
        if (!VS_06mp3.isPlaying && buff == 5)
        {
            VS_07mp3.Play();
            border2.transform.position = new Vector2(1170, 540);
            border2.SetActive(true);
            buff = 6;
        }

        if (!VS_07mp3.isPlaying && buff == 6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
