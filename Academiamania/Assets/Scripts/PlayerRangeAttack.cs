using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour
{
    public GameObject firePrefab;
    public Transform fireSpawn;
    public float fireSpeed = 10f;



    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        if (Input.GetButtonDown("Fire1"))
        {

            GameObject fire = Instantiate(firePrefab, fireSpawn.position, fireSpawn.rotation);

            Vector2 fireballDir = (mousePos - transform.position).normalized;
            fire.GetComponent<Rigidbody2D>().velocity = fireballDir * fireSpeed;
        }
    }
}
