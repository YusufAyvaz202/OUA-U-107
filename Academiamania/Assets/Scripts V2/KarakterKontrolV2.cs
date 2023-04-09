using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontrolV2 : MonoBehaviour
{
    public float moveSpeed; 
    public int kombo;
    public bool saldiri;

    private Vector2 moveInput;
 
    public Rigidbody2D r2d;
    private SpriteRenderer sprt;
    private Animator anim;

    KarakterSaldiriV2 karakterSaldiriV2;
    public bool characterAttack;
    public float CharacterTimer;

    void Start()
    {
        // caching yapt���m komponentler
        sprt = GetComponent<SpriteRenderer>();
        r2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //caching yapt���m classlar
        karakterSaldiriV2 = GetComponent<KarakterSaldiriV2>();

        // fonksiyon kullan�m� i�in caching
        GameObject originalGameObject = GameObject.Find("karakter"); // d��manlar�n karakteri bulmas� i�in

        CharacterTimer = 0.7f;       
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize(); //? bu ne demek

        r2d.velocity = moveInput * moveSpeed;

        karakterAnimasyon();

        karakterDonus();

        karakterSaldiri();

        agirSaldiri();

        CharacterAttackSpacing();

    }

    void karakterAnimasyon()
    {
        if (moveInput.x > 0 || moveInput.x < 0 || moveInput.y > 0 || moveInput.y < 0)
        {
            anim.SetBool("kosuyorMu", true);
        }
        else
        {
            anim.SetBool("kosuyorMu", false);
        }
    }

    void karakterDonus()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            sprt.flipX = false;           
        }

        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            sprt.flipX = true;           
        }
    }

    public void komboSaldiri()
    {
        saldiri = false;

        if (kombo < 2)
        {
            kombo++;
        }
    }

    public void bitirmeAnim()
    {
        saldiri = false;
        kombo = 0;
    }

    public void karakterSaldiri()
    {
        if (Input.GetKeyDown(KeyCode.E) && !saldiri)
        {
            saldiri = true;
            anim.SetTrigger("" + kombo);

            karakterSaldiriV2.DamageEnemy();
        }
    }

    void agirSaldiri()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            if (characterAttack)
            {
                anim.SetTrigger("agirSaldiri");
                karakterSaldiriV2.DamageEnemy();
                characterAttack = false;
            }           
        }       
    }

    void CharacterAttackSpacing()
    {
        if (characterAttack == false) 
        {
            CharacterTimer -= Time.deltaTime;
        }
        if (CharacterTimer < 0)
        {
            CharacterTimer =  0;
        }
        if (CharacterTimer == 0) 
        {
            characterAttack = true;
            CharacterTimer = 1.5f;
        }
    }
}
