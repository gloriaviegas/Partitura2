using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class mostro : MonoBehaviour
{
    public int Life;
    public Rigidbody2D Corpo;
    public float speedM = 3;



    void Update()
    {
        Corpo.velocity = new Vector2(0, speedM);
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Balinha")
        {
            Destroy(collision.gameObject);
            Life--;
            if (Life <= 0)
                Destroy(this.gameObject);
        }



        if (collision.gameObject.tag == "Limitecima")
        {
            
            speedM = -15;
        }

        if (collision.gameObject.tag == "Limitebaixo")
        {

            speedM = 15;
        }
    }
}
