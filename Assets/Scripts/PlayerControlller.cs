using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControlller : MonoBehaviour
{
    private Rigidbody2D rbody2D;
    private SpriteRenderer spriteRenderer;

    public float Speed;

    private float axisH;

    private float minX = -1.75f;
    private float maxX = 1.75f;

    private void Awake()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        axisH = Input.GetAxisRaw("Horizontal");

        if(axisH == 1)
        {
            spriteRenderer.flipX = true;
        }
        else if(axisH == -1)
        {
            spriteRenderer.flipX = false;
        }
        transform.position += Vector3.right * axisH * Time.deltaTime * Speed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, 0);
    }
}
