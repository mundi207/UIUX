using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMentV : MonoBehaviour
{
    public Transform TargetObj;

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x,TargetObj.position.y,0);
        transform.position = new Vector3(transform.position.x,TargetObj.position.y,0);
    }
}
