using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonTestHandler : MonoBehaviour
{
    
    public string nique;
    
    public void Task(string param)
    {
    	SceneManager.LoadScene(param ,LoadSceneMode.Single);
    }
}
