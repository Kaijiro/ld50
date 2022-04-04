using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Store()
    {
        SceneManager.LoadScene(3);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Help(){
        SceneManager.LoadScene(4);
    }
}
