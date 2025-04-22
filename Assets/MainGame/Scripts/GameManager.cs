using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> inventory;
    [SerializeField] private Camera _camera;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pickable();
        }
    }
    
    void Pickable()
    {
        RaycastHit hitinfo;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward,out hitinfo,5 ))
        {
            if (hitinfo.collider.gameObject.tag == "Pickable")
            {
                inventory.Add(hitinfo.collider.gameObject);
                Debug.Log(  "Picked!");
                Destroy(hitinfo.collider.gameObject);
            }
            
            
        }
    }
}
