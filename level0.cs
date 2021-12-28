using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level0 : MonoBehaviour
{
    
    public void play()
    {
        PlayerPrefs.SetInt("level", 2);
        SceneManager.LoadScene(2);
    }
}
