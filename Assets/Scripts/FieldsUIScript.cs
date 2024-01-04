using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UIElements;

public class FieldsUIScript : MonoBehaviour
{

    private int cropQuantity = 0;
    private Label cropQuantityLabel;
    private Button plantButton;
    private ProgressBar growthProgress;
    private Label growthProgressLabel;

    private bool isButtonEnabled = true;

    void Start()
    {
        cropQuantityLabel = GetComponent<UIDocument>().rootVisualElement.Q<Label>("CropQuantity");
        plantButton = GetComponent<UIDocument>().rootVisualElement.Q<Button>("PlantButton");
        growthProgress = GetComponent<UIDocument>().rootVisualElement.Q<ProgressBar>("growthProgress");

        // Try to find the label within the children of growthProgress
        growthProgressLabel = FindLabelInChildren(growthProgress);

        if (cropQuantityLabel != null && plantButton != null && growthProgress != null && growthProgressLabel != null)
        {
            plantButton.clicked += OnPlantButtonClick;
            UpdateCropQuantityLabel();
        }
        else
        {
            Debug.LogError("Plant Button, Crop Quantity Label, Progress Bar, or Progress Bar Label not found!");
        }
    }

    void OnPlantButtonClick()
    {
        if (isButtonEnabled)
        {
            StartCoroutine(EnableButtonAfterDelay(5f)); // Adjust the delay time as needed
            cropQuantity++;
            Debug.Log("Plant Button Clicked! Crop Quantity: " + cropQuantity);
            UpdateCropQuantityLabel();
            // Your button press logic goes here
        }
    }

    void UpdateCropQuantityLabel()
    {
        cropQuantityLabel.text = "Crop Quantity: " + cropQuantity;
    }

    IEnumerator EnableButtonAfterDelay(float delay)
    {
        isButtonEnabled = false;
        plantButton.SetEnabled(false);

        float timer = delay;

        while (timer > 0f)
        {
            growthProgress.value = 1 - (timer / delay);
            growthProgressLabel.text = "Time Remaining: " + Mathf.CeilToInt(timer);
            timer -= Time.deltaTime;
            yield return null;
        }

        growthProgress.value = 1f; // Ensure the progress bar is fully filled
        isButtonEnabled = true;
        plantButton.SetEnabled(true);
        growthProgress.value = 0f; // Reset the progress bar for the next use
        growthProgressLabel.text = "Time Remaining: 0";
    }

    // Recursive method to find a Label component within the children of a VisualElement
    Label FindLabelInChildren(VisualElement parent)
    {
        foreach (var child in parent.Children())
        {
            Label label = child.Q<Label>();
            if (label != null)
            {
                return label;
            }

            // Recursive call to search in the children of the current child
            Label foundLabel = FindLabelInChildren(child);
            if (foundLabel != null)
            {
                return foundLabel;
            }
        }

        return null;
    }
}