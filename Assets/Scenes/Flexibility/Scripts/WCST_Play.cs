using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WCST_Play : MonoBehaviour
{
    //Basic UI
    public AudioSource MCST_12;
    public AudioSource MCST_11;
    public AudioSource MCST_09;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private List<GameObject> keyUI;
    [SerializeField] private GameObject fixCross;
    [SerializeField] private GameObject wizard;
    public Button button;

    [SerializeField] private GameObject correctStar;
    [SerializeField] private GameObject incorrectStar;


    //Cards and Border
    public List<GameObject> cardList = new List<GameObject>();
    public GameObject cardBorder;


    //var for the testPhase
    public List<string> usedRules = new List<string>();
    public int position = 0;

    private GameObject current;
    private string currentColor;
    private int currentNum;
    private string currentShape;

    private GameObject clicked;
    private string clickedColor;
    private int clickedNum;
    private string clickedShape;


    bool preservationError;
    int blockNumber = 1;
    int block2Buff = 0;
    public string sortCategory = "default";
    public int correctChain = 0;

    void Start()
    {
        blockNumber = 1;
        block2Buff = 0;
        position = 0;
        //spaeter wieder aktivieren nur um intro test dauer zu skippen
        //StartCoroutine(IntroSequenz());
    }

    public void CardClick(GameObject clickedObject)
    {

        if (blockNumber == 2 && usedRules.Count > block2Buff)
        {
            sortCategory = usedRules[block2Buff];
        }

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
        if (clickedColor == currentColor)
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
    private bool CheckIfUsed(string sortCategory)
    {
        preservationError = false;
        for (int i = 0; i < usedRules.Count; i++)
        {
            Debug.Log("usedRule[i] == " + usedRules[i]);
            if (usedRules[i] == sortCategory)
            {
                Debug.Log("PRESERVATION ERROR");
                preservationError = true;
            }
        }
        return preservationError;
    }
    private void FirstCompareCards()
    {

        //for schleife unten in die if abfrage da erst unten die sort category festgelegt wird


        if (clickedColor == currentColor || clickedNum == currentNum || clickedShape == currentShape)
        {
            if (clickedColor == currentColor) sortCategory = "color";
            if (clickedShape == currentShape) sortCategory = "shape";
            if (clickedNum == currentNum) sortCategory = "number";

            Debug.Log("checkIfUsed: " + CheckIfUsed(sortCategory));
            if (preservationError == true)
            {
                sortCategory = "default";
                StartCoroutine(IncorrectAnimation());

            }
            else
            {
                StartCoroutine(CorrectAnimation());
                correctChain++;
            }
        }
        else
        {
            StartCoroutine(IncorrectAnimation());
        }
    }
    IEnumerator IntroSequenz()
    {
        button.interactable = false;
        MCST_11.Play();
        yield return new WaitForSeconds(13f);
        button.interactable = true;
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
    IEnumerator WizardAnimation()
    {
        DisableKeys();
        correctChain = 0;
        MCST_09.Play();
        wizard.SetActive(true);
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
        yield return new WaitForSeconds(0.5f);
        correctStar.SetActive(false);
        current.SetActive(false);
        cardBorder.SetActive(false);
        yield return new WaitForSeconds(1f);
        position++;

        if (blockNumber == 2 && correctChain == 6)
        {
            block2Buff++;
            if ((blockNumber == 2 && position == 48) || blockNumber == 2 && block2Buff == 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                StartCoroutine(WizardAnimation());
            }
        }
        else
        {
            if (correctChain == 6 && blockNumber == 1)
            {
                usedRules.Add(sortCategory);
                if (usedRules.Count < 3)
                {
                    StartCoroutine(WizardAnimation());
                }
            }
            else
            {
                NextCard();
                EnableKeys();
            }
        }

        if (position == 24 || (usedRules.Count == 3 && blockNumber == 1))
        {
            StartCoroutine(BlockSwitch());
        }

    }


    IEnumerator IncorrectAnimation()
    {
        incorrectStar.SetActive(true);
        DisableKeys();
        yield return new WaitForSeconds(0.5f);
        incorrectStar.SetActive(false);
        current.SetActive(false);
        cardBorder.SetActive(false);
        yield return new WaitForSeconds(1f);
        position++;
        if (blockNumber == 2 && position == 48)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            if (position == 24)
            {
                StartCoroutine(BlockSwitch());
            }
            else
            {
                EnableKeys();
                NextCard();
            }

        }
    }

    IEnumerator BlockSwitch()
    {
        blockNumber = 2;
        correctChain = 0;
        sortCategory = "default";
        MCST_12.Play();
        DisableKeys();
        DisableKeyUI();
        MCST_12.Play();
        yield return new WaitForSeconds(3f);
        position = 24;
        EnableKeyUI();
        StartCoroutine(Wait());
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

    private void NextCard()
    {
        cardBorder.SetActive(true);
        if (position < 48)
        {
            SetCurrent(cardList[position]);
        }
    }

    public void DisableUI()
    {
        text.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        EnableKeyUI();
        StartCoroutine(Wait());
    }

    private void EnableKeyUI()
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


    }

    private void DisableKeyUI()
    {
        foreach (GameObject obj in keyUI)
        {
            obj.gameObject.SetActive(false);
        }
        fixCross.SetActive(true);
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
