using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour {

	static Rigidbody rb;
	public static Vector3 diceVelocity;
    static Vector3 rt;
    public static bool clickDice = false;
    public GameObject cubeDice, plane;

    // Use this for initialization
    void Start () {
		rb = this.GetComponent<Rigidbody>();  
	}
	
	// Update is called once per frame
	void Update () {
		diceVelocity = rb.velocity;
	}
    public void BtnDice()
    {
        cubeDice.SetActive(true);
        plane.SetActive(false);
        clickDice = true;
        //DiceNumberTextScript.diceNumber = 0;
        float dirX = Random.Range(0, 500);
        float dirY = Random.Range(0, 500);
        float dirZ = Random.Range(0, 500);
        transform.position = new Vector3(0, Random.Range(6, 9), 0);
        transform.rotation = Quaternion.Euler(Random.Range(0, 45), Random.Range(0, 45), Random.Range(0, 45));
        //transform.rotation = Quaternion.identity;
        rb.AddForce(transform.up * Random.Range(300, 500));
        rb.AddTorque(dirX, dirY, dirZ);
    }
}
