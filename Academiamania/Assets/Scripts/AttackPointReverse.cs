using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPointReverse : MonoBehaviour
{
    public Vector3 localFaceRight = new Vector3(0.56f, 0.08f, 0);
    public Vector3 localFaceLeft = new Vector3(-0.56f, 0.08f, 0);

    void IsFacingRight(bool isFacingRight)
    {
        if (isFacingRight)
        {
            transform.localPosition = localFaceRight;
        }
        else
        {
            transform.localPosition = localFaceLeft;
        }
    }
}
