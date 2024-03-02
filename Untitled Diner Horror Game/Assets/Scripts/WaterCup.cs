using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCup : MonoBehaviour
{
    private Renderer waterCupRenderer;
    private Color originalColor;

    void Start()
    {
        waterCupRenderer = GetComponent<Renderer>();
        originalColor = waterCupRenderer.material.color;
    }

    public void HighlightCup(Color highlightColor)
    {
        if (waterCupRenderer != null)
        {
            waterCupRenderer.material.color = highlightColor;
        }
    }

    public void ResetColor()
    {
        if (waterCupRenderer != null)
        {
            waterCupRenderer.material.color = originalColor;
        }
    }
}
