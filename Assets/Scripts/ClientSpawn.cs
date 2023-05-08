using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawn : MonoBehaviour
{
    [SerializeField] GameObject customer;

    float timer=0.0f;
    float TIMER_EXPIRED = 2.0f;

    [SerializeField] GameManager gameManager;

    void Start()
    {

    }

    private void Update() 
    {
        if(GameObject.FindGameObjectsWithTag("Customer").Length > 0)
            return;

        if(gameManager.gameOver)
            return;

        timer+=Time.deltaTime;
        if(timer > TIMER_EXPIRED)
        {
            InstantiateCustomer();

            timer = 0.0f;
            if(TIMER_EXPIRED > 0)
                TIMER_EXPIRED-=0.5f;
        }
    }

    public void InstantiateCustomer()
    {
        
        GameObject newCustomer = Instantiate(customer);
        newCustomer.GetComponent<CustomerLogic>().SetGameManager(gameManager);
        int randomFace = Random.Range(0,newCustomer.transform.childCount-1);
        newCustomer.transform.GetChild(randomFace).gameObject.SetActive(true);
        newCustomer.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        print("inst" + newCustomer.GetInstanceID() + " randomFace " + randomFace);
    }
}
