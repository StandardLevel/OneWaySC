﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class GhostSpawn : MonoBehaviour
{
    Player player;
    public GameObject[] Ghost = new GameObject[3];
    GameObject Ghostinstance;
    GameManager GM;
   
   
    float SpawnTime = 20f;
    int random = 0;

    void SpawnCountDown()
    {
        if (GM.Ghoston == false && player.backon == 0 && !(player.expand == 5))
        {
            SpawnTime -= Time.deltaTime;
        }
    }

    void Stage1()
    {
        if (SpawnTime < 0)
        {
            Ghostinstance = Instantiate(Ghost[2], transform.position, Quaternion.identity) as GameObject;
            GM.Ghoston = true;
            SpawnTime = Random.Range(15f, 25f);
        }
        transform.Translate(0, 0, 0.1f * Time.deltaTime);
    }

    void Stage2()
    {
        if (SpawnTime < 0)
        {
            Ghostinstance = Instantiate(Ghost[0], transform.position, Quaternion.identity) as GameObject;
            GM.Ghoston = true;
            SpawnTime = Random.Range(12f, 20f);
        }
        transform.Translate(0, 0, 0.1f * Time.deltaTime);
    }

    void Stage3()
    {
        if (SpawnTime < 0)
        {
            random = Random.Range(0, 2);
            Ghostinstance = Instantiate(Ghost[random], transform.position, Quaternion.identity) as GameObject;
            GM.Ghoston = true;
            SpawnTime = Random.Range(12f, 20f);
            
        }
        transform.Translate(0, 0, 0.1f * Time.deltaTime);
    }

    void Stage4()
    {


        if (SpawnTime < 0)
        {
            if (GameObject.Find("FoxyCrushJM").GetComponent<FoxyCrushJMar>().Crush == true)//doorghost가 문앞에 있으면
            {
                Debug.Log("확");
                do
                {
                    random = Random.Range(0, 3);
                } while (random == 2);
                                                
            }
            else
            {
                random = Random.Range(0, 3);
            }
            Ghostinstance = Instantiate(Ghost[random], transform.position, Quaternion.identity) as GameObject;
            GM.Ghoston = true;
            SpawnTime = Random.Range(12f, 20f);
        }
        transform.Translate(0, 0, 0.1f * Time.deltaTime);
    }

   /* private int GiveMeANumber()
    {
        var exclude = new HashSet<int>() { 5, 7, 17, 23 };
        var range = Enumerable.Range(1, 100).Where(i => !exclude.Contains(i));

        var rand = new System.Random();
        int index = rand.Next(0, 100 - exclude.Count);
        return range.ElementAt(index);
    }*/

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Player>();
        
    }

    void Update()
    {
        SpawnCountDown();
        switch (GM.Stage)
        {
            case 1:
                Stage1();
                break;
            case 2:
                Stage2();
                break;
            case 3:
                Stage3();
                break;
            case 4:
                Stage4();
                break;
        }
        
    }    
}
