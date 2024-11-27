using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    private GameObject HpbarPrefab;
    private Slider hpbar;
    [SerializeField]
    private Canvas canvas;

    private RectTransform hpbarPos;

    private int MaxHp, CurHp;

    private void Awake()
    {
        HpbarPrefab = Resources.Load("Prefab/Hpbar") as GameObject;
        GameObject temp = Instantiate(HpbarPrefab);
        hpbar = temp.GetComponent<Slider>();

        hpbar.transform.SetParent(canvas.transform);
        hpbarPos = temp.GetComponent<RectTransform>();
    }
    private void Start()
    {
        MaxHp = 100;
        CurHp = 100;
        hpbar.value = CurHp / MaxHp;
    }
    private void FixedUpdate()
    {
        hpbarPos.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 1, -10));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            CurHp -= 10;
            hpbar.value = Mathf.Lerp(hpbar.value, (float)CurHp / (float)MaxHp, Time.deltaTime * 10);
        }
    }
}
