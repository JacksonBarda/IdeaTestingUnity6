using UnityEngine;


public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera mainCamera;

    
    void Start()
    {


        mainCamera = Camera.main;
    }

    void Update()
    {
        if (isDragging)
        {
            DragObject();
        }
    }

    void OnMouseDown()
    {
        if (GameManager.Instance != null &&
            (GameManager.Instance.CurrentState == GameManager.GameState.Prep || 
             GameManager.Instance.CurrentState == GameManager.GameState.Store))
        {
            isDragging = true;

            // Convert mouse position to world space and calculate the offset
            Vector3 mouseWorldPosition = GetMouseWorldPosition();
            offset = transform.position - mouseWorldPosition;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    private void DragObject()
    {
        // Convert mouse position to world space and apply the offset
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        transform.position = mouseWorldPosition + offset;

    }

    private Vector3 GetMouseWorldPosition()
    {
        // Get the mouse position in screen space
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Set the z-coordinate to match the object's distance from the camera
        mouseScreenPosition.z = mainCamera.WorldToScreenPoint(transform.position).z;

        // Convert the screen position to world space
        return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }
}
