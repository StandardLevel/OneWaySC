using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GHOST_3 : MonoBehaviour
{
    public float SPEED = 15f;
    Player player;
    Animation Ani;
    GameObject Ghost;
    Animator animator;
   
    GameManager GM;


   

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        GM.GhostType = 3;
        Ghost = GameObject.Find("Ghost3(Clone)");
        player = GameObject.Find("Player").GetComponent<Player>();
        Ani = player.GetComponent<Animation>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player.transform.position.z - 2.5f < transform.position.z && player.Die == false && player.On ==true && transform.position.z<50f)
        {
            player.Die = true;
            Ani.Play("Die");
        }

        transform.Translate(0, 0, SPEED * Time.deltaTime);
        if (transform.position.z < 40)
        {        
            Vector3 vec = new Vector3(player.transform.position.x - this.transform.position.x, 0, player.transform.position.z - this.transform.position.z);

            transform.rotation = Quaternion.LookRotation(vec, new Vector3(0, 0, 0));
        }
        else
        {
            
            transform.rotation = Quaternion.LookRotation(new Vector3(0,0,1), new Vector3(0,0,0));
        }

        if (player.Die == true)
        {
            SPEED = 0;
            float stop = player.transform.position.z - 2.5f;
            animator.SetBool("isAttack", true);
            transform.position = new Vector3(0, 0.1f, stop);
        }

        if(transform.position.z > 80f)
        {
            Destroy(Ghost);
        }

     

        if (GM.Clear == true)
            Destroy(Ghost);
    }
}
