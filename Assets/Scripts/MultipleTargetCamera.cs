﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour
{
    #region PUBLIC
    public List<Transform> targets;
    [Space]
    public Vector3 offset;
    [Space]
    public float smoothTime = .5f;
    [Space]
    public float minZoom;
    public float maxZoom;
    public float zoomLimiter;
    [Header("Camera Shake Values")]
    CameraShake cameraShake;
    [Space]
    public float magnitude;
    public float duration;
    #endregion

    #region PRIVATE
    private Vector3 velocity;
    private Camera cam;
    #endregion


    void Start()
    {
        cam = GetComponent<Camera>();
        cameraShake = GetComponent<CameraShake>();
    }

    void Update()
    {
        //cameraShake.Shake(duration, magnitude);
    }

    void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }

        Zoom();
        Move();
    }

    void Zoom()
    {
        //Debug.Log(GetGreatestDistance());
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
}
