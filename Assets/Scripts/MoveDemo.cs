using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDemo : MonoBehaviour
{
    private float mZcord;
    private Vector3 posdif;
    private void OnMouseDown()
    {
        mZcord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        posdif = gameObject.transform.position - mouseAsWorldPoint();
    }
    private void OnMouseDrag()
    {
        transform.position = mouseAsWorldPoint()+posdif;
    }
    private Vector3 mouseAsWorldPoint()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mZcord;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
