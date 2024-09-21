using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private Transform menu;

    [SerializeField]
    private Text fpsText;
    private float pollingTime = 1f;
    private float time;
    private int frameCount;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            ToggleMenu();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            menu.gameObject.SetActive(false);
        }

        FPSCounter();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }

    void ToggleMenu()
    {
        if(menu.gameObject.activeInHierarchy == false)
        {
            menu.gameObject.SetActive(true);
        }
        else
        {
            menu.gameObject.SetActive(false);
        }
    }

    void FPSCounter()
    {
        time += Time.deltaTime;
        frameCount++;

        if(time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            fpsText.text = "    FPS: " + frameRate.ToString();
            time -= pollingTime;
            frameCount = 0;
        }
    }
}
