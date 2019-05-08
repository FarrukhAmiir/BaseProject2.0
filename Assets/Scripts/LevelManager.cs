using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    public class Neons
    {
        public Button[] OnScreen;
        public GameObject[] Enimies;
        public GameObject[] Fire;
        public Sprite[] Background;
    }
    [System.Serializable]
    public class ShopManager
    {
        public bool locked;
        public int Price;
    }
    public Neons[] Neon;
    public ShopManager[] Shop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
