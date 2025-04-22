using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Item";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material DefaultMaterial;
    private Transform _selection;
    [SerializeField] private GameObject pickUpUI;

    void Update()
    {
        if(_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = DefaultMaterial;
            _selection = null;
            pickUpUI.SetActive(false);
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit) )
        {
            var selection = hit.transform;
            if( selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if( selectionRenderer != null )
                {
                    selectionRenderer.material = highlightMaterial;
                }
                _selection = selection;
                pickUpUI.SetActive(true);
            }
        }
    }
}
