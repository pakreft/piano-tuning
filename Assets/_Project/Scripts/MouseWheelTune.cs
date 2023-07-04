using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseWheelTune : MonoBehaviour
{
    public float minValue = 0f;
    public float maxValue = 10f;
    public float sensitivity = 1f;
    public float targetValue = 5f;
    
    public Slider slider; // Verweis auf die Slider-Komponente

    void Update()
    {
        float scrollDelta = Input.mouseScrollDelta.y;

        targetValue += scrollDelta * sensitivity;
        targetValue = Mathf.Clamp(targetValue, minValue, maxValue);

        if (targetValue >= 3f && targetValue <= 5f)
        {
            Debug.Log("Im Bereich!");
        }
        else
        {
            Debug.Log("Außerhalb des Bereichs!");
        }

        // Aktualisiere den Wert des Sliders
        slider.value = targetValue / maxValue;
    }
}
