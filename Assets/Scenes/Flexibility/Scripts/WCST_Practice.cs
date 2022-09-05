using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public GameObject cardBorder;
    //public GameObject MCWST_06;

    private GameObject current;
    private string currentColor;
    private int currentNum;
    private string currentShape;

    private List<string> usedRules = new List<string>();

    private GameObject clicked;
    private string clickedColor;
    private int clickedNum;
    private string clickedShape;

    private int position = 0;

    public int secondTry = 0;
    int buff = 0;
    bool preservationError;

    public string sortCategory = "default";
    public int correctChain = 0;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    { 
        /*
        if (!MCST_09mp3.isPlaying && correctChain == 6)
        {
            wizard.SetActive(false);
            EnabelKeyUI();
            //Hier dann next card machen mit 
            // rule switch nicht vergessen. momentaner wert wird in eine liste abgespeichert.
            // Funktion schreiben welche die geklickte variable mit der kompletten liste zu vergleichen damit eine regel nicht zweimal vorkommt -> perservation error.
        }
            
        */
        
        if(!MCST_10mp3.isPlaying && buff == 1)
        {
            buff++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    public void DisablePractice()
    {
        foreach (GameObject obj in keyUI)
        {
            obj.gameObject.SetActive(false);
            
        }
        current.SetActive(false);   
        fixCross.SetActive(true);
        cardBorder.SetActive(false);
        //StartCoroutine(Wait());
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
        cardBorder.SetActive(true);
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

        if (correctChain == 0 && sortCategory == "default")
        {
           Debug.Log("first compare");
           FirstCompareCards();
        }
        else
        {
            CompareCards();
        }

        //schwierig, chain = 0 first automatisch ausloest und chain > 0 weitergeht, wenn chain gebreakt wird dann wird automatisch correctchain 0 ausgeloest
        
    }

    private void CompareCards()
    { 
        switch (sortCategory)
        {
            case "color":
                CompareColor();
                break;
            case "shape":
                CompareShape();
                break;
            case "number":
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
        preservationError = false;
        for (int i = 0; i< usedRules.Count; i++)
        {
            Debug.Log("usedRule[i] == " + usedRules[i]);
            if (usedRules[i] == "color" || usedRules[i] == "shape" || usedRules[i] == "number")
            {
                Debug.Log("PRESERVATION ERROR"); 
                preservationError = true;
            }            
        }
        if (preservationError == false  && (clickedColor == currentColor || clickedNum == currentNum || clickedShape == currentShape))
        {
            
            if (clickedColor == currentColor) sortCategory = "color";
            if (clickedShape == currentShape) sortCategory = "shape";
            if (clickedNum == currentNum) sortCategory = "number";
            correctChain++;
            
            StartCoroutine(CorrectAnimation());
        }
        else
        {
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
        current.SetActive(false);
        if(position < 12)
        {
            SetCurrent(cardList[position]);
        }
        
    }

    IEnumerator WizardAnimation()
    {
        DisableKeys();
        correctChain = 0;
        MCST_09mp3.Play();
        wizard.SetActive(true);
        usedRules.Add(sortCategory);
        yield return new WaitForSeconds(6f);
        sortCategory = "default";
        wizard.SetActive(false);
        EnableKeys();
        NextCard();
    }

    IEnumerator CorrectAnimation()
    {
        correctStar.SetActive(true);
        DisableKeys();
        yield return new WaitForSeconds(1f);
        correctStar.SetActive(false);
        position++;
        secondTry = 0;
        if (correctChain == 6 && position  < 12)
        {
            StartCoroutine(WizardAnimation());
        }
        else
        {
            NextCard();
            EnableKeys();
        }
        if (position == 12)
        {
            DisablePractice();
            DisableKeys();
            MCST_10mp3.Play();
            buff = 1;
        }
    }

    IEnumerator IncorrectAnimation()
    {
        incorrectStar.SetActive(true);
        DisableKeys();
        yield return new WaitForSeconds(1f);
        incorrectStar.SetActive(false);
        
        
        if (position == 12)
        {
            DisablePractice();
            DisableKeys();
            MCST_10mp3.Play();
            buff = 1;
        }
        if (secondTry == 0)
        {
            EnableKeys();
            secondTry++;
        }
        else if (position < 12 && secondTry != 0)
        {
            secondTry = 0;
            position++;
            EnableKeys();
            NextCard();
        }


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

