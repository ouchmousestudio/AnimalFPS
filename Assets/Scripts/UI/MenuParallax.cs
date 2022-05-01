using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuParallax : MonoBehaviour
{
    //Move the camera with mouse movement

    private Vector3 pos;
    private Vector3 startPos;
    [SerializeField] Camera camera;
    [SerializeField] float amount = -8f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        pos = camera.ScreenToViewportPoint(Input.mousePosition);
        pos.z = 0;
        Debug.Log("pos" + pos);
        transform.position = pos;
        transform.position = new Vector3(startPos.x + (pos.x * amount), startPos.y + (pos.y * amount), 0);
        Debug.Log("transform" + transform.position);
    }
}
