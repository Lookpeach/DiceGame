using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour {

	static Rigidbody rb;
	public static Vector3 diceVelocity;
    static Vector3 rt;
    public static bool clickDice = false;
    bool moveOn = false;
    public GameObject cubeDice, plane;
    public bool coroutineAllowed = true;
    private float last = 1.0f;
    private int last_dice_number = 0;
    private int sum_dice = 0;
    public GameObject[] info;

    public GameObject player;
    public GameObject[] turnPoint;
    public Sprite[] car;

    // Use this for initialization
    void Start () {
		rb = this.GetComponent<Rigidbody>();  
	}
	
	// Update is called once per frame
	void Update () {
		diceVelocity = rb.velocity;
        if(player.transform.position == turnPoint[0].transform.position)
        {
            player.GetComponent<SpriteRenderer>().sprite = car[0];
        }
        else if (player.transform.position == turnPoint[1].transform.position)
        {
            player.GetComponent<SpriteRenderer>().sprite = car[1];
        }
        else if (player.transform.position == turnPoint[2].transform.position)
        {
            player.GetComponent<SpriteRenderer>().sprite = car[2];
        }
        else if (player.transform.position == turnPoint[3].transform.position)
        {
            player.GetComponent<SpriteRenderer>().sprite = car[3];
        }
        if (moveOn == true)
        {
            last -= Time.deltaTime;
            if (last <= 0)
            {
                if (last_dice_number != DiceNumberTextScript.diceNumber)
                {
                    //Debug.Log("Yielded");

                    GameControl.diceSideThrown = DiceNumberTextScript.diceNumber;


                    //Debug.Log("Moving");
                    GameControl.MovePlayer(1);
                    coroutineAllowed = true;

                    //Debug.Log("Finish");
                    moveOn = false;
                    last = 1.0f;
                    last_dice_number = DiceNumberTextScript.diceNumber;

                    sum_dice += DiceNumberTextScript.diceNumber;
                    if (sum_dice == 1)
                    {
                        info[0].SetActive(true);
                        //for (int i=0; i<=8; i++)
                        //{
                        //    if (i != 0)
                        //        info[i].SetActive(false);
                        //}
                            
                    }
                    else if(sum_dice == 3)
                    {
                        info[1].SetActive(true);
                        //for (int i = 0; i <= 8; i++)
                        //{
                        //    if (i != 1)
                        //        info[i].SetActive(false);
                        //}
                    }
                    else if (sum_dice == 4)
                    {
                        info[2].SetActive(true);
                        //for (int i = 0; i <= 8; i++)
                        //{
                        //    if (i != 2)
                        //        info[i].SetActive(false);
                        //}
                    }
                    else if (sum_dice == 6)
                    {
                        info[3].SetActive(true);
                        //for (int i = 0; i <= 8; i++)
                        //{
                        //    if (i != 3)
                        //        info[i].SetActive(false);
                        //}
                    }
                    else if (sum_dice == 8)
                    {
                        info[4].SetActive(true);
                        //for (int i = 0; i <= 8; i++)
                        //{
                        //    if (i != 4)
                        //        info[i].SetActive(false);
                        //}
                    }
                    else if (sum_dice == 10)
                    {
                        info[5].SetActive(true);
                        //for (int i = 0; i <= 8; i++)
                        //{
                        //    if (i != 5)
                        //        info[i].SetActive(false);
                        //}
                    }
                    else if (sum_dice == 12)
                    {
                        info[6].SetActive(true);
                        //for (int i = 0; i <= 8; i++)
                        //{
                        //    if (i != 6)
                        //        info[i].SetActive(false);
                        //}
                    }
                    else if (sum_dice == 13)
                    {
                        info[7].SetActive(true);
                        //for (int i = 0; i <= 8; i++)
                        //{
                        //    if (i != 7)
                        //        info[i].SetActive(false);
                        //}
                    }
                    else if (sum_dice >= 15)
                    {
                        info[8].SetActive(true);
                        //for (int i = 0; i <= 8; i++)
                        //{
                        //    if (i != 8)
                        //        info[i].SetActive(false);
                        //}
                    }
                    else
                    {
                        for (int i = 0; i <= 8; i++)
                        {
                             info[i].SetActive(false);
                        }
                    }
                }
            }
        }
	}

    public void ClickDiceButton()
    {
        last = 1.0f;
        moveOn = true;
        //Debug.Log("Clicked 1");
        cubeDice.SetActive(true);
        plane.SetActive(false);
        for (int i = 0; i <= 8; i++)
        {
            info[i].SetActive(false);
        }
        if (/*!GameControl.gameOver && */coroutineAllowed)
            //StartCoroutine("RollTheDice");
            print("In If Condition");
        RollTheDice();
        //DiceNumberTextScript.diceNumber = 2;
        //GameControl.MovePlayer(1);
    }

    private void RollTheDice()
    {
        coroutineAllowed = false;
        //DiceNumberTextScript.diceNumber = 0;
        float dirX = Random.Range(0, 500);
        float dirY = Random.Range(0, 500);
        float dirZ = Random.Range(0, 500);
        transform.position = new Vector3(0, Random.Range(6, 9), 0);
        transform.rotation = Quaternion.Euler(Random.Range(0, 45), Random.Range(0, 45), Random.Range(0, 45));
        //transform.rotation = Quaternion.identity;
        rb.AddForce(transform.up * Random.Range(700, 900));
        rb.AddTorque(dirX, dirY, dirZ);
        clickDice = false;
        moveOn = true;
        //yield return new WaitForSeconds(0.01f);
        //Debug.Log("Yielding");

        /* 
        if (whosTurn == 1)
        {
            GameControl.MovePlayer(1);
        } else if (whosTurn == -1)
        {
            GameControl.MovePlayer(2);
        }
        whosTurn *= -1;
        */
    }

    //public void BtnDice()
    //{
    //    cubeDice.SetActive(true);
    //    plane.SetActive(false);
    //    clickDice = true;
    //    //DiceNumberTextScript.diceNumber = 0;
    //    float dirX = Random.Range(0, 500);
    //    float dirY = Random.Range(0, 500);
    //    float dirZ = Random.Range(0, 500);
    //    transform.position = new Vector3(0, Random.Range(6, 9), 0);
    //    transform.rotation = Quaternion.Euler(Random.Range(0, 45), Random.Range(0, 45), Random.Range(0, 45));
    //    //transform.rotation = Quaternion.identity;
    //    rb.AddForce(transform.up * Random.Range(300, 500));
    //    rb.AddTorque(dirX, dirY, dirZ);
    //    GameControl.MovePlayer(1);
    //    coroutineAllowed = true;
    //}
}
