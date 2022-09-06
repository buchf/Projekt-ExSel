using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WCST_Play : MonoBehaviour
{
    //Basic UI
    public AudioSource MCST_11;
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
    private List<string> usedRules = new List<string>();
    private int position = 0;

    private GameObject current;
    private string currentColor;
    private int currentNum;
    private string currentShape;

    private GameObject clicked;
    private string clickedColor;
    private int clickedNum;
    private string clickedShape;

    bool preservationError;

    void Start()
    {
        //spaeter wieder aktivieren nur um intro test dauer zu skippen
        //StartCoroutine(IntroSequenz());
    }

    IEnumerator IntroSequenz()
    {
        button.interactable = false;
        MCST_11.Play();
        yield return new WaitForSeconds(13f);
        button.interactable = true;
    }

    public void DisableUI()
    {
        text.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
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

    private void SetCurrent(GameObject currentObj)
    {
        cardBorder.SetActive(true);
        current = currentObj;
        current.SetActive(true);
        currentColor = current.GetComponent<CardDisplay>().card.color;
        currentNum = current.GetComponent<CardDisplay>().card.number;
        currentShape = current.GetComponent<CardDisplay>().card.shape;
    }
}
