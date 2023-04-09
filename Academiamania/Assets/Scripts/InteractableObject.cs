using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : CollidableObject
{
    public Animator chestAnimator; // Reference to the chest's Animator component
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
            // Check if this object is a chest
            if (chestAnimator != null)
            {
                // Enable the chest's Animator component and play the opening animation
                chestAnimator.enabled = true;
                chestAnimator.Play("ChestOpen"); // Replace "ChestOpen" with the name of your chest opening animation
            }
            // If this object is not a chest, perform some other action (e.g. show a message)
            else
            {
                Debug.Log("Interacted with non-chest object");
            }

            // Set the "z_interacted" flag to true so this object can't be interacted with again
            z_interacted = true;
        }
    }
}
