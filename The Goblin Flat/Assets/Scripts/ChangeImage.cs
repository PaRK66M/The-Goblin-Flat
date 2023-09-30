using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeImage : MonoBehaviour
{
    public GameObject[] images;
    private GameObject currentImage;

    private void Start()
    {
        currentImage = images[0];
        currentImage.SetActive(true);
    }

    public void ChangeRender(int i)
    {
        currentImage.SetActive(false);
        currentImage = images[i];
        currentImage.SetActive(true);
    }
}
