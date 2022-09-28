using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class VSBackend : MonoBehaviour
{
    public List<GameObject> sequenzList = new List<GameObject>();
    public List<GameObject> clickedList = new List<GameObject>();

    public static Stopwatch timer = new Stopwatch();


    public int listCompareVar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearLists()
    {
        CompareLists();
        sequenzList.Clear();
        clickedList.Clear();
    }

    public void CompareLists()
    {
        int x = clickedList.Count;
        int y = sequenzList.Count;
        int[] clicks = {-1, -1};
        listCompareVar = 1;

        if (x != y)
        {
            listCompareVar = 0;
        }

        for (int i = 0; i < x; i++)
        {
            if (clickedList[i] == sequenzList[i])
            {
                clicks[i] = 1;
                //accuracyCounter++;
            }


            if (clickedList[i] != sequenzList[i])
            {
                clicks[i] = 0;
                listCompareVar = 0;
            }
        }
    }
}
