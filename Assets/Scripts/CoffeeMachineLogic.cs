using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachineLogic : MonoBehaviour
{
    private static bool isCoffeeReady=false;
    private float timer = 0;
    private float waitTime = 2.0f;
    
    private bool coffeeOrder = false;

    private void OnTriggerEnter(Collider other) 
    {
        print("Prepare coffee");

    
        if(other.CompareTag("Player"))
        {
            print("Wait for coffee");

            coffeeOrder = true;
            
        }

        return;

    }

    private void Update() 
    {
        
        if(coffeeOrder)
        {

            if (timer < waitTime)
            {
                timer += Time.deltaTime;

            }
            else
            {
                print("Coffee ready!");
                isCoffeeReady = true;
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                timer=0.0f;
                coffeeOrder = false;
                waitTime = Random.Range(2.0f,2.5f);


            }
        }

    }

    public bool getCoffee()
    {
        print("get a coffee");


        if(isCoffeeReady == true)
        {
            print("Coffee is taken!");

            isCoffeeReady = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);

            return true;
        }

        return false;
    }

}
