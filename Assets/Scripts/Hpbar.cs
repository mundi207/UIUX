using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class Hpbar : MonoBehaviour
{
    private GameObject HpbarPrefab;
    private Slider hpbar;
    [SerializeField]
    private Canvas canvas;

    private RectTransform hpbarPos;

    public GameObject P1, P2;

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
        P1.SetActive(false);
        P2.SetActive(false);

        if(Time.timeScale == 0)
            Time.timeScale = 1;

        Instance.MaxHp = 100;
        Instance.CurHp = 100;
        hpbar.value = Instance.CurHp / Instance.MaxHp;
    }
    private void Update()
    {
        if(hpbar.value == 0)
        {
            //Instance.P1.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void FixedUpdate()
    {
        hpbarPos.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 1, -10));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Instance.CurHp -= 50;
            hpbar.value = Mathf.Lerp(hpbar.value,(float)Instance.CurHp / (float)Instance.MaxHp,Time.deltaTime * 10);
        }
        if(hpbar.value == 0)
        {
            P1.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Item"))
        {
            Instance.CurHp += 25;
            hpbar.value = Mathf.Lerp(hpbar.value,(float)Instance.CurHp / (float)Instance.MaxHp,Time.deltaTime * 10);
        }
        if(hpbar.value == 0)
        {
            P1.SetActive(true);
            Time.timeScale = 0;
        }
        else if(collision.gameObject.CompareTag("D2"))
        {
            P2.SetActive(true);
        }
    }
}
