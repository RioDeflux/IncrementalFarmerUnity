using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuScript : MonoBehaviour
{
    public TextMeshProUGUI Fields;
    // Start is called before the first frame update
    void Start()
    {
        Fields.SetText(DisplayCorrectFieldsText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private string DisplayCorrectFieldsText()
    {
        var fieldCount = "0";
        var fieldCropType = "Wheat";

        return $"{fieldCount} - {fieldCropType}";
    }
}
