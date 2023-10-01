using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyValues : MonoBehaviour
{
    public int gold = 50;

    public void Steal()
    {
        gameObject.layer = 0;
    }
}
