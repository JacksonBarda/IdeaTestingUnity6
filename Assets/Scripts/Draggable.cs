using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Assertions.Must;


public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera mainCamera;
    [SerializeField]
    private List<GameObject> childrenToDrag = new List<GameObject>();
    private List<Vector3> childOffsets = new List<Vector3>();
    
    void Start()
    {
        int i = 0;
        foreach (GameObject child in childrenToDrag)
        {

            //Debug.Log(childOffsets[0]);
            childOffsets.Add(child.transform.position - transform.position);

            i++;
        }
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
            offset = transform.position - Input.mousePosition;
            if(childrenToDrag.Count > 0)
            {

                int i = 0;
                foreach (GameObject child in childrenToDrag)
                {
                    childOffsets[i] = child.transform.position - transform.position;
                    i++;
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
        transform.position = Input.mousePosition + offset;
        if(childrenToDrag.Count > 0)
        {
            int i = 0;
            foreach (GameObject child in childrenToDrag)
            {
                child.transform.position = transform.position + childOffsets[i];
                i++;
            }
        }

    }


}
