using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIV2 : MonoBehaviour
{    
    public float distance; // tarama uzaklýðý
    public float durmaMesafesi; // durma mesafesi

    public float followspeed; // takip etme hýzý
    private bool Attack; // takip etmesi için gereken bool tipi deðiþken
    private bool takip = false;

    private Transform target; // hedef
    private Animator anim; // animasyon sorumlusu
    private SpriteRenderer sprt; //sprite renderer için deðiþken atadým.

    EnemyV2 healthV2;

    EnemyCombatV2 ecV2;

    


    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //player taglý gameobjecti bul fonksiyonu.

        anim = GetComponent<Animator>();   // animator caching
        sprt = GetComponent<SpriteRenderer>(); // Spriterenderer caching

        Physics2D.queriesStartInColliders = false; // çizgi çizdirmek için gereken fonksiyon (?)
        healthV2 = GetComponent<EnemyV2>();
        ecV2 = GetComponent<EnemyCombatV2>();
    }

    
    void Update()
    {
        EnemyAIMob(); //AI mobu her karede çarýyorum
    }

    void EnemyAIMob()
    { 
        RaycastHit2D hitEnemyLeft = Physics2D.Raycast(transform.position, -transform.right, distance);  // sola doðru çizgi 3 deðiþken alýyor kimden çýkacaðý, yönü ve uzunluðu. 
        RaycastHit2D hitEnemyUp = Physics2D.Raycast(transform.position, transform.up, distance);        // yukarý doðru çizgi 3 deðiþken alýyor kimden çýkacaðý, yönü ve uzunluðu. 
        RaycastHit2D hitEnemyDown = Physics2D.Raycast(transform.position, -transform.up, distance);     // aþaðý doðru çizgi 3 deðiþken alýyor kimden çýkacaðý, yönü ve uzunluðu. 
        RaycastHit2D hitEnemyRight = Physics2D.Raycast(transform.position, transform.right, distance);  // saða doðru çizgi 3 deðiþken alýyor kimden çýkacaðý, yönü ve uzunluðu. 


        // if else bloðu þu iþe yarýyor = Eðer çizgilerden birisi kýrmýzý olursa o yöne dðoru git ve takip etme fonksiyonunu çaðýr.

        if (hitEnemyLeft.collider != null)    
        {
            Debug.DrawLine(transform.position, hitEnemyLeft.point, Color.red);

            sprt.flipX = true;

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

            sprt.flipX = false;

            anim.SetBool("takip", true);

            EnemyFollow();
        }

        else
        {
            Debug.DrawLine(transform.position, transform.position - transform.right * distance, Color.green);
            Debug.DrawLine(transform.position, transform.position + transform.up * distance, Color.green);
            Debug.DrawLine(transform.position, transform.position - transform.up * distance, Color.green);
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            anim.SetBool("Attack", false);
            anim.SetBool("takip", false);

        }


    }

    void EnemyFollow()
    {

        if (Vector2.Distance(transform.position, target.position) >= durmaMesafesi && healthV2.currentHealth>0)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, followspeed * Time.deltaTime);

            followspeed = 2.0f;

            takip = true;
            anim.SetBool("takip", takip);

            Attack = false;
            anim.SetBool("Attack", Attack);

            ecV2.DamagePlayer();
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
