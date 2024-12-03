using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform Player;
    private Camera myCam;

    private Vector3 PlayerPos;

    private void Awake()
    {
        myCam = GetComponent<Camera>();
    }
    private void Update()
    {
        myCam.orthographicSize = (Screen.height / 100) / 3;
        PlayerPos = new Vector3(Player.position.x, Player.position.y + 2.2f, -10);

        //PlayerPos.x = Mathf.Clamp(0, -1.75f, 1.75f);

        transform.position = Vector3.Lerp(transform.position, PlayerPos, 0.2f);
    }
}
