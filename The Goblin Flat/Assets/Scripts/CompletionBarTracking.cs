using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompletionBarTracking : MonoBehaviour
{
    public float percentageIncrease = 0.1f;
    public float percentageDecrease = 0.01f;
    public float barValue;

    public float barResetValue = 0.5f;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        ResetBar();
    }

    // Update is called once per frame
    void Update()
    {
        barValue -= percentageDecrease * Time.deltaTime;
        //Remove this if
        if(barValue < 0)
        {
            barValue = 0;
        }
        slider.value = barValue;
    }

    public void ResetBar()
    {
        barValue = barResetValue;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Money")
        {
            barValue += percentageIncrease * Time.deltaTime;
        }
    }
}
