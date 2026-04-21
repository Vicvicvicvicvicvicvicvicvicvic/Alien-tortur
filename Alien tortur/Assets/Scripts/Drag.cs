using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Drag : MonoBehaviour
{
    [SerializeField]
    public Collider2D syringecollider;
    public Collider2D slimecollider;
    public GameObject slimey;
    public Sprite beforeuse;
    public Sprite afteruse;
    public GameObject syringe;

    GameObject objSelected = null;
    private Vector3 origin;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    public void resettools()
    {
        syringe.GetComponent<SpriteRenderer>().sprite = beforeuse;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckHitObject();
            
        }
        if (Input.GetMouseButton(0) && objSelected != null)
        {
            DragObject();
        }
        if (Input.GetMouseButtonUp(0) && objSelected != null)
        {
            DropObject();
        }
    }


    void CheckHitObject()
    {
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

        if (hit2D.collider != null)
        {
            GameObject hitfourd = hit2D.collider.gameObject;
            origin = hitfourd.transform.position;

            if (hitfourd.tag == "Tool")
            {
                objSelected = hit2D.transform.gameObject;
            }
            
        }


    }

    void DragObject()
    {
        objSelected.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 10.0f));
        objSelected.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void DropObject()
    {
        StartCoroutine(Example());
        
    }

    void DropCheck()
    {
        if (syringecollider.IsTouching(slimecollider))
        {

            print("Døds.");
            syringe.GetComponent<SpriteRenderer>().sprite = afteruse;

        }
    }

    IEnumerator Example()
    {
        DropCheck();
        yield return new WaitForSeconds(1.0f);
        slimey.GetComponent<Torture>().VeryDangerousFunctionOfDeathPlaceholder();
        objSelected.transform.position = origin;
        objSelected.transform.rotation = Quaternion.Euler(0, 0, 70);
        objSelected = null;
    }





}
