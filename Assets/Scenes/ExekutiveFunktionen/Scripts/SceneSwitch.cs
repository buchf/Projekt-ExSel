using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    /*
     * Easy Scene Switcher index = 0 is the intro, 1 = the play scene, 2 = Outroscene
     * 
     */

    private string inputVPN = "";
    public static bool reverse = false;
    public static bool reverseVS = true;

    private void Start()
    {
        reverseVS = false;
    }
    public void StartGame()
    {
        DataSaver.z0.Clear();
        DataSaver.z1.Clear();
        DataSaver.z2.Clear();
        DataSaver.z3.Clear();
        DataSaver.z4.Clear();
        DataSaver.z5.Clear();
        DataSaver.z6.Clear();
        DataSaver.results.Clear();
        Randomizer.countFalseTask = 0;
        Randomizer.totalTasks = 0;
        DataSaver.VPN = inputVPN;
        Randomizer.reverse = reverse;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 123);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 126);
    }
    public void GoNoGoBackStart()
    {
        //GoNoGo.counter = 0;
        //GoNoGo.trial = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 131);
    }

    public void ReadInput(string s)
    {
        inputVPN = s;
    }

    public void SetReverse()
    {
        reverse = true;
    }

    public void StartGoNoGO()
    {
        
        DataGoNoGO.overall.Clear();
        DataGoNoGO.results.Clear();
        DataGoNoGO.header.Clear();
        DataGoNoGO.z1.Clear();
        DataGoNoGO.VPN = inputVPN;
        
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 127);
    }
    public void StartCardSorting()
    {
        CSPlay.correctResponse = 0;
        CSDataSaver.header.Clear();
        CSDataSaver.overall.Clear();
        CSDataSaver.results.Clear();
        CSDataSaver.practice.Clear();
        CSDataSaver.test.Clear();
        CSDataSaver.VPN = inputVPN;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 154);
        //Debug.Log(CSDataSaver.fileName.ToString());
    }

    public void BackCardSorting()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 159);
    }

    public void StartWCST()
    {
        WCST_Data.header.Clear();
        WCST_Data.practice.Clear();
        WCST_Data.test.Clear();
        WCST_Data.results.Clear();
        WCST_Data.VPN = inputVPN;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 16);
    }

    public void StartAX_CPT()
    {
        AX_Data.header.Clear();
        AX_Data.practice.Clear();
        AX_Data.test.Clear();
        AX_Data.overall.Clear();
        AX_Data.results.Clear();
        AX_Data.VPN = inputVPN;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 20);
    }

    public void SetVSbackwards()
    {
        reverseVS = true;
    }
    public void StartVS()
    {
        VSData.header.Clear();
        VSData.practiceOne.Clear();
        VSData.practiceTwo.Clear();
        VSData.testOne.Clear();
        VSData.testTwo.Clear();
        VSData.testThree.Clear();
        VSData.testFour.Clear();
        VSData.testFive.Clear();
        VSData.testSix.Clear();
        VSData.testSeven.Clear();
        VSData.testEigth.Clear();
        VSData.results.Clear();
        VSData.totalTask.Clear();
        VSData.VPN = inputVPN;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 24);
    }

}
