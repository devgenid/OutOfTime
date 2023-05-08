using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLogic : MonoBehaviour
{
    private Vector3 StartPos;
    private Vector3 WaitingPos;
    private Vector3 FinalPos;
    private bool isWaiting = true;
    private bool haveCoffee = false;
    private bool isGone = false;
    public bool takeCoffee=false;
    int patience=100;

    [SerializeField] private PatienceLogic patienceLogic;

    float timer = 0.0f;
    float TIMER_EXPIRED = 0.1f;
    int LOSE_PATIENCE = 2;

     private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        WaitingPos = GameObject.FindGameObjectWithTag("WaitingPoint").transform.position;
        FinalPos = StartPos;

        print("customer" + gameObject.GetInstanceID());

        patienceLogic.SetMaxHealth(patience);
        patienceLogic.SetPatience(patience);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameOver)
            return;

        if(isWaiting && !haveCoffee && !isGone && transform.position != WaitingPos)
        {
            transform.position = WaitingPos;
        }
        else if( transform.position == WaitingPos && isWaiting && !haveCoffee)
        {
            isWaiting = false;

        }
        else if(!isWaiting && !haveCoffee)
        {
            haveCoffee = takeCoffee;
        }
        else if(haveCoffee && !isGone)
        {
            transform.position = FinalPos;
            isGone=true;
            gameManager.AddCustomer();
       
        }
        
        if(isGone && transform.position == FinalPos)
        {
            Destroy(gameObject);

        }
        else
        {
            timer +=Time.deltaTime;
            if(timer>=TIMER_EXPIRED)
            {    
                patience-=(LOSE_PATIENCE*Random.Range(1,3));
                timer = 0.0f;
            }
            
            patienceLogic.SetPatience(patience);

            if(patience <= 0)
            {
                transform.position = FinalPos;
                isGone=true;
                gameManager.SetGameOver(true);

            }

        }
    }


    public void SetGameManager(GameManager gameManagerLogic)
    {
        gameManager=gameManagerLogic;
    }
    
}
