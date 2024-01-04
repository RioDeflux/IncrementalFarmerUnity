using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomProgressBar : VisualElement
{
    private Slider customProgressBar;

    public CustomProgressBar(float minValue, float maxValue)
    {
        // Create a Slider with the specified min and max values
        customProgressBar = new Slider(minValue, maxValue);
        customProgressBar.style.flexGrow = 1;

        // Add the Slider to the CustomSlider VisualElement
        Add(customProgressBar);
    }

    // Property to get and set the value of the customProgressBar
    public float Value
    {
        get { return customProgressBar.value; }
        set { customProgressBar.value = value; }
    }
}
