using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Slider patienceSlider;

    private Transform cam;

    private void Start() {
        cam = Camera.main.transform;
    }
    void LateUpdate()
    {
        if (patienceSlider.value<=40)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if(patienceSlider.value <= 80)
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
         

        transform.LookAt(transform.position + cam.forward);
    }
}
