using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuHandler : MonoBehaviour
{
    public void ExitApp()
    {
        Application.Quit();
    }

    public void ChangeScreen(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
    
}
