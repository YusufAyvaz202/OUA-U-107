using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D r2d;
    private Vector2 moveInput;
    private SpriteRenderer sprt;
    private Animator anim;
    public int kombo;
    public bool saldiri;
    GameObject child;

    PlayerCombat playercombat;

    void Start()
    {
        sprt = GetComponent<SpriteRenderer>();
        r2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playercombat = GetComponent<PlayerCombat>();
        GameObject originalGameObject = GameObject.Find("karakter");
        child = originalGameObject.transform.GetChild(0).gameObject;
        
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        r2d.velocity = moveInput * moveSpeed;

        karakterAnimasyon();

        karakterDonus();

        karakterSaldiri();

        agirSaldiri();

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
            child.BroadcastMessage("IsFacingRight", true);
        }

        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            sprt.flipX = true;
            child.BroadcastMessage("IsFacingRight", false);


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
            playercombat.DamageEnemy();

        }

    }

    void agirSaldiri()

    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            anim.SetTrigger("agirSaldiri");
            playercombat.DamageEnemy();
        }
    }


}
