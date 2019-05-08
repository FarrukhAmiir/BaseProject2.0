using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("DiamondPos").transform.position, 10 * Time.deltaTime);

        if (transform.position == GameObject.Find("DiamondPos").transform.position)
        {
            Destroy(gameObject);
        }

    }
}
