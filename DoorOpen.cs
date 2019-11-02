using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    Player player;
    Quaternion Right = Quaternion.identity;
    //필요한 사운드 이름
    float se = 0;
    static public GameObject self;
    GameManager GM;
    bool Once = true;
    Animation anim;
    private AudioSource DoorI;
    public AudioClip[] clip;


    void Start()
    {
        self = GameObject.Find("DoorAxis");
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animation>();
        DoorI = GetComponent<AudioSource>();
    }

    void Open()
    {
        Right.eulerAngles = new Vector3(0, -90, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, Right, Time.deltaTime * 1.2f);
    }
    public void DoorIS()
    {
        DoorI.clip = clip[0];
        DoorI.spatialBlend = 1; // 0 = 2D , 1 = 3D
        DoorI.minDistance = 2; // 거리 최솟값
        DoorI.maxDistance = 4; // 거리 최댓값
        DoorI.Play();
    }
    public void DoorOpenSoound()
    {
        DoorI.clip = clip[1];
        DoorI.spatialBlend = 1;
        DoorI.minDistance = 2;
        DoorI.maxDistance = 50;
        DoorI.Play();
    }


    void Update()
    {
        if (GM.Clear == true)
        {
            Invoke("Open", 1.2f);
            if (se == 0)
            {
                DoorOpenSoound();
                se = 1;
            }
        }
        if (GM.Stage == 4 && Once == true)
        {
            Once = false;
            anim.Play("4Stage_Door");
        }
    }
}