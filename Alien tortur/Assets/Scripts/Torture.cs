using UnityEngine;

public class Torture : MonoBehaviour
{


    public GameObject slime;

    private Color deathColor = Color.red;

    private void Start()
    {
        
    }


    public void VeryDangerousFunctionOfDeathPlaceholder()
    {
        GetComponent<SpriteRenderer>().color = deathColor;
    }
}
