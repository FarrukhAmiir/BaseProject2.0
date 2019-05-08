using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameOn)
        {

            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Enimies").transform.GetChild(0).position, speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
