using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirador : MonoBehaviour
{
    public GameObject Bala;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Z))
      {
            GameObject Balinha = Instantiate(Bala, transform.position, Quaternion.identity);
            Destroy(Balinha, 3f);

      if(transform.localScale.x == 1)

            Balinha.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
      if (transform.localScale.x == -1)
            Balinha.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
        }
    }
}
