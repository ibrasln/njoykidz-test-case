using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenOffset = .8f;

    private float screenHalfWidth;

    private Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void Start()
    {
        float screenHalfHeight = Camera.main.orthographicSize;
        screenHalfWidth = screenHalfHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);

        float clampedX = Mathf.Clamp(mousePosition.x, -screenHalfWidth + screenOffset, screenHalfWidth - screenOffset);

        transform.position = new(clampedX, transform.position.y, transform.position.z);
    }
}
