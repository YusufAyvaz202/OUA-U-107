using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterDash : MonoBehaviour
{
    public bool isDash;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update() 
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // fare pozisyonunu 3D dünyaya çevirir
            mousePos.z = transform.position.z; // z ekseni ayný kalsýn diye deðiþtirmeden önce GameObject'in mevcut z pozisyonunu saklayýn
            transform.position = mousePos; // GameObject'in pozisyonunu fare pozisyonuna eþitleyin

            anim.SetTrigger("isDash");

        }
    }
}
