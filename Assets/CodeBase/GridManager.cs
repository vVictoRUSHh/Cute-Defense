using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width;
    public int height;
    public float cellSize = 1f;
    public GameObject cellPrefab;
    public Vector3 _offset;

    public Cell[,] grid;
    [ContextMenu("Create Game field")]
    private void CreateGrid()
    {
        grid = new Cell[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 pos = new Vector3(x * cellSize, 0, y * cellSize);
                GameObject cellGO = Instantiate(cellPrefab, pos + _offset , Quaternion.identity, transform);
                Cell cell = cellGO.GetComponent<Cell>();
                grid[x, y] = cell;

                cell.name = $"Cell {x},{y}";
            }
        }
    }

    public Cell GetCellFromWorldPosition(Vector3 worldPos)
    {
        int x = Mathf.FloorToInt(worldPos.x / cellSize);
        int y = Mathf.FloorToInt(worldPos.z / cellSize);

        if (x >= 0 && x < width && y >= 0 && y < height)
            return grid[x, y];
        return null;
    }
}