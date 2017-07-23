using UnityEngine;
using System.Collections;
using Core;
using State;

public class FoodSlider : Entity
{
    public UnityEngine.UI.Slider foodSlider;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var playerState = FindObjectOfType<PlayerState>();
        foodSlider.value = (float)playerState.Food / playerState.FoodCapacity;
    }
}
