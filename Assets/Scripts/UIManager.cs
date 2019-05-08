using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   
    public Text Life, Score;
    public LevelManager level;
    public Text NoHeartmessage,MainDiamonds,ShopDiamonds,ScoreText,DiamondsText,HighScore,GameUpperDiamond;
    public GameObject Shop,pauseWindow,GameOver,Settings,MusicOn,MusicOff,SoundOn,SoundOff,background,left,right;
    public GameObject[] Show;
    GameManager Manager;
    int levelNumber;
    Scene CurrentScene;
    GameManager manager;
    public Sprite[] Backgrounds;
    TestSound Sound;
    private void Awake()
    {
        Sound = GameObject.Find("SoundManager").GetComponent<TestSound>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
        Sound = GameObject.Find("SoundManager").GetComponent<TestSound>();
        if (PlayerPrefs.GetInt("Music") == 0)
        {

            MusicOn.GetComponent<Button>().interactable = false;
            MusicOff.GetComponent<Button>().interactable = true;
            Sound.UnMuteMusic("Background");

        }


        else if (PlayerPrefs.GetInt("Music") == 1)
        {
            MusicOn.GetComponent<Button>().interactable = true;
            MusicOff.GetComponent<Button>().interactable = false;
            Sound.MuteMusic("Background");
        }

        if (PlayerPrefs.GetInt("Sound") == 0)
        {

            SoundOn.GetComponent<Button>().interactable = false;
            SoundOff.GetComponent<Button>().interactable = true;
            Sound.UnMuteMusic("1");
            Sound.UnMuteMusic("Buzz3");
            Sound.UnMuteMusic("Diamond");
            PlayerPrefs.SetInt("Sound", 0);
        }

        else if (PlayerPrefs.GetInt("Sound") == 1)
        {
            SoundOn.GetComponent<Button>().interactable = true;
            SoundOff.GetComponent<Button>().interactable = false;
            Sound.MuteMusic("1");
            Sound.MuteMusic("Buzz3");
            Sound.MuteMusic("Diamond");

        }
        CurrentScene = SceneManager.GetActiveScene();
        if (CurrentScene.name == "MainMenu")
        {
            ShopDiamonds.text = PlayerPrefs.GetInt("Diamonds").ToString();
            MainDiamonds.text = PlayerPrefs.GetInt("Diamonds").ToString();
            HighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
            
        }
        else
        {
            manager = GameObject.Find("GameManager").GetComponent<GameManager>();
            int back = Random.Range(0, Backgrounds.Length);
            background.GetComponent<Image>().sprite = Backgrounds[back];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(string name)
    {
        Sound = GameObject.Find("SoundManager").GetComponent<TestSound>();
        if (GameManager.gameOn)
        {
            Sound.PlaySounds("1");
            if (name == "0")
            {
                GameObject obj = Instantiate(level.Neon[PlayerPrefs.GetInt("NeonNumber")].Fire[0], new Vector3(1.92f, 3.98f, 0), Quaternion.identity);
                obj.name = "Blue";
                obj.transform.SetParent(GameObject.Find("Fire").transform);

            }
            else if (name == "1")
            {
                GameObject obj = Instantiate(level.Neon[PlayerPrefs.GetInt("NeonNumber")].Fire[1], new Vector3(1.92f, 2.02f, 0), Quaternion.identity);
                obj.name = "White";
                obj.transform.SetParent(GameObject.Find("Fire").transform);
            }
            else if (name == "2")
            {
                GameObject obj = Instantiate(level.Neon[PlayerPrefs.GetInt("NeonNumber")].Fire[2], new Vector3(1.92f, -0.52f, 0), Quaternion.identity);
                obj.name = "Green";
                obj.transform.SetParent(GameObject.Find("Fire").transform);
            }
            else if (name == "3")
            {
                GameObject obj = Instantiate(level.Neon[PlayerPrefs.GetInt("NeonNumber")].Fire[3], new Vector3(-1.92f, 3.98f, 0), Quaternion.identity);
                obj.name = "Purple";
                obj.transform.SetParent(GameObject.Find("Fire").transform);

            }
            else if (name == "4")
            {
                GameObject obj = Instantiate(level.Neon[PlayerPrefs.GetInt("NeonNumber")].Fire[4], new Vector3(-1.92f, 2.02f, 0), Quaternion.identity);
                obj.name = "Pink";
                obj.transform.SetParent(GameObject.Find("Fire").transform);
            }

            else if (name == "5")
            {
                GameObject obj = Instantiate(level.Neon[PlayerPrefs.GetInt("NeonNumber")].Fire[5], new Vector3(-1.92f, -0.52f, 0), Quaternion.identity);
                obj.name = "Orange";
                obj.transform.SetParent(GameObject.Find("Fire").transform);
            }
        }
    
    }

    public void Click(string name)
    {
        if(name == "HomeShop")
        {
            Shop.SetActive(false);
        }

        else if(name =="Shop")
        {
            Shop.SetActive(true);
        }

        else if (name == "Play")
        {
            GameManager.gameOn = true;
            SceneManager.LoadScene(1);
        }

        else if (name == "Pause")
        {
            Time.timeScale = 0;
            pauseWindow.SetActive(true);
        }

        else if (name == "Resume")
        {
            Time.timeScale = 1;
            pauseWindow.SetActive(false);
        }

        else if (name == "Retry")
        {
            GameManager.gameOn = true;
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }

        else if (name == "Home")
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
            
        }

        else if (name == "Settings")
        {
            Settings.SetActive(true);
        }

        else if (name == "Okay")
        {
            Settings.SetActive(false);
        }

        else if (name == "MusicOn")
        {
            MusicOn.GetComponent<Button>().interactable = true;
            MusicOff.GetComponent<Button>().interactable = false;
            Sound.MuteMusic("Background");
            PlayerPrefs.SetInt("Music", 1);
        }

        else if (name == "MusicOff")
        {
            MusicOn.GetComponent<Button>().interactable = false;
            MusicOff.GetComponent<Button>().interactable = true;
            Sound.UnMuteMusic("Background");
            PlayerPrefs.SetInt("Music", 0);
        }

        else if (name == "SoundOn")
        {
            SoundOn.GetComponent<Button>().interactable = true;
            SoundOff.GetComponent<Button>().interactable = false;
            Sound.MuteMusic("1");
            Sound.MuteMusic("Buzz3");
            Sound.MuteMusic("Diamond");
            PlayerPrefs.SetInt("Sound", 1);
        }

        else if (name == "SoundOff")
        {
            SoundOn.GetComponent<Button>().interactable = false;
            SoundOff.GetComponent<Button>().interactable = true;
            Sound.UnMuteMusic("1");
            Sound.UnMuteMusic("Buzz3");
            Sound.UnMuteMusic("Diamond");
            PlayerPrefs.SetInt("Sound", 0);
        }

        else if(name == "Left")
        {
            left.GetComponent<Button>().interactable = false;
            right.GetComponent<Button>().interactable = true;
        }
        else if (name == "Right")
        {
            left.GetComponent<Button>().interactable = true;
            right.GetComponent<Button>().interactable = false;
        }
    }
}
