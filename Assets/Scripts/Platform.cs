using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField]
    GameObject Player;

    BoxCollider2D coll;


    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if player y is below a platform y turn off collider
        if(Player.transform.position.y < transform.position.y)
        {
            coll.enabled = false;
        }
        //if player y is above a platform y turn on collider
        if(Player.transform.position.y > transform.position.y)
        {
            coll.enabled = true;
        }
        //if user pushes down then turn off collider
        if(Input.GetAxis("Vertical") < 0)
        {
            coll.enabled = false;
        }




    }
}
