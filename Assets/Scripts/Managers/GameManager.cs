using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public static GameManager Instance;
    public static FloatManager FloatManager;

    void Awake()
    {
        if (Instance == null) // check if instance exists
            Instance = this; // set instance
        else if (Instance != this) // if instance exists and it's not this
            Destroy(gameObject);    // destroy it

        DontDestroyOnLoad(gameObject); // dont destroy this when reloading scene
        GetMenagers();
    }


    private void GetMenagers()
    {
        FloatManager = GetComponent<FloatManager>();


    }



}
