using UnityEngine;

public class GridSystem
{
  int width;
  int height;
  float cellSize;

  public GridSystem(int width, int height, float cellSize) {
    this.width = width;
    this.height = height;
    this.cellSize = cellSize;
  }

  // Convert grid position to world position
  public Vector3 GetWorldPosition(int x, int z) {
    return new Vector3(x, 0, z) * cellSize;
  }
  
  // Convert world position to grid position imposed by custom grid system
  public GridPosition GetGridPosition(Vector3 worldPosition)
  {
    return new GridPosition(
      Mathf.FloorToInt(worldPosition.x / cellSize),
      Mathf.FloorToInt(worldPosition.z / cellSize)
    );
  }
  
  public void DrawGridObject(int x, int z, Color color, float duration = 1000f)
  {
    Vector3 bottomLeft  = GetWorldPosition(x, z);
    Vector3 bottomRight = GetWorldPosition(x + 1, z);
    Vector3 topLeft     = GetWorldPosition(x, z + 1);
    Vector3 topRight    = GetWorldPosition(x + 1, z + 1);

    // Bottom edge
    Debug.DrawLine(bottomLeft, bottomRight, color, duration);
    // Left edge
    Debug.DrawLine(bottomLeft, topLeft, color, duration);
    // Top edge
    Debug.DrawLine(topLeft, topRight, color, duration);
    // Right edge
    Debug.DrawLine(bottomRight, topRight, color, duration);
  }
}