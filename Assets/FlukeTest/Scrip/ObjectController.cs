using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField]private int id;
    
    [Header("New Position")]
    [SerializeField] float NX;
    [SerializeField] float NY;
    [SerializeField] float NZ;
    
    [Header("Original Position")]
    [SerializeField] float PX;
    [SerializeField] float PY;
    [SerializeField] float PZ;
    
    [Header("Time")]
    [SerializeField] private float timeStart = 1.0f;
    [SerializeField] private float timeBack = 1.0f;

    private void Start()
    {
        GameEvent.current.onEventTriggerEnter += OnObjectMove;
        GameEvent.current.onEventTriggerExit += OnObjectClose;
    }
    private void OnObjectClose(int id)
    {
        if(id == this.id)
        {
            LeanTween.move(gameObject, new Vector3(PX, PY, PZ), timeBack ).setEaseInQuad();
        }
    }

    private void OnObjectMove(int id)
    {
        if (id == this.id)
        {
            LeanTween.move(gameObject, new Vector3(NX, NY, NZ),timeStart).setEaseInQuad();
        }
    }
}
