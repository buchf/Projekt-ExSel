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
        Truhe, Blume, Apfel, Baer, Gras, Huhn, Kleid, Boot, Gans, Hexe, Stern, Elfe, Frosch, Mond, Krone, Blatt, Hund;

    public GameObject border;
    public GameObject fixCross;

    public GameObject lines;

    public Button button;
    public AudioSource backwards;
    public AudioSource forward;

    public static int currentTrial = 1;
    public int sequenzLength = 1;
    public int clickedLength = 0;

    public static int wrongCounter = 0;
    public GameObject defaultObject;
    public static int accuracy = 0;
    // Start is called before the first frame update
    void Start()
    {
        lines.SetActive(false);
        accuracy = 0;
        VSBackend.expPhase = 1;
        wrongCounter = 0;
        clickedLength = 0;
        currentTrial = 1;
        sequenzLength = 1;
        backend = FindObjectOfType<VSBackend>();

        StartCoroutine(IntroAudio());
        foreach (GameObject i in startUI)
        {
            i.SetActive(true);
        }
    }

    IEnumerator IntroAudio()
    {
        button.interactable = false;
        if(SceneSwitch.reverseVS == true)
        {
            backwards.Play();
        }
        else
        {
            forward.Play();
        }
        yield return new WaitForSeconds(8f);
        button.interactable = true;
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
        lines.SetActive(false);
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
                if (wrongCounter >= 3)
                { 
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
                }
                else
                {
                    wrongCounter = 0;
                }
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
            if (current == 13)
            {
                if (wrongCounter >= 3)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    wrongCounter = 0;
                }
                sequenzLength++;
            }
        }
        if (sequenzLength == 3)
        {
            if (current == 13)
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
                StartCoroutine(Sequenz(Baum, Huhn, Hase));
            }
            if (current == 17)
            {
                StartCoroutine(Sequenz(Kobold, Kleid, Boot));
            }
            if (current == 18)
            {
                StartCoroutine(Sequenz(Gans, Hexe, Schluessel));
            }
            if (current == 19)
            {
                if (wrongCounter >= 3)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    wrongCounter = 0;
                }
                sequenzLength++;
            }
        }
        if (sequenzLength == 4)
        {
            if (current == 19)
            {
                StartCoroutine(Sequenz(Ring, Huhn, Blume, Vogel));
            }
            if (current == 20)
            {
                StartCoroutine(Sequenz(Baum, Baer, Zwerg, Schwein));
            }
            if (current == 21)
            {
                StartCoroutine(Sequenz(Wolf, Drachen, Kobold, Zauberhut));
            }
            if (current == 22)
            {
                StartCoroutine(Sequenz(Apfel, Kleid, Stern, Boot));
            }
            if (current == 23)
            {
                StartCoroutine(Sequenz(Hund, Buch, Schuh, Fisch));
            }
            if (current == 24)
            {
                StartCoroutine(Sequenz(Hexe, Bild, Besen, Hase));
            }
            if (current == 25)
            {
                if (wrongCounter >= 3)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    wrongCounter = 0;
                }
                sequenzLength++;
            }
        }
        if (sequenzLength == 5)
        {
            if (current == 25)
            {
                StartCoroutine(Sequenz(Mond, Apfel, Stern, Blatt, Hase));
            }
            if (current == 26)
            {
                StartCoroutine(Sequenz(Brille, Kleid, Wolf, Huhn, Fisch));
            }
            if (current == 27)
            {
                StartCoroutine(Sequenz(Buch, Blume, Gras, Schuh, Elfe));
            }
            if (current == 28)
            {
                StartCoroutine(Sequenz(Krone, Gans, Drachen, Zauberhut, Bild));
            }
            if (current == 29)
            {
                StartCoroutine(Sequenz(Truhe, Ring, Boot, Frosch, Kobold));
            }
            if (current == 30)
            {
                StartCoroutine(Sequenz(Vogel, Baum, Hexe, Besen, Zwerg));
            }
            if (current == 31)
            {
                if (wrongCounter >= 3)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    wrongCounter = 0;
                }
                sequenzLength++;
            }
        }
        if (sequenzLength == 6)
        {
            if (current == 31)
            {
                StartCoroutine(Sequenz(Stern, Elfe, Hexe, Huhn, Schluessel, Truhe));
            }
            if (current == 32)
            {
                StartCoroutine(Sequenz(Blume, Zwerg, Buch, Zauberhut, Blatt, Boot));
            }
            if (current == 33)
            {
                StartCoroutine(Sequenz(Gras, Besen, Kleid, Schwein, Kobold, Bild));
            }
            if (current == 34)
            {
                StartCoroutine(Sequenz(Frosch, Gans, Pilz, Haus, Baum, Brille));
            }
            if (current == 35)
            {
                StartCoroutine(Sequenz(Drachen, Krone, Wolf, Hund, Apfel, Schuh));
            }
            if (current == 36)
            {
                StartCoroutine(Sequenz(Mond, Fisch, Baer, Vogel, Ring, Hase));
            }
            if (current == 37)
            {
                if (wrongCounter >= 3)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    wrongCounter = 0;
                }
                sequenzLength++;
            }
        }
        if (sequenzLength == 7)
        {
            if (current == 37)
            {
                StartCoroutine(Sequenz(Brille, Hund, Gans, Hase, Buch, Zwerg, Frosch));
            }
            if (current == 38)
            {
                StartCoroutine(Sequenz(Gras, Hase, Brille, Blatt, Krone, Truhe, Zauberhut));
            }
            if (current == 39)
            {
                StartCoroutine(Sequenz(Blume, Kobold, Schwein, Besen, Truhe, Baer, Pilz));
            }
            if (current == 40)
            {
                StartCoroutine(Sequenz(Elfe, Baum, Haus, Ring, Stern, Drachen, Hase));
            }
            if (current == 41)
            {
                StartCoroutine(Sequenz(Haus, Hase, Brille, Schuh, Kobold, Blume, Vogel));
            }
            if (current == 42)
            {
                StartCoroutine(Sequenz(Gans, Bild, Boot, Ring, Zwerg, Blatt, Hase));
            }
            if (current == 43)
            {
                if (wrongCounter >= 3)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    wrongCounter = 0;
                }
                sequenzLength++;
            }
        }
        if (sequenzLength == 8)
        {
            if (current == 43)
            {
                StartCoroutine(Sequenz(Vogel, Haus, Buch, Zauberhut, Besen, Brille, Ring, Gans));
            }
            if (current == 44)
            {
                StartCoroutine(Sequenz(Fisch, Kleid, Hase, Apfel, Schluessel, Zwerg, Elfe, Besen));
            }
            if (current == 45)
            {
                StartCoroutine(Sequenz(Kleid, Baer, Zwerg, Hase, Baum, Mond, Kobold, Hund));
            }
            if (current == 46)
            {
                StartCoroutine(Sequenz(Gras, Wolf, Schwein, Apfel, Truhe, Bild, Haus, Zauberhut
));
            }
            if (current == 47)
            {
                StartCoroutine(Sequenz(Apfel, Besen, Zwerg, Krone, Truhe, Vogel, Mond, Blume));
            }
            if (current == 48)
            {
                StartCoroutine(Sequenz(Besen, Krone, Truhe, Gans, Baum, Hund, Vogel, Drachen));
            }
            if (current == 49)
            {
                //ENDE nexxt scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        lines.SetActive(true);
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
        SpawnObjectInBlock(a, 5);
        lines.SetActive(true);
    }
    void SpawnOnField(GameObject a, GameObject b)
    {
        a.GetComponent<Button>().interactable = true;
        b.GetComponent<Button>().interactable = true;

        if (currentTrial == 7)
        {
            SpawnObjectInBlock(a, 4);
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
        lines.SetActive(true);
    }
    void SpawnOnField(GameObject a, GameObject b, GameObject c)
    {
        a.GetComponent<Button>().interactable = true;
        b.GetComponent<Button>().interactable = true;
        c.GetComponent<Button>().interactable = true;

        if (currentTrial == 13)
        {
            SpawnObjectInBlock(a, 4);
            SpawnObjectInBlock(c, 5);
            SpawnObjectInBlock(b, 6);
        }
        if (currentTrial == 14)
        {
            SpawnObjectInBlock(b, 4);
            SpawnObjectInBlock(c, 5);
            SpawnObjectInBlock(a, 6);
        }
        if (currentTrial == 15)
        {
            SpawnObjectInBlock(a, 4);
            SpawnObjectInBlock(b, 5);
            SpawnObjectInBlock(c, 6);
        }
        if (currentTrial == 16)
        {
            SpawnObjectInBlock(c, 4);
            SpawnObjectInBlock(b, 5);
            SpawnObjectInBlock(a, 6);
        }
        if (currentTrial == 17)
        {
            SpawnObjectInBlock(a, 4);
            SpawnObjectInBlock(c, 5);
            SpawnObjectInBlock(b, 6);
        }
        if (currentTrial == 18)
        {
            SpawnObjectInBlock(b, 4);
            SpawnObjectInBlock(a, 5);
            SpawnObjectInBlock(c, 6);
        }
        lines.SetActive(true);
    }
    void SpawnOnField(GameObject a, GameObject b, GameObject c, GameObject d)
    {
        a.GetComponent<Button>().interactable = true;
        b.GetComponent<Button>().interactable = true;
        c.GetComponent<Button>().interactable = true;
        d.GetComponent<Button>().interactable = true;

        if (currentTrial == 19)
        {
            SpawnObjectInBlock(a, 2);
            SpawnObjectInBlock(b, 1);
            SpawnObjectInBlock(c, 5);
            SpawnObjectInBlock(d, 9);
        }
        if (currentTrial == 20)
        {
            SpawnObjectInBlock(a, 1);
            SpawnObjectInBlock(b, 2);
            SpawnObjectInBlock(c, 5);
            SpawnObjectInBlock(d, 9);
        }
        if (currentTrial == 21)
        {
            SpawnObjectInBlock(a, 3);
            SpawnObjectInBlock(b, 6);
            SpawnObjectInBlock(c, 8);
            SpawnObjectInBlock(d, 1);
        }
        if (currentTrial == 22)
        {
            SpawnObjectInBlock(a, 6);
            SpawnObjectInBlock(b, 4);
            SpawnObjectInBlock(c, 7);
            SpawnObjectInBlock(d, 2);
        }
        if (currentTrial == 23)
        {
            SpawnObjectInBlock(a, 8);
            SpawnObjectInBlock(b, 9);
            SpawnObjectInBlock(c, 4);
            SpawnObjectInBlock(d, 3);
        }
        if (currentTrial == 24)
        {
            SpawnObjectInBlock(a, 4);
            SpawnObjectInBlock(b, 6);
            SpawnObjectInBlock(c, 2);
            SpawnObjectInBlock(d, 8);
        }
        lines.SetActive(true);
    }

    void SpawnOnField(GameObject a, GameObject b, GameObject c, GameObject d, GameObject e)
    {
        a.GetComponent<Button>().interactable = true;
        b.GetComponent<Button>().interactable = true;
        c.GetComponent<Button>().interactable = true;
        d.GetComponent<Button>().interactable = true;
        e.GetComponent<Button>().interactable = true;

        if (currentTrial == 25)
        {
            SpawnObjectInBlock(a, 1);
            SpawnObjectInBlock(b, 3);
            SpawnObjectInBlock(c, 5);
            SpawnObjectInBlock(d, 7);
            SpawnObjectInBlock(e, 9);
        }
        if (currentTrial == 26)
        {
            SpawnObjectInBlock(a, 6);
            SpawnObjectInBlock(b, 7);
            SpawnObjectInBlock(c, 8);
            SpawnObjectInBlock(d, 5);
            SpawnObjectInBlock(e, 3);
        }
        if (currentTrial == 27)
        {
            SpawnObjectInBlock(a, 2);
            SpawnObjectInBlock(b, 3);
            SpawnObjectInBlock(c, 6);
            SpawnObjectInBlock(d, 7);
            SpawnObjectInBlock(e, 9);
        }
        if (currentTrial == 28)
        {
            SpawnObjectInBlock(a, 7);
            SpawnObjectInBlock(b, 3);
            SpawnObjectInBlock(c, 9);
            SpawnObjectInBlock(d, 2);
            SpawnObjectInBlock(e, 6);
        }
        if (currentTrial == 29)
        {
            SpawnObjectInBlock(a, 6);
            SpawnObjectInBlock(b, 1);
            SpawnObjectInBlock(c, 2);
            SpawnObjectInBlock(d, 8);
            SpawnObjectInBlock(e, 5);
        }
        if (currentTrial == 30)
        {
            SpawnObjectInBlock(a, 2);
            SpawnObjectInBlock(b, 7);
            SpawnObjectInBlock(c, 8);
            SpawnObjectInBlock(d, 5);
            SpawnObjectInBlock(e, 4);
        }
        lines.SetActive(true);
    }
    void SpawnOnField(GameObject a, GameObject b, GameObject c, GameObject d, GameObject e, GameObject f)
    {
        a.GetComponent<Button>().interactable = true;
        b.GetComponent<Button>().interactable = true;
        c.GetComponent<Button>().interactable = true;
        d.GetComponent<Button>().interactable = true;
        e.GetComponent<Button>().interactable = true;
        f.GetComponent<Button>().interactable = true;

        if (currentTrial == 31)
        {
            SpawnObjectInBlock(a, 2);
            SpawnObjectInBlock(b, 7);
            SpawnObjectInBlock(c, 8);
            SpawnObjectInBlock(d, 5);
            SpawnObjectInBlock(e, 4);
            SpawnObjectInBlock(f, 6);
        }
        if (currentTrial == 32)
        {
            SpawnObjectInBlock(a, 7);
            SpawnObjectInBlock(b, 6);
            SpawnObjectInBlock(c, 3);
            SpawnObjectInBlock(d, 4);
            SpawnObjectInBlock(e, 9);
            SpawnObjectInBlock(f, 2);
        }
        if (currentTrial == 33)
        {
            SpawnObjectInBlock(a, 1);
            SpawnObjectInBlock(b, 3);
            SpawnObjectInBlock(c, 6);
            SpawnObjectInBlock(d, 4);
            SpawnObjectInBlock(e, 7);
            SpawnObjectInBlock(f, 5);
        }
        if (currentTrial == 34)
        {
            SpawnObjectInBlock(a, 8);
            SpawnObjectInBlock(b, 7);
            SpawnObjectInBlock(c, 4);
            SpawnObjectInBlock(d, 6);
            SpawnObjectInBlock(e, 3);
            SpawnObjectInBlock(f, 2);
        }
        if (currentTrial == 35)
        {
            SpawnObjectInBlock(a, 2);
            SpawnObjectInBlock(b, 6);
            SpawnObjectInBlock(c, 7);
            SpawnObjectInBlock(d, 9);
            SpawnObjectInBlock(e, 5);
            SpawnObjectInBlock(f, 4);
        }
        if (currentTrial == 36)
        {
            SpawnObjectInBlock(a, 8);
            SpawnObjectInBlock(b, 7);
            SpawnObjectInBlock(c, 9);
            SpawnObjectInBlock(d, 1);
            SpawnObjectInBlock(e, 3);
            SpawnObjectInBlock(f, 5);
        }
        lines.SetActive(true);
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

        if (currentTrial == 37)
        {
            SpawnObjectInBlock(a, 5);
            SpawnObjectInBlock(b, 1);
            SpawnObjectInBlock(c, 2);
            SpawnObjectInBlock(d, 3);
            SpawnObjectInBlock(e, 7);
            SpawnObjectInBlock(f, 9);
            SpawnObjectInBlock(g, 6);
        }
        if (currentTrial == 38)
        {
            SpawnObjectInBlock(a, 9);
            SpawnObjectInBlock(b, 3);
            SpawnObjectInBlock(c, 6);
            SpawnObjectInBlock(d, 7);
            SpawnObjectInBlock(e, 2);
            SpawnObjectInBlock(f, 8);
            SpawnObjectInBlock(g, 1);
        }
        if (currentTrial == 39)
        {
            SpawnObjectInBlock(a, 1);
            SpawnObjectInBlock(b, 3);
            SpawnObjectInBlock(c, 4);
            SpawnObjectInBlock(d, 9);
            SpawnObjectInBlock(e, 7);
            SpawnObjectInBlock(f, 5);
            SpawnObjectInBlock(g, 6);
        }
        if (currentTrial == 40)
        {
            SpawnObjectInBlock(a, 4);
            SpawnObjectInBlock(b, 6);
            SpawnObjectInBlock(c, 5);
            SpawnObjectInBlock(d, 8);
            SpawnObjectInBlock(e, 7);
            SpawnObjectInBlock(f, 2);
            SpawnObjectInBlock(g, 1);
        }
        if (currentTrial == 41)
        {
            SpawnObjectInBlock(a, 8);
            SpawnObjectInBlock(b, 4);
            SpawnObjectInBlock(c, 1);
            SpawnObjectInBlock(d, 5);
            SpawnObjectInBlock(e, 6);
            SpawnObjectInBlock(f, 3);
            SpawnObjectInBlock(g, 9);
        }
        if (currentTrial == 42)
        {
            SpawnObjectInBlock(a, 6);
            SpawnObjectInBlock(b, 7);
            SpawnObjectInBlock(c, 8);
            SpawnObjectInBlock(d, 9);
            SpawnObjectInBlock(e, 3);
            SpawnObjectInBlock(f, 2);
            SpawnObjectInBlock(g, 1);
        }
        lines.SetActive(true);
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

        if (currentTrial == 43)
        {
            SpawnObjectInBlock(a, 1);
            SpawnObjectInBlock(b, 3);
            SpawnObjectInBlock(c, 4);
            SpawnObjectInBlock(d, 9);
            SpawnObjectInBlock(e, 7);
            SpawnObjectInBlock(f, 8);
            SpawnObjectInBlock(g, 6);
            SpawnObjectInBlock(h, 2);
        }
        if (currentTrial == 44)
        {
            SpawnObjectInBlock(a, 5);
            SpawnObjectInBlock(b, 6);
            SpawnObjectInBlock(c, 1);
            SpawnObjectInBlock(d, 3);
            SpawnObjectInBlock(e, 8);
            SpawnObjectInBlock(f, 9);
            SpawnObjectInBlock(g, 7);
            SpawnObjectInBlock(h, 2);
        }
        if (currentTrial == 45)
        {
            SpawnObjectInBlock(a, 6);
            SpawnObjectInBlock(b, 7);
            SpawnObjectInBlock(c, 8);
            SpawnObjectInBlock(d, 1);
            SpawnObjectInBlock(e, 3);
            SpawnObjectInBlock(f, 2);
            SpawnObjectInBlock(g, 9);
            SpawnObjectInBlock(h, 4);
        }
        if (currentTrial == 46)
        {
            SpawnObjectInBlock(a, 6);
            SpawnObjectInBlock(b, 5);
            SpawnObjectInBlock(c, 2);
            SpawnObjectInBlock(d, 3);
            SpawnObjectInBlock(e, 8);
            SpawnObjectInBlock(f, 1);
            SpawnObjectInBlock(g, 7);
            SpawnObjectInBlock(h, 9);
        }
        if (currentTrial == 47)
        {
            SpawnObjectInBlock(a, 5);
            SpawnObjectInBlock(b, 2);
            SpawnObjectInBlock(c, 3);
            SpawnObjectInBlock(d, 6);
            SpawnObjectInBlock(e, 7);
            SpawnObjectInBlock(f, 8);
            SpawnObjectInBlock(g, 1);
            SpawnObjectInBlock(h, 9);
        }
        if (currentTrial == 48)
        {
            SpawnObjectInBlock(a, 6);
            SpawnObjectInBlock(b, 1);
            SpawnObjectInBlock(c, 8);
            SpawnObjectInBlock(d, 9);
            SpawnObjectInBlock(e, 7);
            SpawnObjectInBlock(f, 5);
            SpawnObjectInBlock(g, 4);
            SpawnObjectInBlock(h, 3);
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
}
