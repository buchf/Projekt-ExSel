using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class WCST_Practice : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private List<Button> button;
    [SerializeField] private List<GameObject> keyUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableUI()
    {
        text.gameObject.SetActive(false);
        foreach(Button i in button){
            i.gameObject.SetActive(false);
        }
        EnabelKeyUI();
    }

    private void EnabelKeyUI()
    {
        foreach (GameObject obj in keyUI)
        {
            obj.gameObject.SetActive(true);
        }
    }
    public void BackToIntro()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1 );
    }

    public void TestClick(GameObject clickedObject)
    {
       Debug.Log(clickedObject.GetComponent<CardDisplay>().card.color.ToString()); 
    }
}
