using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {


    [SerializeField]
    private int scene;
    [SerializeField]
    private Text loadingText;
    [SerializeField]
    private GameObject StartButton;
    [SerializeField]
    private GameObject QuitButton;


    // Updates once per frame
    public void LoadLevel()
    {

        // ...change the instruction text to read "Loading..."
        loadingText.text = "Loading...";

        // ...and start a coroutine that will load the desired scene.
        StartCoroutine(LoadNewScene());

        StartButton.SetActive(false);
        QuitButton.SetActive(false);
        loadingText.gameObject.SetActive(true);

        // ...then pulse the transparency of the loading text to let the player know that the computer is still working.
        loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b,
            Mathf.PingPong(Time.time, 1));

    }




    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    IEnumerator LoadNewScene()
    {
        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone)
        {
            yield return null;
        }

    }
}