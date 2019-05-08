using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{

    public LevelManager level;
    public float timeBetween;
    public float speed;
    int levelNumber;
    public GameObject diamond;
    public int score = 0, life = 3,diamondCount;
    public static bool gameOn= true;
    public bool clear = false;
    // Start is called before the first frame update
    void Start()
    {
        //if(clear)
        //{

        //    PlayerPrefs.DeleteAll();
        //}
        Time.timeScale = 1;
        level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        levelNumber = PlayerPrefs.GetInt("NeonNumber");
        StartCoroutine(EnemyCreation());
        OnScreenScreation();
        Debug.Log("dsd"+ levelNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemyCreation()
    {
      //  yield return new WaitForSeconds(1f);
        while (gameOn)
        {
           
            int r = Random.Range(0, level.Neon[levelNumber].Enimies.Length);
            GameObject obj = Instantiate(level.Neon[levelNumber].Enimies[r]);
            obj.transform.SetParent(GameObject.Find("Enimies").transform);
            obj.transform.position = GameObject.Find("Enimies").transform.position;
            obj.name = obj.name.Remove(obj.name.Length - 7);
            
            yield return new WaitForSeconds(timeBetween);
        }
    }

    public void OnScreenScreation()
    {
        for(int i = 0;i<level.Neon[levelNumber].OnScreen.Length;i++)
        {
            Button But = Instantiate(level.Neon[levelNumber].OnScreen[i], GameObject.Find("Canvas").transform);
            But.transform.SetSiblingIndex(i+1);
        }
    }
}
