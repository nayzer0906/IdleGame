using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform popup;
    private void Update()
    {
        if (Input.touchSupported)
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
                            if (hit.transform.GetComponent<Building>())
                            {
                                popup.gameObject.SetActive(true);
                            }
                            else
                            {
                                popup.gameObject.SetActive(false);
                            }
                        }
                    }
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && !EventSystem.current.IsPointerOverGameObject())
                {
                    if (hit.transform.GetComponent<Building>())
                    {
                        popup.gameObject.SetActive(true);
                    }
                    else
                    {
                        popup.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
