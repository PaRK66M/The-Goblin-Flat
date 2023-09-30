using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPocketsRaycast : MonoBehaviour
{
    public Transform raycastStart;
    public Vector2 facing = Vector2.left;
    public float reachDistance = 5;

    public ContactFilter2D filter;

    public RaycastHit2D pockets;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pockets = Physics2D.Raycast(raycastStart.position, facing, reachDistance, filter.layerMask);
        Debug.DrawRay(raycastStart.position, facing * reachDistance, Color.green);
        
    }
}
