using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 10;
    public Vector3 pos = new Vector3(0, 0, 0);
    public GameObject ninja;
    private Rigidbody2D rb;
    private int direction = -1;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
 
    }


    void FixedUpdate()
    {
        Vector3 tempScale = new Vector3(-direction, 1, 1);
        transform.localScale = tempScale;


        Vector3 tempVect = new Vector3(-direction, 0, 0);
        tempVect = tempVect * speed * Time.deltaTime;
        //rb.MovePosition(rb.transform.position + tempVect);

        rb.AddForce(tempVect, ForceMode2D.Impulse);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Instantiate(ninja,new Vector3(0f,0f,0f), Quaternion.identity);
        }
        if (collision.gameObject.tag == "wall")
        {
            //direction = -direction;

            this.transform.position = pos;

        }
    }

 

    IEnumerator castSkill()
    {
        yield return new WaitForSeconds(Random.Range(5, 10));
        direction = -direction;
        StartCoroutine(castSkill());

    }

  
}
