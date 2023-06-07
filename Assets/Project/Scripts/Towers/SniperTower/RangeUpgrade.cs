using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class RangeUpgrade : MonoBehaviour
{
    public float Range;
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,Range);
    }
}
