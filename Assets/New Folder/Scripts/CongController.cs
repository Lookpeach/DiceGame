using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongController : MonoBehaviour
{
    public GameObject cvIntro, cvGame, cvCong;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HomeBtn()
    {
        cvGame.SetActive(false);
        cvCong.SetActive(false);
        cvIntro.SetActive(true);
    }
}
