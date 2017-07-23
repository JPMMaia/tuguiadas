using UnityEngine;
using System.Collections;
using Core;
using State;

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
        var playerState = FindObjectOfType<PlayerState>();
        crewSlider.value = (float)playerState.CrewHealth / playerState.CrewMaxHealth;
    }
}
