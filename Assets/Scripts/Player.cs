using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   

    GameManager manager;
    UIManager ui;
    CameraShake cam;
    TestSound Sound;
    // Start is called before the first frame update
    void Start()
    {
        Sound = GameObject.Find("SoundManager").GetComponent<TestSound>();
        cam = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-(Vector3.up *manager.speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == gameObject.tag)
        {
            int diam = Random.Range(1, 4);
            if(diam ==3)
            {
                Sound.PlaySounds("Diamond");
                GameObject d = Instantiate(manager.diamond, GameObject.Find("Enimies").transform);
                d.transform.position = transform.position;
                manager.diamondCount++;
                ui.GameUpperDiamond.text = manager.diamondCount.ToString();
                
            }
            manager.score += 5;
            if(manager.score>=15 &&manager.score<=50)
            {
                manager.speed = 1.2f;
                manager.timeBetween = 1.7f;
            }
            else  if (manager.score >= 51 && manager.score<=80)
            {
                manager.speed = 1.7f;
                manager.timeBetween = 1.1f;
            }
            else if (manager.score >= 81 && manager.score <= 150)
            {
                manager.speed = 2.2f;
                manager.timeBetween = 0.7f;
            }
            else if (manager.score >= 151 )
            {
                manager.speed = 3.0f;
                manager.timeBetween = 0.4f;
            }
            ui.Score.text = manager.score.ToString();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Boundary")
        {
            Sound.PlaySounds("Buzz3");
            cam.Shake(0.3f, 0.1f);
            Handheld.Vibrate();
            manager.life--;
            ui.Life.text = manager.life.ToString();
            if (manager.life <= 0)
            {
                ui.ScoreText.text = manager.score.ToString();
                ui.DiamondsText.text = manager.diamondCount.ToString();
                StartCoroutine(PauseWindow());
                if (manager.score> PlayerPrefs.GetInt("HighScore"))
                {
                  //  ui.HighScore.text = manager.score.ToString();
                    PlayerPrefs.SetInt("HighScore", manager.score);
                    Debug.Log(PlayerPrefs.GetInt("HighScore"));
                }
                GameManager.gameOn = false;
               
                Destroy(GameObject.Find("Enimies"));
            }
          
            Destroy(gameObject);
        }

        else if(collision.gameObject.tag != gameObject.tag)
        {
            Sound.PlaySounds("Buzz3");
            cam.Shake(0.3f, 0.1f);
            Handheld.Vibrate();
            manager.life--;
            ui.Life.text = manager.life.ToString();
            if(manager.life<=0)
            {
                ui.ScoreText.text = manager.score.ToString();
                ui.DiamondsText.text = manager.diamondCount.ToString();
                StartCoroutine(PauseWindow());
                if (manager.score > PlayerPrefs.GetInt("HighScore"))
                {
                 
                    PlayerPrefs.SetInt("HighScore", manager.score);
                    Debug.Log(PlayerPrefs.GetInt("HighScore"));
                }
                GameManager.gameOn = false;
               
                Destroy(GameObject.Find("Enimies"));
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    IEnumerator PauseWindow()
    {
        PlayerPrefs.SetInt("Diamonds", manager.diamondCount + PlayerPrefs.GetInt("Diamonds"));
        ui.GameOver.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
    }
}
