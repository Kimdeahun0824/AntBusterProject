using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretCreator_Btn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Camera mainCamera;
    public Vector2 mousePosition;
    public Transform parent;
    public GameObject turretPrefab;
    public GameObject turretImagePrefab;

    public GameObject tempCreateObj;


    public void OnDrag(PointerEventData eventData)
    {
        // GFunc.Log($"OnPointerDown TEST : {eventData.position}");
        mousePosition = eventData.position;
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
        tempCreateObj.transform.position = mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        mousePosition = eventData.position;
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
        tempCreateObj = Instantiate(turretImagePrefab, mousePosition, Quaternion.identity, parent);
        GFunc.Log($"OnPointerDown TEST : {tempCreateObj.name}");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Destroy(tempCreateObj);
        mousePosition = eventData.position;
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
        Instantiate(turretPrefab, mousePosition, Quaternion.identity, parent);
    }

}
