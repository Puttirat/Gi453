using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PickUpItemQuest : MonoBehaviour
{
    /*[SerializeField] private string selectableTag = "Pickable";
    [SerializeField] private Material highlightMaterial;*/
    [SerializeField] private GameObject interactiveText;

    private Material defaultMaterial;
    private Transform highlight;
    private Transform _selection;
    private RaycastHit raycastHit;
    

    void FixedUpdate()
    {
        /*PickAbleItem();
        PickChair();*/
        HighlightDisk();
    }

    /*public void PickAbleItem()
    {
       if (highlight != null)
       {
            highlight.GetComponent<MeshRenderer>().material = defaultMaterial;
            highlight = null;
       }
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray , out raycastHit,5f ))
        {
            highlight = raycastHit.transform;
            if(highlight.CompareTag("Pickable") && highlight != _selection)
            {
                if (highlight.GetComponent<MeshRenderer>().material != highlightMaterial)
                {
                    defaultMaterial = highlight.GetComponent<MeshRenderer>().material;
                    highlight.GetComponent<MeshRenderer>().material = highlightMaterial;
                }
            }
            else
            {
                highlight = null;
            }
        }
    }
    
    public void PickChair()
    {
        if (highlight != null)
        {
            highlight.GetComponent<MeshRenderer>().material = defaultMaterial;
            highlight = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray , out raycastHit,5f ))
        {
            highlight = raycastHit.transform;
            if(highlight.CompareTag("Item") && highlight != _selection)
            {
                if (highlight.GetComponent<MeshRenderer>().material != highlightMaterial)
                {
                    defaultMaterial = highlight.GetComponent<MeshRenderer>().material;
                    highlight.GetComponent<MeshRenderer>().material = highlightMaterial;
                    
                }
            }
            else
            {
                highlight = null;
            }
        }
    }*/
    
    public void HighlightDisk()
    {
        if (highlight != null)
        {
            Outline outlineComponent = highlight.gameObject.GetComponent<Outline>();
        
            if (outlineComponent != null)
            {
                outlineComponent.enabled = false;
            }
        
            highlight = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray , out raycastHit,7f ))
        {
            highlight = raycastHit.transform;
            if (highlight != null)
            {
                Debug.Log("Highlight Tag: " + highlight.tag);
                if(highlight.CompareTag("DiskDoor") && highlight != _selection)
                {
                    HighlightDiskMat();
                    interactiveText.SetActive(true);
                }
            
                else if(highlight.CompareTag("DiskFlashlight") && highlight != _selection)
                {
                    HighlightDiskMat();
                    interactiveText.SetActive(true);
                }
                else if(highlight.CompareTag("DiskLighter") && highlight != _selection)
                {
                    HighlightDiskMat();
                    interactiveText.SetActive(true);
                }
                else if(highlight.CompareTag("DiskBookShelf") && highlight != _selection)
                {
                    HighlightDiskMat();
                    interactiveText.SetActive(true);
                }
                else if(highlight.CompareTag("DiskDeer") && highlight != _selection)
                {
                    HighlightDiskMat();
                    interactiveText.SetActive(true);
                }
                else if(highlight.CompareTag("Knife") && highlight != _selection)
                {
                    HighlightDiskMat();
                    interactiveText.SetActive(true);
                }
                else if(highlight.CompareTag("Flashlight") && highlight != _selection)
                {
                    HighlightDiskMat();
                    interactiveText.SetActive(true);
                }
                else
                {
                    highlight = null;
                    interactiveText.SetActive(false);
                } 
            }
            
            
        }
        else
        {
            interactiveText.SetActive(false);
        }
    }

    void HighlightDiskMat()
    {
        
            Outline _outline = highlight.gameObject.GetComponent<Outline>();
            if (_outline == null)
            {
                _outline = highlight.gameObject.AddComponent<Outline>();
            }
            _outline.enabled = true;
            _outline.OutlineColor = Color.magenta;
            _outline.OutlineWidth = 10f;
        
    }
}
