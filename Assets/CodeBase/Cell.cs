using UnityEngine;

public class Cell : MonoBehaviour
{
    public CellType Type;

    private Renderer rend;
    private Color originalColor;
    public Color highlightColor = Color.yellow;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    public void Highlight()
    {
        if (rend != null)
            rend.material.color = highlightColor;
    }

    public void Unhighlight()
    {
        if (rend != null)
            rend.material.color = originalColor;
    }
}