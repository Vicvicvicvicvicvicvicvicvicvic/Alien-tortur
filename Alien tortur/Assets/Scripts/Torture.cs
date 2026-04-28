using System;
using System.Collections;
using UnityEngine;

public class Torture : MonoBehaviour
{
    bool isdeads = false;

    public GameObject slime;
    public GameObject dragscript;
    private Color alivecolor = Color.cyan;
    public Sprite beforeuse;
    public Sprite afteruse;
    private Color deathColor = Color.red;
    public bool isMovingyesno = false;

    private void Start()
    {
        
    }
    private void Update()
    {
        //Når den dør.
        if(isdeads == true)
        {
            transform.position += new Vector3(0.03f, 0, 0);
            if (slime.transform.position.x > 12)
            {
                slime.GetComponent<SpriteRenderer>().sprite = beforeuse;
                isdeads = false;
                dragscript.GetComponent<Drag>().resettools();
                transform.position = new Vector3(-13.23f, -1.96f, 0);
            }
        }
        //Når der kommer ny alien
        if (slime.transform.position.x < -0.23f)
        {
            transform.position += new Vector3(0.03f, 0, 0);
            isMovingyesno = true;
        }
        else if (slime.transform.position.x > -0.19f)
        {
            isMovingyesno = true;
        }
        else if (isdeads == true)
        {
            isMovingyesno = true;
        }
        else
        {
            isMovingyesno = false;
        }

            
        


    }

    public void VeryDangerousFunctionOfDeathPlaceholder()
    {
        GetComponent<SpriteRenderer>().sprite = afteruse;

        // Alien skal dø her hvis mulig.
        // Den kommer til at dø.
        // Lige her.
        // Og så smutter den.


        StartCoroutine(deadchecker());

    }

    IEnumerator deadchecker()
    {
        isdeads = true;
        yield return new WaitForSeconds(1.0f);
        
    }


}
