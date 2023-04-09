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
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // fare pozisyonunu 3D d�nyaya �evirir
            mousePos.z = transform.position.z; // z ekseni ayn� kals�n diye de�i�tirmeden �nce GameObject'in mevcut z pozisyonunu saklay�n
            transform.position = mousePos; // GameObject'in pozisyonunu fare pozisyonuna e�itleyin

            anim.SetTrigger("isDash");

        }
    }
}
