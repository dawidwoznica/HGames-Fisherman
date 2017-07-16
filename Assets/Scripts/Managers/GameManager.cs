using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public static FloatManager FloatManager;
    public static FishManager FishManager;
    public static ProgressBarManager ProgressBarManager;
    public static FishermanManager FishermanManager;
    public static WaterManager WaterManager;


    void Awake()
    {
        if (Instance == null) // check if instance exists
            Instance = this; // set instance
        else if (Instance != this) // if instance exists and it's not this
            Destroy(gameObject);    // destroy it

        DontDestroyOnLoad(gameObject); // dont destroy this when reloading scene
        GetManagers(); // get managers
    }

    private void GetManagers()
    {
        // get all managers component
        FloatManager = GetComponent<FloatManager>();
        FishManager = GetComponent<FishManager>();
        ProgressBarManager = GetComponent<ProgressBarManager>();
        FishermanManager = GetComponent<FishermanManager>();
        WaterManager = GetComponent<WaterManager>();
    }

}
