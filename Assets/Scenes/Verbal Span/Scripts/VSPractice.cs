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
    public GameObject inCorrect;

    public int currentTrial = 1;
    public int sequenzLength = 1;
    public int clickedLength = 0;

    // Start is called before the first frame update
    void Start()
    {
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
            
            foreach (var i in backend.clickedList)
            {
                i.SetActive(false);
            }
            currentTrial++;
            backend.ClearLists();
            clickedLength = 0;
            StartTrial(currentTrial);
        }
    }
    private void StartTrial(int current)
    {
        if(current == 1)
        {
            StartCoroutine(SequenzOne(Wolf));
        }
        if (current == 2)
        {
            StartCoroutine(SequenzOne(Besen));
        }
    }

    private void SpawnObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
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

    IEnumerator SequenzOne(GameObject a)
    {
        fixCross.SetActive(true);
        yield return new WaitForSeconds(1f);
        fixCross.SetActive(false);
        SpawnObject(a);
        yield return new WaitForSeconds(1f);
        a.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnOne(a);
    }

    void SpawnOne(GameObject a)
    {
        if (currentTrial == 1)
        {
            SpawnObjectInBlock(a, 5);
        }
        if (currentTrial == 2)
        {
            SpawnObjectInBlock(a, 5);
        }
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
        backend.clickedList.Add(gameObject);
        clickedLength++;
    }

    IEnumerator ClickAnimation(GameObject gameObject)
    {
        gameObject.GetComponent<Button>().interactable = false;
        border.SetActive(true);
        yield return new WaitForSeconds(.2f);
        border.SetActive(false);
        gameObject.GetComponent<Button>().interactable = true;
    }
}
