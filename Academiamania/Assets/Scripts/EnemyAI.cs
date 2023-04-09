using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private bool takip = false; // takip etmesi için gereken bool tipi deðiþken

    public float durmaMesafesi; // durma mesafesi

    public float distance; // tarama uzaklýðý

    private Transform target; // hedef

    public float followspeed; // takip etme hýzý

    private Animator anim; // animasyon sorumlusu

    private bool Attack;

    private SpriteRenderer sprt;

    EnemyCombat enemycombat;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        anim = GetComponent<Animator>();
        
        Physics2D.queriesStartInColliders = false;

        sprt = GetComponent<SpriteRenderer>();

        enemycombat = GetComponent<EnemyCombat>();
    }

    // Update is called once per frame
    void Update()
    {

        EnemyAIMob();

    }

    

    void EnemyAIMob() 
    {
        RaycastHit2D hitEnemyLeft = Physics2D.Raycast(transform.position, -transform.right, distance);
        RaycastHit2D hitEnemyUp = Physics2D.Raycast(transform.position, transform.up, distance);
        RaycastHit2D hitEnemyDown = Physics2D.Raycast(transform.position, -transform.up, distance);
        RaycastHit2D hitEnemyRight = Physics2D.Raycast(transform.position, transform.right, distance);

        if (hitEnemyLeft.collider != null)
        {
            Debug.DrawLine(transform.position, hitEnemyLeft.point, Color.red);

            sprt.flipX = false;

            anim.SetBool("takip", true);

            EnemyFollow();

            


        }
        else if (hitEnemyUp.collider != null)
        {
            Debug.DrawLine(transform.position, hitEnemyUp.point, Color.red);

            anim.SetBool("takip", true);

            EnemyFollow();
        }

        else if (hitEnemyDown.collider != null)
        {
            Debug.DrawLine(transform.position, hitEnemyDown.point, Color.red);

            anim.SetBool("takip", true);

            EnemyFollow();
        }

        else if (hitEnemyRight.collider != null)
        {
            Debug.DrawLine(transform.position, hitEnemyRight.point, Color.red);

            sprt.flipX = true;

            anim.SetBool("takip", true);

            EnemyFollow();
        }

        else
        {
            Debug.DrawLine(transform.position, transform.position - transform.right * distance, Color.green);
            Debug.DrawLine(transform.position, transform.position + transform.up * distance, Color.green);
            Debug.DrawLine(transform.position, transform.position - transform.up * distance, Color.green);
            anim.SetBool("Attack", false);
            anim.SetBool("takip", false);

        }

        
    }

    void EnemyFollow()
    {

        if (Vector2.Distance(transform.position, target.position) > durmaMesafesi)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, followspeed * Time.deltaTime);

            followspeed = 2.0f;

            takip = true;
            anim.SetBool("takip", takip);
            
            Attack = false;

            anim.SetBool("Attack", Attack);

            enemycombat.DamagePlayer();

        }

        else 

        {
            followspeed = 0;
            Attack = true;
            takip = false;
            anim.SetBool("takip", takip);
            anim.SetBool("Attack", Attack);
            
        }



    }
}
