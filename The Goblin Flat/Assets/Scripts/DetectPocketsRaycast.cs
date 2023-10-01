using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPocketsRaycast : MonoBehaviour
{
    public Transform raycastStart;
    public Vector2 facing = Vector2.left;
    public float reachDistance = 5;

    public ContactFilter2D normalFilter;
    public ContactFilter2D pocketPickingFilter;

    public RaycastHit2D pockets;

    public GameObject currentPocket = null;
    public bool pickingPockets = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!pickingPockets)
        {
            pockets = Physics2D.Raycast(raycastStart.position, facing, reachDistance, normalFilter.layerMask);
            if (pockets)
            {
                if (currentPocket != pockets.collider.gameObject)
                {
                    if (currentPocket)
                    {
                        currentPocket.GetComponent<ChangeImage>().ChangeRender(0);
                        
                    }
                    currentPocket = pockets.collider.gameObject;
                    currentPocket.GetComponent<ChangeImage>().ChangeRender(1);
                }
            }
            else
            {
                if (currentPocket)
                {
                    currentPocket.GetComponent<ChangeImage>().ChangeRender(0);
                }
                currentPocket = null;
            }
            
            
            Debug.DrawRay(raycastStart.position, facing * reachDistance, Color.green);
        }
        else
        {
            pockets = Physics2D.Raycast(raycastStart.position, facing, reachDistance, pocketPickingFilter.layerMask);
            if (!pockets)
            {
                currentPocket.GetComponent<ChangeImage>().ChangeRender(0);
            }
        }
        
        
    }
}
