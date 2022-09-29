using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class VSTest : MonoBehaviour
{
    [SerializeField] List<GameObject> startUI = new List<GameObject>();
    [SerializeField] List<GameObject> blocks = new List<GameObject>();
    public VSBackend backend;
    [SerializeField]
    GameObject Wolf, Besen, Haus, Kobold, Fisch, Schwein, Baum, Zauberhut, Buch, Bild, Pilz, Schuh, Vogel, Drachen, Hase, Schluessel, Brille, Ring, Zwerg,
        Truhe, Blume, Apfel, Baer, Gras, Huhn, Kleid, Boot, Gans, Hexe, Stern, Elfe, Gnom, Frosch, Mond, Krone, Blatt;

    public GameObject border;
    public GameObject fixCross;

    public int currentTrial = 1;
    public int sequenzLength = 1;
    public int clickedLength = 0;

    int buff = 0;
    public GameObject defaultObject;
    // Start is called before the first frame update
    void Start()
    {
        buff = 0;
        clickedLength = 0;
        currentTrial = 6;
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
        if (sequenzLength == clickedLength)
        {

            foreach (var i in backend.sequenzList)
            {
                i.SetActive(false);
            }

            backend.ClearLists();
            clickedLength = 0;
            currentTrial++;
            StartTrial(currentTrial);
        }
    }
    private void StartTrial(int current)
    {
        if (sequenzLength == 1)
        {
            if (current == 1)
            {
                StartCoroutine(Sequenz(Baum));
            }
            if (current == 2)
            {
                StartCoroutine(Sequenz(Zauberhut));

            }
            if (current == 3)
            {
                StartCoroutine(Sequenz(Haus));

            }
            if (current == 4)
            {
                StartCoroutine(Sequenz(Buch));

            }
            if (current == 5)
            {
                StartCoroutine(Sequenz(Bild));

            }
            if (current == 6)
            {
                StartCoroutine(Sequenz(Pilz));

            }
            if (current == 7)
            {
                sequenzLength = 2;
            }

        }
        if (sequenzLength == 2)
        {
            if (current == 7)
            {
                Debug.Log("test");
                StartCoroutine(Sequenz(Buch, Kobold));
            }
            if (current == 8)
            {
                StartCoroutine(Sequenz(Schuh, Vogel));
            }
            if (current == 9)
            {
                StartCoroutine(Sequenz(Pilz, Drachen));
            }
            if (current == 10)
            {
                StartCoroutine(Sequenz(Fisch, Hase));
            }
            if (current == 11)
            {
                StartCoroutine(Sequenz(Schluessel, Brille));
            }
            if (current == 12)
            {
                StartCoroutine(Sequenz(Ring, Zwerg));
            }
            if(current == 13)
            {
                sequenzLength++;
            }
        }
        if(sequenzLength == 3)
        {
            if(current == 13)
            {
                StartCoroutine(Sequenz(Zauberhut, Buch, Truhe));
            }
            if (current == 14)
            {
                StartCoroutine(Sequenz(Blume, Ring, Besen));
            }
            if (current == 15)
            {
                StartCoroutine(Sequenz(Apfel, Baer, Gras));
            }
            if (current == 16)
            {
                StartCoroutine(Sequenz(Apfel, Baer, Gras));
            }
            if (current == 17)
            {
                StartCoroutine(Sequenz(Apfel, Baer, Gras));
            }
            if (current == 18)
            {
                StartCoroutine(Sequenz(Apfel, Baer, Gras));
            }
            if (current == 19)
            {
                sequenzLength++;
            }

        }

    }

    private void SpawnObject(GameObject gameObject)
    {
        gameObject.transform.position = defaultObject.transform.position;
        gameObject.SetActive(true);
        gameObject.GetComponent<Button>().interactable = false;
        backend.sequenzList.Add(gameObject);
    }

    public void StartTest()
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
    IEnumerator Sequenz(GameObject a, GameObject b, GameObject c)
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
        SpawnObject(c);
        yield return new WaitForSeconds(1f);
        c.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnOnField(a, b, c);
    }
    IEnumerator Sequenz(GameObject a, GameObject b, GameObject c, GameObject d)
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
        SpawnObject(c);
        yield return new WaitForSeconds(1f);
        c.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnObject(d);
        yield return new WaitForSeconds(1f);
        d.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnOnField(a, b, c, d);
    }
    IEnumerator Sequenz(GameObject a, GameObject b, GameObject c, GameObject d, GameObject e)
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
        SpawnObject(c);
        yield return new WaitForSeconds(1f);
        c.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnObject(d);
        yield return new WaitForSeconds(1f);
        d.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnObject(e);
        yield return new WaitForSeconds(1f);
        e.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnOnField(a, b, c, d, e);
    }
    IEnumerator Sequenz(GameObject a, GameObject b, GameObject c, GameObject d, GameObject e, GameObject f)
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
        SpawnObject(c);
        yield return new WaitForSeconds(1f);
        c.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnObject(d);
        yield return new WaitForSeconds(1f);
        d.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnObject(e);
        yield return new WaitForSeconds(1f);
        e.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnObject(f);
        yield return new WaitForSeconds(1f);
        f.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnOnField(a, b, c, d, e, f);
    }
    IEnumerator Sequenz(GameObject a, GameObject b, GameObject c, GameObject d, GameObject e, GameObject f, GameObject g)
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
        SpawnObject(c);
        yield return new WaitForSeconds(1f);
        c.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnObject(d);
        yield return new WaitForSeconds(1f);
        d.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnObject(e);
        yield return new WaitForSeconds(1f);
        e.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnObject(f);
        yield return new WaitForSeconds(1f);
        f.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnObject(g);
        yield return new WaitForSeconds(1f);
        g.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnOnField(a, b, c, d, e, f, g);
    }
    IEnumerator Sequenz(GameObject a, GameObject b, GameObject c, GameObject d, GameObject e, GameObject f, GameObject g, GameObject h)
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
        SpawnObject(c);
        yield return new WaitForSeconds(1f);
        c.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnObject(d);
        yield return new WaitForSeconds(1f);
        d.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnObject(e);
        yield return new WaitForSeconds(1f);
        e.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnObject(f);
        yield return new WaitForSeconds(1f);
        f.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnObject(g);
        yield return new WaitForSeconds(1f);
        g.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnObject(h);
        yield return new WaitForSeconds(1f);
        h.SetActive(false);
        yield return new WaitForSeconds(1f);
        SpawnOnField(a, b, c, d, e, f, g, h);
    }


    void SpawnOnField(GameObject a)
    {
        a.GetComponent<Button>().interactable = true;
        SpawnObjectInBlock(a,5);
    }
    void SpawnOnField(GameObject a, GameObject b)
    {
        a.GetComponent<Button>().interactable = true;
        b.GetComponent<Button>().interactable = true;

        if(currentTrial == 7)
        {
            SpawnObjectInBlock(a,4);
            SpawnObjectInBlock(b, 5);
        }
        if (currentTrial == 8)
        {
            SpawnObjectInBlock(a, 4);
            SpawnObjectInBlock(b, 5);
        }
        if (currentTrial == 9)
        {
            SpawnObjectInBlock(a, 4);
            SpawnObjectInBlock(b, 5);
        }
        if (currentTrial == 10)
        {
            SpawnObjectInBlock(a, 4);
            SpawnObjectInBlock(b, 5);
        }
        if (currentTrial == 11)
        {
            SpawnObjectInBlock(a, 4);
            SpawnObjectInBlock(b, 5);
        }
        if (currentTrial == 12)
        {
            SpawnObjectInBlock(a, 4);
            SpawnObjectInBlock(b, 5);
        }

    }
    void SpawnOnField(GameObject a, GameObject b, GameObject c)
    {
        a.GetComponent<Button>().interactable = true;
        b.GetComponent<Button>().interactable = true;
        c.GetComponent<Button>().interactable = true;

        if (currentTrial == 13)
        {
            SpawnObjectInBlock(a, 4);
            SpawnObjectInBlock(b, 5);
            SpawnObjectInBlock(c, 6);
        }
        if (currentTrial == 14)
        {
            SpawnObjectInBlock(a, 4);
            SpawnObjectInBlock(b, 5);
            SpawnObjectInBlock(c, 6);
        }
        if (currentTrial == 15)
        {
            SpawnObjectInBlock(a, 4);
            SpawnObjectInBlock(b, 5);
            SpawnObjectInBlock(c, 6);
        }
        if (currentTrial == 16)
        {
            SpawnObjectInBlock(a, 4);
            SpawnObjectInBlock(b, 5);
            SpawnObjectInBlock(c, 6);
        }
        if (currentTrial == 17)
        {
            SpawnObjectInBlock(a, 4);
            SpawnObjectInBlock(b, 5);
            SpawnObjectInBlock(c, 6);
        }
        if (currentTrial == 18)
        {
            SpawnObjectInBlock(a, 4);
            SpawnObjectInBlock(b, 5);
            SpawnObjectInBlock(c, 6);
        }

    }
    void SpawnOnField(GameObject a, GameObject b, GameObject c, GameObject d)
    {
        a.GetComponent<Button>().interactable = true;
        b.GetComponent<Button>().interactable = true;
        c.GetComponent<Button>().interactable = true;
        d.GetComponent<Button>().interactable = true;
        
    }

    void SpawnOnField(GameObject a, GameObject b, GameObject c, GameObject d, GameObject e)
    {
        a.GetComponent<Button>().interactable = true;
        b.GetComponent<Button>().interactable = true;
        c.GetComponent<Button>().interactable = true;
        d.GetComponent<Button>().interactable = true;
        e.GetComponent<Button>().interactable = true;
    }
    void SpawnOnField(GameObject a, GameObject b, GameObject c, GameObject d, GameObject e, GameObject f)
    {
        a.GetComponent<Button>().interactable = true;
        b.GetComponent<Button>().interactable = true;
        c.GetComponent<Button>().interactable = true;
        d.GetComponent<Button>().interactable = true;
        e.GetComponent<Button>().interactable = true;
        f.GetComponent<Button>().interactable = true;
    }

    void SpawnOnField(GameObject a, GameObject b, GameObject c, GameObject d, GameObject e, GameObject f, GameObject g)
    {
        a.GetComponent<Button>().interactable = true;
        b.GetComponent<Button>().interactable = true;
        c.GetComponent<Button>().interactable = true;
        d.GetComponent<Button>().interactable = true;
        e.GetComponent<Button>().interactable = true;
        f.GetComponent<Button>().interactable = true;
        g.GetComponent<Button>().interactable = true;
    }
    void SpawnOnField(GameObject a, GameObject b, GameObject c, GameObject d, GameObject e, GameObject f, GameObject g, GameObject h)
    {
        a.GetComponent<Button>().interactable = true;
        b.GetComponent<Button>().interactable = true;
        c.GetComponent<Button>().interactable = true;
        d.GetComponent<Button>().interactable = true;
        e.GetComponent<Button>().interactable = true;
        f.GetComponent<Button>().interactable = true;
        g.GetComponent<Button>().interactable = true;
        h.GetComponent<Button>().interactable = true;
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
}
