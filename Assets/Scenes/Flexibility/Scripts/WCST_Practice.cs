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
    [SerializeField] private GameObject fixCross;
    [SerializeField] private GameObject wizard;
    public AudioSource MCST_09mp3;
    public AudioSource MCST_10mp3;


    [SerializeField] private GameObject correctStar;
    [SerializeField] private GameObject incorrectStar;

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
        if (!MCST_09mp3.isPlaying && correctChain == 7)
        {
            
            wizard.SetActive(false);
            correctChain = 0;
        }
        if (!MCST_09mp3.isPlaying && correctChain == 6)
        {
            correctChain++;
            WizardAnimation();
            Debug.Log("test"); 
        }
        if(position == 12)
        {   
            DisablePractice();
            MCST_10mp3.Play();
            position++;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    public void DisablePractice()
    {
        foreach (GameObject obj in keyUI)
        {
            obj.gameObject.SetActive(false);
            
        }
        fixCross.SetActive(true);
        StartCoroutine(Wait());
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
            if (obj.gameObject.GetComponent<Button>())
            {
                obj.GetComponent<Button>().transition = Selectable.Transition.None;
                obj.GetComponent<Button>().interactable = false;
            }
        }
        fixCross.SetActive(true);
        StartCoroutine(Wait());
        
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
                CompareColor();
                break;
            case 2:
                CompareShape();
                break;
            case 3:
                CompareNum();
                break;
        }
        
    }

    private void CompareColor()
    {
        
        if(clickedColor == currentColor)
        {
            StartCoroutine(CorrectAnimation());
            correctChain++;
        }
        else
        {
            StartCoroutine(IncorrectAnimation());
            correctChain = 0;
        }
    }

    private void CompareShape()
    { 
        if (clickedShape == currentShape)
        {
            StartCoroutine(CorrectAnimation());
            correctChain++;
        }
        else
        {
            StartCoroutine(IncorrectAnimation());
            correctChain = 0;
        }   
    }

    private void CompareNum()
    {
        
        if (clickedNum == currentNum)
        {
            StartCoroutine(CorrectAnimation());
            correctChain++;
        }
        else
        {
            StartCoroutine(IncorrectAnimation());
            correctChain = 0;
        } 
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
            StartCoroutine(CorrectAnimation());
        }
        else
        {
            Debug.Log("FALSE");
            StartCoroutine(IncorrectAnimation());
        }
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        fixCross.SetActive(false);
        foreach (GameObject obj in keyUI)
        {
            if (obj.gameObject.GetComponent<Button>())
            {
                obj.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
                obj.GetComponent<Button>().interactable = true;
            }
        }
        SetCurrent(cardList[position]);
    }

    private void NextCard()
    {
        Debug.Log("position:" + position);
       
        current.SetActive(false);
        
        if(position == 11)
        {
            Debug.Log("finsih");
        }
        else
        {
            position++;
            Debug.Log("CARD");
            SetCurrent(cardList[position]);
        }   
    }
    public void WizardAnimation()
    {
        MCST_09mp3.Play();
        wizard.SetActive(true);   
    }

    IEnumerator CorrectAnimation()
    {
        correctStar.SetActive(true);
        DisableKeys();
        yield return new WaitForSeconds(1f);
        correctStar.SetActive(false);
        EnableKeys();
        NextCard();
    }

    IEnumerator IncorrectAnimation()
    {
        incorrectStar.SetActive(true);
        DisableKeys();
        yield return new WaitForSeconds(1f);
        incorrectStar.SetActive(false);
        EnableKeys();
        NextCard();
    }

    private void EnableKeys()
    {
        foreach (GameObject obj in keyUI)
        {
            if (obj.gameObject.GetComponent<Button>())
            {
                obj.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
                obj.GetComponent<Button>().interactable = true;
            }
        }
    }

    private void DisableKeys()
    {
        foreach (GameObject obj in keyUI)
        {
            if (obj.gameObject.GetComponent<Button>())
            {
                obj.GetComponent<Button>().transition = Selectable.Transition.None;
                obj.GetComponent<Button>().interactable = false;
            }
        }
    }
}

