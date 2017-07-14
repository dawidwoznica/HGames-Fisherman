using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour {

	public Sprite[] NormalFish;
    public Sprite[] RareFish;


    void Awake()
    {
        NormalFish = Resources.LoadAll<Sprite>("Sprites/Fish/Normal");
        RareFish = Resources.LoadAll<Sprite>("Sprites/Fish/Rare");
    }


}
