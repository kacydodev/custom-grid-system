using UnityEngine;
using UnityEngine.InputSystem;

public class MouseRaycast : MonoBehaviour
{
  static Camera targetCamera;
  [SerializeField] GridSystem gridSystem;

  void Start() {
    targetCamera = Camera.main;
  }

  void Update() {}

  public static Vector3 GetMousePosition() {
    Vector2 mousePosition = Mouse.current.position.ReadValue();
    Ray ray = targetCamera.ScreenPointToRay(mousePosition);

    if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue))
    {
      return hit.point;
    }
    
    return Vector3.zero;
  }
}