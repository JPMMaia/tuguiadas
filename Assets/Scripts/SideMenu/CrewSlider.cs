using UnityEngine;
using System.Collections;
using Core;

public class CrewSlider : Entity
{
    public UnityEngine.UI.Slider crewSlider;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var playerState = Application.Model.PlayerState;
        crewSlider.value = (float)playerState.CrewHealth / playerState.CrewMaxHealth;
    }
}
