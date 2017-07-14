using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishController : MonoBehaviour
{
    private RectTransform _rect;
    private int _randomValue;
    private Vector3 _start;
    private Vector3 _destination;
    public int Speed;
    public Sprite Fish;


    void Start()
    {
        _rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        _randomValue = Random.Range(-700, 700);
        Speed = Random.Range(1, 4);
        _start = _rect.anchoredPosition;
        _destination = new Vector3(0, _randomValue, 0);

        _rect.anchoredPosition = Vector3.Lerp(_start, _destination, Time.deltaTime * Speed / 2);
    }

    public void GetFish()
    {
        int random = Random.Range(1, 10);

        if (random < 8)
        {
            int randomIndex = Random.Range(0, GameManager.FishManager.NormalFish.Length);
            Fish = GameManager.FishManager.NormalFish[randomIndex];
        }

        else if (random >= 8)
        {
            int randomIndex = Random.Range(0, GameManager.FishManager.RareFish.Length);
            Fish = GameManager.FishManager.RareFish[randomIndex];
        }
    }
}

