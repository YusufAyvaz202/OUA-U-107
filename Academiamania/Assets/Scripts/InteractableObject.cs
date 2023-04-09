using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : CollidableObject
{
    private bool z_interacted = false;
    protected override void OnCollided(GameObject collidedObject)
    {
        base.OnCollided(collidedObject);

        if (Input.GetKey(KeyCode.F))
        {
            OnInteract();
        }
    }

    protected virtual void OnInteract()
    {
        if (!z_interacted)
        {
            z_interacted = true;
            Debug.Log("INTERACT WITH " + name);
        }

    }
}
