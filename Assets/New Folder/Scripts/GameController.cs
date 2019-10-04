using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject canvasInfo, canvasGame;
    //.............................
    public GameObject dice;
    public Text textShowDice;
    public int n;
    //.............................
    public GameObject player;
    public Sprite[] carRot;
    public GameObject[] waypoints;
    public int waypointIndex = 0;
    [SerializeField]
    private float moveSpeed = 1f;
    public bool moveAllowed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        textShowDice.text = DiceNumberTextScript.diceNumber.ToString();
        n = DiceNumberTextScript.diceNumber;
    //    if (moveAllowed == true)
    //    {
    //        Move();
    //    }
           
    }
    //private void Move()
    //{
    //    if (waypointIndex <= waypoints.Length - 1)
    //    {
    //        transform.position = Vector2.MoveTowards(transform.position,
    //        waypoints[waypointIndex].transform.position,
    //        moveSpeed * Time.deltaTime);

    //        if (transform.position == waypoints[waypointIndex].transform.position)
    //        {
    //            waypointIndex += 1;
    //        }
    //    }
    //}
    public void MovePlayer()
    {

    }

    public void PlayGameButton()
    {
        canvasInfo.SetActive(false);
        canvasGame.SetActive(true);
    }
    public void DiceButton()
    {
        //DiceNumberTextScript.diceNumber = 0;
        float dirX = Random.Range(0, 500);
        float dirY = Random.Range(0, 500);
        float dirZ = Random.Range(0, 500);
        transform.position = new Vector3(0, Random.Range(6, 9), 0);
        transform.rotation = Quaternion.Euler(Random.Range(0, 45), Random.Range(0, 45), Random.Range(0, 45));
        //transform.rotation = Quaternion.identity;
        dice.GetComponent<Rigidbody>().AddForce(transform.up * Random.Range(3000, 3500));
        dice.GetComponent<Rigidbody>().AddTorque(dirX, dirY, dirZ);
        //rb.AddForce(transform.up * Random.Range(300, 500));
        //rb.AddTorque(dirX, dirY, dirZ);
        //moveAllowed = true;
    }
}
