using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Gerenciarcena : MonoBehaviour
{
    public void CarregueCena(int numeroCena)
    {
        SceneManager.LoadScene(numeroCena);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
