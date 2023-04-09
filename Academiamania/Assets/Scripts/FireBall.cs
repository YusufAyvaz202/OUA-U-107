using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float lifeTime = 1f;

    private void Start()
    {
        Invoke("DestroyFireball", 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            GameObject myObject = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(myObject, lifeTime);
            Destroy(gameObject);
        }

    }

    void DestroyFireball()
    {
        Destroy(gameObject);
    }
}
