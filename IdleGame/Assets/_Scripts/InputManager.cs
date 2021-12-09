using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Transform popupPrefab;
   
    private void Update()
    {
        if (Input.touchSupported)
        {
            TouchInput();
        }
        else
        {
            MouseInput();
        }
    }

    private void OpenPopup(bool val)
    {
        popupPrefab.gameObject.SetActive(val);
    }

    private void ShootRaycast(Ray ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var building = hit.transform.GetComponent<Building>();
            if (building)
            {
                OpenPopup(true);
                BuildingPopup.Instance.DisplayBuildingInfo(building);
            }
            else
            {
                OpenPopup(false);
            }
        }
    }

    private void TouchInput()
    {
        var touches = Input.touchCount;
        if (touches > 0)
        {
            for (int i = 0; i < touches; i++)
            {
                var touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Began)
                {
                    if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                        return;

                    ShootRaycast(Camera.main.ScreenPointToRay(touch.position));
                }
            }
        }
    }

    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            ShootRaycast(Camera.main.ScreenPointToRay(Input.mousePosition));
        }
    }
}
