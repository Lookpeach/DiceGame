using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceNumberTextScript : MonoBehaviour {

	Text text;
	public static int diceNumber;
    public int n;

    private int whosTurn = 1;
    private bool coroutineAllowed = true;

    // Use this for initialization
    void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = diceNumber.ToString ();
        n = diceNumber;
        if (DiceScript.clickDice == true)
        {
            if (!GameControl.gameOver && coroutineAllowed && DiceScript.clickDice == true)
            {
                //StartCoroutine("RollTheDice");
                GameControl.diceSideThrown = diceNumber;
                GameControl.MovePlayer(1);

                whosTurn *= 1;
                coroutineAllowed = true;
            }
            DiceScript.clickDice = false;    
        }
        //GameControl.diceSideThrown = diceNumber;
        //Debug.Log("diceNumber" + diceNumber);
        
    }
    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        yield return new WaitForSeconds(0.05f);

        GameControl.diceSideThrown = diceNumber;
        GameControl.MovePlayer(1);

        whosTurn *= 1;
        coroutineAllowed = true;
    }
}
