using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string SceneName { get; private set; }

    private void Start() 
    {
        SceneNameSet();
    }
    
    public void Change(string Name)
    {
        SceneManager.LoadScene(Name);
        SceneNameSet();
    }

    public void Change(int Num)
    {
        SceneManager.LoadScene(Num);
        SceneNameSet();
    }

    private void SceneNameSet()
    {
        SceneName = SceneManager.GetActiveScene().ToString();
    }

}
