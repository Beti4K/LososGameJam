using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    private GameObject player;

    [SerializeField] float leftBorder;
    [SerializeField] float rightBorder;

    [SerializeField] private Camera cam;

    private readonly Vector2 targetAspectRatio = new Vector2(16, 9);
    private readonly Vector2 rectCenter = new Vector2(0.5f, 0.5f);

    private Vector2 lastResolution;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, transform.position.z);

        if (player.transform.position.x > rightBorder)
        {
            transform.position = new Vector3(rightBorder, player.transform.position.y, transform.position.z);
        }

        if (player.transform.position.x < leftBorder)
        {
            transform.position = new Vector3(leftBorder, player.transform.position.y, transform.position.z);
        }
    }

    //Camera aspect ratio control below

    private void OnValidate()
    {
        cam = GetComponent<Camera>();
    }

    public void LateUpdate()
    {
        var currentScreenResolution = new Vector2(Screen.width, Screen.height);

        // Don't run all the calculations if the screen resolution has not changed
        if (lastResolution != currentScreenResolution)
        {
            CalculateCameraRect(currentScreenResolution);
        }

        lastResolution = currentScreenResolution;
    }

    private void CalculateCameraRect(Vector2 currentScreenResolution)
    {
        var normalizedAspectRatio = targetAspectRatio / currentScreenResolution;
        var size = normalizedAspectRatio / Mathf.Max(normalizedAspectRatio.x, normalizedAspectRatio.y);
        cam.rect = new Rect(default, size) { center = rectCenter };
    }
}
