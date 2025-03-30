using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera mainCamera;
    [SerializeField]
    private List<GameObject> childrenToDrag = new List<GameObject>();
    
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
            offset = transform.position - GetMouseWorldPosition();
            if(childrenToDrag.Count > 0)
            {
                foreach (GameObject child in childrenToDrag)
                {
                    child.transform.position = transform.position;
                }
            }
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    private void DragObject()
    {
        transform.position = GetMouseWorldPosition() + offset;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = mainCamera.WorldToScreenPoint(transform.position).z;
        return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }
}
