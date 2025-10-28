using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncechk : MonoBehaviour

/// <summary>
/// Keeps the GameObject within the screen bounds, this script assumes the camera is orthographic
/// </summary>
{
    [Header("Dynamic")]
    public float camWidth;
    public float camHeight;

    private void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;

    }


    //LateUpdate is called every frame after update has been called on all game objects
    void LateUpdate()
    {
        Vector3 pos = transform.position;

        //restrict the x position
        if(pos.x > camWidth)
        {
            pos.x = camWidth;

        }
        if(pos.x < -camWidth)
        {
            pos.x = -camWidth;
        }

        //restrict y position
        if(pos.y > camHeight)
        {
            pos.y = camHeight;
        }
        if(pos.y < -camHeight){
            pos.y = -camHeight;

        }
        transform.position = pos;
    }
}
