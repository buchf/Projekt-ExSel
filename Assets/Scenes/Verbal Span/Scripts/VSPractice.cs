using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class VSPractice : MonoBehaviour
{
    [SerializeField] List<GameObject> startUI = new List<GameObject>();
    public VSBackend backend;
    [SerializeField] 
    GameObject Wolf, Besen, Haus, Kobold, Fisch, Schwein;


    // Start is called before the first frame update
    void Start()
    {
        backend = FindObjectOfType<VSBackend>();

        foreach (GameObject i in startUI)
        {
            i.SetActive(true);
        }
    }

    void Update()
    {
        
    }

    
    public void StartPractice()
    {
        foreach (var i in startUI)
        {
           i.SetActive(false);
        }
        backend.sequenzList.Add(Wolf);
    }

    public void RepeatIntro()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
