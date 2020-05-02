using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceTimer : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] int resourceAddAmount;
    [SerializeField] Text resourceTxt;
    [SerializeField] Event eventTimerUp;
    private Slider slider;
    private float filled = 0f;
    private int resource = 0;

    private void Start() 
    {
        slider = GetComponent<Slider>();
        resourceTxt.text = resource.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }


    private void UpdateTimer()
    {
        filled = Time.deltaTime;
        slider.value +=  filled / duration;

        if(slider.value >= 1f)
        {
            eventTimerUp.OnOccured();
            slider.value = 0;
        }
    }

    public void AddResource()
    {
        resource += resourceAddAmount;
        resourceTxt.text = resource.ToString();
    }
}
