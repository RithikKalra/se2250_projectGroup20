using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameLoader : MonoBehaviour
{
    public static int playerType;
    public static int level;

    public void LoadGameKnight()
    {
        playerType = 1;
        level = 1;
        SceneManager.LoadScene("SampleScene");

    }
    public void LoadGameNinja()
    {
        playerType = 2;
        level = 1;
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadGameWizard()
    {
        playerType = 3;
        level = 1;
        SceneManager.LoadScene("SampleScene");
    }
    
}
