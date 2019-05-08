using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManagement : MonoBehaviour
{
    public int childNumber;
    LevelManager Manager;
    UIManager ui;

    private void Awake()
    {
       //  PlayerPrefs.DeleteAll();
        ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        Manager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ui.Show[PlayerPrefs.GetInt("ShowPlayer")].SetActive(true);
        Assignement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Assignement()
    {
        if (PlayerPrefs.GetInt("FirstTime" + childNumber) == 0&& childNumber>0)
        {

            PlayerPrefs.SetInt("FirstTime" + childNumber, 1);

            if (Manager.Shop[childNumber].locked)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(false); 
                PlayerPrefs.SetInt("Locked" + childNumber, 0);
            }
            else
            {
                PlayerPrefs.SetInt("Locked" + childNumber, 1);
            }
            
            PlayerPrefs.SetInt("Price" + childNumber, Manager.Shop[childNumber].Price);
        }
        else
        {
           
            if(PlayerPrefs.GetInt("Locked"+childNumber) == 0&&childNumber>0)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                gameObject.transform.GetChild(0).gameObject.SetActive(false); 
            }
        }
    }


    public void Buy()
    {
        if (Manager.Shop[childNumber].locked && PlayerPrefs.GetInt("Locked" + childNumber) == 0)
        {
            if (PlayerPrefs.GetInt("TotalHearts") >= PlayerPrefs.GetInt("Price"+childNumber))
            {
                Manager.Shop[childNumber].locked = false;
                PlayerPrefs.SetInt("Locked" + childNumber, 1);
                PlayerPrefs.SetInt("Player", childNumber);
                PlayerPrefs.SetInt("TotalHearts", PlayerPrefs.GetInt("TotalHearts") - 500);
              //  ui.BallHeart.text = PlayerPrefs.GetInt("TotalHearts").ToString();
             //   ui.MHeart.text = PlayerPrefs.GetInt("TotalHearts").ToString();
             //   ui.UHeart.text = PlayerPrefs.GetInt("TotalHearts").ToString();
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine("Notbuy");
            }
        }
     
    }

    IEnumerator Notbuy()
    {
        
        ui.NoHeartmessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        ui.NoHeartmessage.gameObject.SetActive(false);
    }

    public void Select()
    {
        //   ui.Title.SetActive(true);
        ui.Show[PlayerPrefs.GetInt("ShowPlayer")].SetActive(false);
        PlayerPrefs.SetInt("NeonNumber", childNumber);
        PlayerPrefs.SetInt("ShowPlayer", childNumber);
        ui.Show[PlayerPrefs.GetInt("ShowPlayer")].SetActive(true);
        GameManager.gameOn = true;
    }
}
