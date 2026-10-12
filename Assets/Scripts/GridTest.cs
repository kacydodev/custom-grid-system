using UnityEngine;
using UnityEngine.InputSystem;

public class Testing : MonoBehaviour
{
  [SerializeField] int width;
  [SerializeField] int height;
  [SerializeField] float cellSize;

  GridSystem gridSystem;

  void Start() {
    width = 10;
    height = 10;
    cellSize = 2f;
    gridSystem = new GridSystem(width, height, cellSize);

    for (int x = 0; x < width; x++)
    {
      for (int z = 0; z < height; z++)
      {
        gridSystem.DrawGridObject(x, z, Color.slateBlue);
      }
    }
  }

  void Update() {
    if (Mouse.current.leftButton.wasPressedThisFrame)
    {
      Vector3 mousePosition = MouseRaycast.GetMousePosition();
      GridPosition gridPosition = gridSystem.GetGridPosition(mousePosition);
      Debug.Log(gridPosition);
    }
  }
}