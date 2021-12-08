﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Transform popup;
    private Popup popupClass;

    private void Awake()
    {
        popupClass = popup.GetComponent<Popup>();
    }

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
        popup.gameObject.SetActive(val);
    }

    private void GetBuilding(Building building)
    {
        popupClass.SetBuildingInfo(building);
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
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit) && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                    {
                        var building = hit.transform.CompareTag("Building");
                        if (building)
                        {
                            OpenPopup(true);
                            GetBuilding(hit.transform.GetComponent<Building>());
                        }
                        else
                        {
                            OpenPopup(false);
                        }
                    }
                }
            }
        }
    }

    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && !EventSystem.current.IsPointerOverGameObject())
            {
                var building = hit.transform.CompareTag("Building");
                if (building)
                {
                    OpenPopup(true);
                    GetBuilding(hit.transform.GetComponent<Building>());
                }
                else
                {
                    OpenPopup(false);
                }
            }
        }
    }
}