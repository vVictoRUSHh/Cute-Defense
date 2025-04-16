using UnityEngine;

public class CellHighlighter : MonoBehaviour
{
    public LayerMask cellLayer;
    private Cell lastHighlightedCell;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, cellLayer))
        {
            Cell cell = hit.collider.GetComponent<Cell>();
            if (cell != null)
            {
                if (lastHighlightedCell != null && lastHighlightedCell != cell)
                {
                    lastHighlightedCell.Unhighlight();
                }

                cell.Highlight();
                lastHighlightedCell = cell;
            }
        }
        else
        {
            if (lastHighlightedCell != null)
            {
                lastHighlightedCell.Unhighlight();
                lastHighlightedCell = null;
            }
        }
    }
}