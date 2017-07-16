using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnClick : MonoBehaviour
{
    [SerializeField]
    private int _scene;

    public void RestartGame()
    {
        SceneManager.LoadScene(_scene); // load scene
    }

}
