using System;
using UnityEngine;

public class GroundPlacement : MonoBehaviour {

    [SerializeField]
    private GameObject [] placeableGOs;

    private GameObject currentGO;

    private float mouseWheelRotation;
    private int currentPrefabIndex = -1;
    public bool isBeingPlaced = false;
	
	// Update is called once per frame
	void Update () {
        {
            HandleNewObjectHotkey();

            if (currentGO != null) {
                MoveCurrentObjectToMouse();
                RotateFromMouseWheel();
                ReleaseIfClicked();
            }
        }
	}

    void HandleNewObjectHotkey()
    {
        
        for (int i = 0; i < placeableGOs.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + 1 + i))
            {
                isBeingPlaced = true;
                if (PressedKeyOfCurrentPrefab(i))
                {
                    Destroy(currentGO);
                    currentPrefabIndex = -1;
                }
                else
                {
                    if (currentGO != null)
                    {
                        Destroy(currentGO);
                    }
                    currentGO = Instantiate(placeableGOs[i]);
                    currentPrefabIndex = i;
                }
                break;
            }
        }
    }

    private bool PressedKeyOfCurrentPrefab(int i)
    {
        return currentGO != null && currentPrefabIndex == i;
    }

    void MoveCurrentObjectToMouse() {
        Cursor.visible = false;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo)) {
            
                currentGO.transform.position = hitInfo.point;
                currentGO.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);         
        }
    }

    void RotateFromMouseWheel() {
        mouseWheelRotation += Input.mouseScrollDelta.y;
        currentGO.transform.Rotate(Vector3.up, mouseWheelRotation * 10f);
    }

    void ReleaseIfClicked() {
        if (Input.GetMouseButtonDown(0)) {
            isBeingPlaced = false;
            currentGO = null;
        }
    }
}
