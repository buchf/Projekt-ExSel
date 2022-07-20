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

    public List<GameObject> cardList = new List<GameObject>();

    public GameObject MCWST_06;

    private GameObject current;
    private string currentColor;
    private int currentNum;
    private string currentShape;

    private GameObject clicked;
    private string clickedColor;
    private int clickedNum;
    private string clickedShape;

    // Start is called before the first frame update
    void Start()
    {
        SetCurrent(cardList[0]);
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

    private void SetCurrent(GameObject currentObj)
    {
        current = currentObj;
        currentColor = current.GetComponent<CardDisplay>().card.color;
        currentNum = current.GetComponent<CardDisplay>().card.number;
        currentShape = current.GetComponent<CardDisplay>().card.shape;
    }

    public void CardClick(GameObject clickedObject)
    {

        clicked = clickedObject;
        clickedColor = clicked.GetComponent<CardDisplay>().card.color;
        clickedNum = clicked.GetComponent<CardDisplay>().card.number;
        clickedShape = clicked.GetComponent<CardDisplay>().card.shape;


        //eventuell compare cards abfangen mit firstcompare und dann auf color, shape, number
        // switch case mit variable -> die dann das gesuchte attribut prüft bis zahl 6 erreicht is wenn nicht dann auf 0 
        FirstCompareCards();
    }

    private void FirstCompareCards()
    {
        if(clickedColor == currentColor || clickedNum == currentNum || clickedShape == currentShape)
        {
            Debug.Log("TRUE");
        }
        else
        {
            Debug.Log("FALSE");
        }
    }
}
