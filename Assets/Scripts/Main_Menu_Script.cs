using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Script : MonoBehaviour
{

    public void open_game_scene() 
    {
        SceneManager.LoadSceneAsync(1);    
    }

    public void close_app() 
    {
        Application.Quit();
    }
}
