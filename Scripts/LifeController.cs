using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public static LifeController instance;
    private PlayerController player;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {

    }
}
