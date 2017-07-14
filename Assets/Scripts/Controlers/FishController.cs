using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FishController : MonoBehaviour
{
    private RectTransform _rect;
    public int Speed = 1;
    private int _randomValue;
    private Vector3 _start;
    private Vector3 _destination;

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
        
        _rect.anchoredPosition = Vector3.Lerp(_start, _destination, Time.deltaTime * Speed / 3);
    

    }

 
}

