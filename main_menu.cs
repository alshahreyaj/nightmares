using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{

    [SerializeField]
    GameObject set_pan, crd_pan, main_pan;

    int id;
    // Start is called before the first frame update
    void Start()
    {
        id = PlayerPrefs.GetInt("level");
        main_pan.SetActive(true);
        set_pan.SetActive(false);
        crd_pan.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void setting()
    {
        main_pan.SetActive(false);
        set_pan.SetActive(true);
    }

    public void cradit()
    {
        main_pan.SetActive(false);
        crd_pan.SetActive(true);
    }

    public void back()
    {
        main_pan.SetActive(true);
        set_pan.SetActive(false);
        crd_pan.SetActive(false);
    }


    public void exit()
    {
        Application.Quit();
    }

    public void cont()
    {
        if(id > 0)
        {
            SceneManager.LoadScene(id);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void new_game()
    {
        PlayerPrefs.SetInt("level", 1);
        SceneManager.LoadScene(1);
    }
}
