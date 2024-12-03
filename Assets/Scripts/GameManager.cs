using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int WhenHigh;
    public static GameManager Instance {get; private set;}
    public GameObject[] Stairs;
    private float valueY;

    public Transform D2;

    public int MaxHp, CurHp;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Spawner();
        Init();
        InitStairs();
    }
    private void Spawner()
    {
        Stairs = new GameObject[WhenHigh];
        for(int i = 0; i < Stairs.Length; i++)
        {
            Stairs[i] = Instantiate(Resources.Load("Prefab/Stair") as GameObject);
        }
    }
    private void Init()
    {
        valueY = -3.5f;
    }
    private void InitStairs()
    {
        for(int i = 0; i < Stairs.Length; i++)
        {
            if(i == 0)
                Stairs[i].transform.position = new Vector3(0, -3.5f, 0);
            else
            {
                float ran = Random.Range(-1.75f,1.75f);

                valueY += 0.5f;

                if(ran > 0)
                    ran -= Stairs[i].transform.position.x;
                else
                    ran += Stairs[i].transform.position.x;
                Stairs[i].transform.position = new Vector3(ran, 0, 0);
            }
            Stairs[i].transform.position += new Vector3(0,valueY,0);

            if(i != 0)
            {
                float itemran = Random.Range(1, 10);
                if(itemran < 2)
                {
                    Instantiate(Resources.Load("Prefab/Item") as GameObject, Stairs[i].transform.position, Stairs[i].transform.rotation);
                }
            }
            if(i == Stairs.Length - 1)
            {
                D2.position = Stairs[i].transform.position;
            }
        }
    }
}
