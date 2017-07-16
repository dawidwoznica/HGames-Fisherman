using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishController : MonoBehaviour
{
    private int _randomValue;
    private RectTransform _fishRectTransform;
    private Vector2 _start;
    private Vector2 _destination;
    public float Speed;
    public Sprite Fish;


    void Awake()
    {
        _fishRectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        _randomValue = Random.Range(-600, 600); // draw a random movement length value
        Speed = Random.Range(0.5f, 2); // then draw speed 
        _start = _fishRectTransform.anchoredPosition; // save the starting position
        _destination = new Vector2(0, _randomValue); // and set the movement destination point

        _fishRectTransform.anchoredPosition = Vector2.Lerp(_start, _destination, Time.deltaTime * Speed); // then I used Lerp function to move the 'fish'
    }

    public void DrawFish()
    {
        /// <summary>
        /// This function simply draw random fish from array depending on it's rarity and save the sprite to Fish variable.
        /// </summary>
         
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

