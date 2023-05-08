using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaristaLogic : MonoBehaviour
{
    Vector3 movementInput;
    bool isCoffeeReady = false;
    [SerializeField] private CoffeeMachineLogic coffeeMachine;
    [SerializeField] private GameObject coffee;

    void Start()
    {        

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
             RaycastHit hit;
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray, out hit))
             {
                 movementInput = hit.point;
                 movementInput.y = 0; //stay in the ground
                 movementInput.z = 0;
                 transform.position = movementInput;

                print(hit.collider.gameObject.tag);
                print("isCoffeeReady " + isCoffeeReady);

                if(hit.collider.gameObject.tag == "CoffeeMachine" && !isCoffeeReady)
                {
                    Prepare_coffee();
                }
                else if(hit.collider.gameObject.tag == "Customer" && isCoffeeReady)
                {
                    CustomerLogic customerLogic = hit.collider.gameObject.GetComponent<CustomerLogic>();
                    Give_coffee(customerLogic);
                }
             }
         }
    }

    void Prepare_coffee()
    {
        isCoffeeReady = coffeeMachine.getCoffee();

        if(isCoffeeReady)
        {
            coffee.SetActive(true);
        }
    }

    void Give_coffee(CustomerLogic customerLogic)
    {
        customerLogic.takeCoffee = true;
        isCoffeeReady = false;
        coffee.SetActive(false);

        print("Barista Give coffee");
    }

    void RotateCharacterToMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = mousePos - playerPos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
    }


    private void FixedUpdate()
    {

        RotateCharacterToMouse();
    }
}
