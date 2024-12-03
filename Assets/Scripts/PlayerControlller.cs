using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static GameManager;

public class PlayerControlller : MonoBehaviour
{
    private Rigidbody2D rbody2D;
    private SpriteRenderer Sprite;
    [SerializeField]
    private Transform DetectedObj;

    public float Speed;

    private float axisH;

    [SerializeField]
    private bool JumpFlag, DownFlag, isGround;
    public float Jumppow;

    private void Awake()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        axisH = Input.GetAxisRaw("Horizontal");
        isGround = Physics2D.OverlapCircle(DetectedObj.position,0.05f,LayerMask.GetMask("Ground"));

        if(axisH == 1)
        {
            Sprite.flipX = true;
        }
        else if(axisH == -1)
        {
            Sprite.flipX = false;
        }
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            JumpFlag = true;
        }
        else if(Input.GetKey(KeyCode.DownArrow) && !isGround)
        {
            DownFlag = true;
        }
        transform.position += Vector3.right * axisH * Time.deltaTime * Speed;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
    private void FixedUpdate()
    {
        if(JumpFlag)
        {
            JumpFlag = false;
            rbody2D.AddForce(new Vector2(0,Jumppow));
        }
        else if(DownFlag)
        {
            DownFlag = false;
            rbody2D.AddForce(new Vector2(0,-5f));
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Item"))
        {
            rbody2D.AddForce(new Vector2(0, 500));
        }
    }
}
