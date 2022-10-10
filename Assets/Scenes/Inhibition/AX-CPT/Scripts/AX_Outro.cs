using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AX_Outro : MonoBehaviour
{

    public AudioSource AX_CPT_06;

    // Start is called before the first frame update
    void Start()
    {
        AX_CPT_06.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!AX_CPT_06.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 23);
        }
    }
}
