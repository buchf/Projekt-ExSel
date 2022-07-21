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
    public GameObject cardBoder;
    //public GameObject MCWST_06;

    private GameObject current;
    private string currentColor;
    private int currentNum;
    private string currentShape;

    private GameObject clicked;
    private string clickedColor;
    private int clickedNum;
    private string clickedShape;

    private int position = 0;

    private int sortCategory = 0;
    public int correctChain = 0;

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
        SetCurrent(cardList[position]);
    }
    public void BackToIntro()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1 );
    }

    private void SetCurrent(GameObject currentObj)
    {
        cardBoder.SetActive(true);
        current = currentObj;
        current.SetActive(true);
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


        //schwierig, chain = 0 first automatisch ausloest und chain > 0 weitergeht, wenn chain gebreakt wird dann wird automatisch correctchain 0 ausgeloest
        if (correctChain == 0)
        {
            FirstCompareCards();
        }
        else if (correctChain > 0)
        {
            CompareCards();
        }
        
        
        
    }

    private void CompareCards()
    {
        switch (sortCategory)
        {
            case 1:
                Debug.Log("CASE COLOR");
                CompareColor();
                break;
            case 2:
                Debug.Log("CASE sha");
                CompareShape();
                break;
            case 3:
                Debug.Log("CASE num");
                CompareNum();
                break;
        }
        
    }

    private void CompareColor()
    {
        
        if(clickedColor == currentColor)
        {
            correctChain++;
        }
        else
        {
            Debug.Log("CHAINBReAK");
            correctChain = 0;
        }
        current.SetActive(false);
        position++;
        SetCurrent(cardList[position]);
    }

    private void CompareShape()
    { 
        if (clickedShape == currentShape)
        {
            correctChain++;
        }
        else
        {
            Debug.Log("CHAINBReAK");
            correctChain = 0;
        }
        current.SetActive(false);
        position++;
        SetCurrent(cardList[position]);
    }

    private void CompareNum()
    {
        
        if (clickedNum == currentNum)
        {
            correctChain++;
        }
        else
        {
            Debug.Log("CHAINBReAK");
            correctChain = 0;
        }
        current.SetActive(false);
        position++;
        SetCurrent(cardList[position]);
    }

    private void FirstCompareCards()
    {
        
        if (clickedColor == currentColor || clickedNum == currentNum || clickedShape == currentShape)
        {
            
            if (clickedColor == currentColor) sortCategory = 1;
            if (clickedShape == currentShape) sortCategory = 2;
            if (clickedNum == currentNum) sortCategory = 3;
            correctChain++;
            Debug.Log("TRUE sort= " + sortCategory);
            
        }
        else
        {
            Debug.Log("FALSE");
        }
        current.SetActive(false);
        position++;
        SetCurrent(cardList[position]);
    }


}
