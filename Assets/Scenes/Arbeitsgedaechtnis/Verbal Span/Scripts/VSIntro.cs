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

    public AudioSource VS_02_backmp3;
    public AudioSource VS_05_backmp3;
    public AudioSource VS_06_backmp3;
    public AudioSource VS_07_backmp3;

    public GameObject panel;
    public GameObject pig;
    public GameObject key;
    public GameObject border1;
    public GameObject border2;

    int buff = 0;
    private void Start()
    {
        if (SceneSwitch.reverseVS == true)
        {
            StartCoroutine(BackwardsIntro());
        }
        else
        {
            StartCoroutine(ForwardIntro());
        }
    }

    IEnumerator ForwardIntro()
    {
        VS_01mp3.Play();
        yield return new WaitForSeconds(12f);
        VS_02mp3.Play();
        yield return new WaitForSeconds(24f);
        panel.SetActive(true);
        key.SetActive(true);
        VS_03mp3.Play();
        yield return new WaitForSeconds(3f);
        key.SetActive(false);
        pig.SetActive(true);
        VS_04mp3.Play();
        yield return new WaitForSeconds(3f);
        key.SetActive(true);
        key.transform.position = new Vector2(-100, 0);
        pig.transform.position = new Vector2(100, 0);
        VS_05mp3.Play();
        yield return new WaitForSeconds(12f);
        VS_06mp3.Play();
        border1.transform.position = new Vector2(-100, 0);
        border1.SetActive(true);
        yield return new WaitForSeconds(6f);
        VS_07mp3.Play();
        border2.transform.position = new Vector2(100, 0);
        border2.SetActive(true);
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    IEnumerator BackwardsIntro()
    {
        VS_01mp3.Play();
        yield return new WaitForSeconds(12f);

        VS_02_backmp3.Play();
        yield return new WaitForSeconds(33f);
        panel.SetActive(true);
        key.SetActive(true);
        VS_03mp3.Play();
        yield return new WaitForSeconds(3f);
        key.SetActive(false);
        pig.SetActive(true);
        VS_04mp3.Play();
        yield return new WaitForSeconds(3f);
        key.SetActive(true);
        pig.transform.position = new Vector2(-100, 0);
        key.transform.position = new Vector2(100, 0);
        VS_05_backmp3.Play();
        yield return new WaitForSeconds(12f);
        VS_06_backmp3.Play();
        border1.transform.position = new Vector2(-100, 0);
        border1.SetActive(true);
        yield return new WaitForSeconds(5f);
        VS_07_backmp3.Play();
        border2.transform.position = new Vector2(100, 0);
        border2.SetActive(true);
        yield return new WaitForSeconds(9f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
