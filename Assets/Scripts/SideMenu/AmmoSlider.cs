using UnityEngine;
using System.Collections;
using Core;

public class AmmoSlider : Entity
{
    public UnityEngine.UI.Slider ammoSlider;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var playerState = Application.Model.PlayerState;
        ammoSlider.value = (float)playerState.Ammo / playerState.AmmoCapacity;
    }
}
