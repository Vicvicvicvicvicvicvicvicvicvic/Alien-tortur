using UnityEngine;

public class Drag : MonoBehaviour
{


    GameObject objSelected = null;

    private Vector3 origin;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    }

    void DropObject()
    {
        objSelected.transform.position = origin;
        objSelected = null;

    }

}
