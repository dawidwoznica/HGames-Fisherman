using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private int scene;
    [SerializeField]
    private Text loadingText;
    [SerializeField]
    private GameObject StartButton;
    [SerializeField]
    private GameObject QuitButton;


    void Update()
    {
        if (loadingText.gameObject.activeInHierarchy)
        {
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b,
            Mathf.PingPong(Time.time, 1)); // then pulse the transparency of the loading text to let the player know that the computer is still working
        }
    }

    public void LoadLevel()
    {
        loadingText.text = "Loading..."; // set text to loading

        StartCoroutine(LoadNewScene()); // start the coroutine that will load the scene

        StartButton.SetActive(false); // hide buttons
        QuitButton.SetActive(false);
        loadingText.gameObject.SetActive(true); // and show the loading text 
    }

    IEnumerator LoadNewScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(scene); // start async scene loading

        while (!async.isDone) // wait until async load will be completed
        {
            yield return null;
        }
    }

}