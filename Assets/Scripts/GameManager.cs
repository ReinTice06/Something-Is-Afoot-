using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject Player;
    public GameObject Canvas;
    public CollectibleCounter Counter;


    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(Canvas);
        DontDestroyOnLoad(Counter);
        DontDestroyOnLoad(Player);
        DontDestroyOnLoad(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

