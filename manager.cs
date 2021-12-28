using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    [SerializeField]
    GameObject pause_pan;

    int cur;
    bool paused;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        paused = false;
        cur = SceneManager.GetActiveScene().buildIndex;
        pause_pan.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                resume();
                
            }
            else
            {
                Cursor.visible = true;
                paused = true;
                pause_pan.SetActive(true);
            }
        }
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }

    public void restart()
    {
        SceneManager.LoadScene(cur);
    }

    public void next()
    {
        SceneManager.LoadScene(cur + 1);
        PlayerPrefs.SetInt("level", cur + 1);
    }

    public void resume()
    {
        Cursor.visible = false;
        paused = false;
        pause_pan.SetActive(false);

    }
}
