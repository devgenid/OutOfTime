using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatienceLogic : MonoBehaviour
{

    [SerializeField] private Slider patienceSlider;
    public void SetPatience(int patience) 
    { 
        patienceSlider.value = patience; 

    }

    public void SetMaxHealth(int max) 
    { 
        patienceSlider.maxValue = max;
    }
}
