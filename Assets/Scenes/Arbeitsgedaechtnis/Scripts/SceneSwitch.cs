using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    /*
     * Easy Scene Switcher index = 0 is the intro, 1 = the play scene, 2 = Outroscene
     * 
     */

    public static string inputVPN = "";
    public static bool reverse = false;
    public static bool reverseVS = true;

    public static int repeatGoNoGo;

    private void Start()
    {

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
        DataSaver.count = 1;
        DataSaver.results.Clear();
        Randomizer.countFalseTask = 0;
        Randomizer.totalTasks = 0;
        DataSaver.VPN = inputVPN;
        Randomizer.reverse = reverse;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
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
        
        
    }

    public void StartGoNoGO()
    {
        DataGoNoGO.timePointnogo.Clear();
        DataGoNoGO.overall.Clear();
        DataGoNoGO.results.Clear();
        DataGoNoGO.header.Clear();
        DataGoNoGO.z1.Clear();
        DataGoNoGO.VPN = inputVPN;
        repeatGoNoGo = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 11);
    }
    public void StartCardSorting()
    {
        CSDataSaver.VPN = inputVPN;
        CSDataSaver.ClearAllData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Debug.Log(CSDataSaver.fileName.ToString());
    }

    public void BackCardSorting()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 6);
    }

    public void StartWCST()
    {
        WCST_Data.timePointsts.Clear();
        WCST_Data.overall.Clear();
        WCST_Data.header.Clear();
        WCST_Data.practice.Clear();
        WCST_Data.test.Clear();
        WCST_Data.results.Clear();
        WCST_Data.VPN = inputVPN;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 16);
    }

    public void StartAX_CPT()
    {
        AX_Practice.buff = 0;
        AX_Data.timePointsts.Clear();
        AX_Data.header.Clear();
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
        VSData.timePointsts.Clear();
        VSData.overall.Clear();
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
        VSData.VPN = inputVPN;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 24);
    }

    public void StartCoverStoryIntro()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 28);
    }
    public void StartCoverStoryOutro()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 29);
    }
    public void StartCoverStoryFinal()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 30);
    }
}
