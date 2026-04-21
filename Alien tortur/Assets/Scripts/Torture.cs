using System.Collections;
using UnityEngine;

public class Torture : MonoBehaviour
{
    bool isdeads = false;

    public GameObject slime;

    private Color alivecolor = Color.cyan;
    private Color deathColor = Color.red;

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
                isdeads = false;
                alivecolor = new Color(Random.Range(0F, 1F), Random.Range(0, 1F), Random.Range(0, 1F));
                GetComponent<SpriteRenderer>().color = alivecolor;
                transform.position = new Vector3(-13.23f, -1.96f, 0);
            }
        }
        //Når der kommer ny alien
        if(slime.transform.position.x < -0.23f)
        {
            transform.position += new Vector3(0.03f, 0, 0);
        }


    }

    public void VeryDangerousFunctionOfDeathPlaceholder()
    {
        GetComponent<SpriteRenderer>().color = deathColor;

        // Alien skal dø her hvis mulig.
        // Den kommer til at dø.
        // Lige her.
        // Og så smutter den.


        StartCoroutine(deadchecker());

    }

    IEnumerator deadchecker()
    {
        yield return new WaitForSeconds(1.0f);
        isdeads = true;
    }


}
