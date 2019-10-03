using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public DiceNumberTextScript dn;
    public DiceScript ds;
    int[,] array = new int[,]
        {
            {0,157}, //1 + rot
            {79,115}, //2
            {163,59}, //3
            {271,0}, //4
            {372,-60}, //5 + rot
            {284,-112}, //6
            {189,-167}, //7
            {92,-218}, //8
            {0,-269}, //9 + rot
            {-86,-219}, //10
            {-183,-163}, //11
            {-286,-105}, //12
            {-370,-56}, //13 + rot
            {-275,0}, //14
            {-172,57}, //15
            {-82,110}, //16
        };
    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1f;

    [HideInInspector]
    public int waypointIndex = 0;

    public bool moveAllowed = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAllowed)
        {
            Move();
        }
        ////transform.position = Vector3.Lerp(array[1], array[2]);
        ////transform.localPosition = new Vector2(79, 115);
        //int n = dn.n;
        //Debug.Log(n);
        //if(n != 0 && n<=16)
        //{
        //    for (int i = 1; i <= n; i++)
        //    {
        //        transform.localPosition = new Vector2(array[i, 0], array[i, 1]);
        //    }  
        //}   
    }
    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.localPosition = Vector2.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);
            if(transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }
}
