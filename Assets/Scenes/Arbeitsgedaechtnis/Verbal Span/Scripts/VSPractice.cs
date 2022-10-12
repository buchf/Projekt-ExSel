using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class VSPractice : MonoBehaviour
{
    [SerializeField] List<GameObject> startUI = new List<GameObject>();
    [SerializeField] List<GameObject> blocks = new List<GameObject>();
    public VSBackend backend;
    [SerializeField] 
    GameObject Wolf, Besen, Haus, Kobold, Fisch, Schwein;

    public GameObject border;
    public GameObject fixCross;
    public GameObject correct;
    public GameObject incorrect;

    public GameObject lines;
    public static int currentTrial = 1;
    public int sequenzLength = 1;
    public int clickedLength = 0;

    public AudioSource VerbalSP_08;

    int buff = 0;
    public GameObject defaultObject;
    // Start is called before the first frame update
    void Start()
    {
        VSBackend.expPhase = 0;
        buff = 0;
        clickedLength = 0;
        currentTrial = 1;
        sequenzLength = 1;
        backend = FindObjectOfType<VSBackend>();

        foreach (GameObject i in startUI)
        {
            i.SetActive(true);
        }
    }

    private void Update()
    {
        //listen vergleichen dann correct / incorrect animation -> in animation am ende naechsten trial aufrufen
        if(sequenzLength == clickedLength)
        {
            
            foreach (var i in backend.sequenzList)
            {
                i.SetActive(false);
            }
            
            backend.ClearLists();
            clickedLength = 0;
            if(backend.listCompareVar == 1)
            {
                StartCoroutine(CorrectSequenz());
            }
            else
            {
                StartCoroutine(IncorrectSequenz());
            }
            //StartTrial(currentTrial);
        }
    }
    private void StartTrial(int current)
    {
        if(sequenzLength == 1)
        {
            if (current == 1)
            {
                StartCoroutine(Sequenz(Wolf));
            }
            if (current == 2)
            {
                StartCoroutine(Sequenz(Besen));
                
            }
            if(current == 3)
            {
                sequenzLength = 2;
            }
            
        }
        if(sequenzLength == 2)
        {
            if(current == 3)
            {
                Debug.Log("test");
                StartCoroutine(Sequenz(Haus,Kobold));
            }
            if (current == 4)
            {
                StartCoroutine(Sequenz(Fisch, Schwein));
            }
            if(current == 5)
            {
                StartCoroutine(EndOfPractice());
            }
        }
        
    }

    IEnumerator EndOfPractice()
    {
        VerbalSP_08.Play();
        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void SpawnObject(GameObject gameObject)
    {
        gameObject.transform.position = defaultObject.transform.position;
        gameObject.SetActive(true);
        gameObject.GetComponent<Button>().interactable = false;
        backend.sequenzList.Add(gameObject);
    }

    public void StartPractice()
    {
        foreach (var i in startUI)
        {
           i.SetActive(false);
        }
        StartTrial(currentTrial);
    }

    public void RepeatIntro()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    IEnumerator Sequenz(GameObject a)
    {
        fixCross.SetActive(true);
        yield return new WaitForSeconds(1f);
        fixCross.SetActive(false);
        SpawnObject(a);
        yield return new WaitForSeconds(1f);
        a.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnOnField(a);
    }
    IEnumerator Sequenz(GameObject a, GameObject b)
    {
        fixCross.SetActive(true);
        yield return new WaitForSeconds(1f);
        fixCross.SetActive(false);
        SpawnObject(a);
        yield return new WaitForSeconds(1f);
        a.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnObject(b);
        yield return new WaitForSeconds(1f);
        b.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnOnField(a, b);
    }


    void SpawnOnField(GameObject a)
    {
        a.GetComponent<Button>().interactable = true;
        if (currentTrial == 1)
        {
            SpawnObjectInBlock(a, 5);
        }
        if (currentTrial == 2)
        {
            SpawnObjectInBlock(a, 5);
        }
        lines.SetActive(true);
    }
    void SpawnOnField(GameObject a, GameObject b)
    {
        a.GetComponent<Button>().interactable = true;
        b.GetComponent<Button>().interactable = true;
        if (currentTrial == 3)
        {
            SpawnObjectInBlock(a, 5);
            SpawnObjectInBlock(b, 8);
        }
        if (currentTrial == 4)
        {
            SpawnObjectInBlock(a, 5);
            SpawnObjectInBlock(b, 8);
        }
        lines.SetActive(true);
    }


    void SpawnObjectInBlock(GameObject gameObject, int blockNumber)
    {
        switch (blockNumber)
        {
            case 1:
                gameObject.transform.position = new Vector3(blocks[0].transform.position.x, blocks[0].transform.position.y, -1);
                break;
            case 2:
                gameObject.transform.position = new Vector3(blocks[1].transform.position.x, blocks[1].transform.position.y, -1);
                break;
            case 3:
                gameObject.transform.position = new Vector3(blocks[2].transform.position.x, blocks[2].transform.position.y, -1);
                break;
            case 4:
                gameObject.transform.position = new Vector3(blocks[3].transform.position.x, blocks[3].transform.position.y, -1);
                break;
            case 5:
                gameObject.transform.position = new Vector3(blocks[4].transform.position.x, blocks[4].transform.position.y, -1);
                break;
            case 6:
                gameObject.transform.position = new Vector3(blocks[5].transform.position.x, blocks[5].transform.position.y, -1);
                break;
            case 7:
                gameObject.transform.position = new Vector3(blocks[6].transform.position.x, blocks[6].transform.position.y, -1);
                break;
            case 8:
                gameObject.transform.position = new Vector3(blocks[7].transform.position.x, blocks[7].transform.position.y, -1);
                break;
            case 9:
                gameObject.transform.position = new Vector3(blocks[8].transform.position.x, blocks[8].transform.position.y, -1);
                break;
        }
        gameObject.SetActive(true);
    }

    public void OnMouseDown(GameObject gameObject)
    {
        border.transform.position = gameObject.transform.position;
        Debug.Log(gameObject.name.ToString());
        StartCoroutine(ClickAnimation(gameObject));
    }

    IEnumerator ClickAnimation(GameObject gameObject)
    {
        gameObject.GetComponent<Button>().interactable = false;
        border.SetActive(true);
        yield return new WaitForSeconds(.2f);
        border.SetActive(false);
        gameObject.GetComponent<Button>().interactable = true;
        backend.clickedList.Add(gameObject);
        clickedLength++;
    }

    IEnumerator CorrectSequenz()
    {
        lines.SetActive(false);
        yield return new WaitForSeconds(.2f);
        correct.SetActive(true);
        yield return new WaitForSeconds(1f);
        correct.SetActive(false);
        yield return new WaitForSeconds(1f);
        currentTrial++;
        StartTrial(currentTrial);
    }

    IEnumerator IncorrectSequenz()
    {
        lines.SetActive(false);
        yield return new WaitForSeconds(.2f);
        incorrect.SetActive(true);
        yield return new WaitForSeconds(1f);
        incorrect.SetActive(false);
        yield return new WaitForSeconds(1f);
       // currentTrial++;
       if(buff == 0)
        {
            buff = 1;
            StartTrial(currentTrial);
        }
        else
        {
            buff = 0;
            currentTrial++;
            StartTrial(currentTrial);
        }
        
    }
}
