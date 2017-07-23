using UnityEngine;
using System.Collections;
using Core;

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
        var playerState = Application.Model.PlayerState;
        foodSlider.value = (float)playerState.Food / playerState.FoodCapacity;
    }
}
