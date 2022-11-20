using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    private int direction=0;
    public float movePower=1f;
    private Rigidbody2D rb;
    IEnumerator ChangeDirection()
    {
        direction = Random.Range(0,2);
        yield return new WaitForSeconds(1f);
        StartCoroutine("ChangeDirection");
    }
    void move() 
    {
        if (direction==0)
        {
            rb.velocity = new Vector3(movePower * Time.deltaTime, 0, 0);
        }else if (direction==1)
        {
            rb.velocity = new Vector3(movePower * Time.deltaTime * (-1), 0, 0);
        }
    }
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        StartCoroutine("ChangeDirection");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }
}
