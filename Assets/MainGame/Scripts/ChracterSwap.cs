using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ChracterSwap : MonoBehaviour
{
    public GameObject CharacterOne;
    public GameObject CharacterTwo;
    public GameObject CharacterTheRoom;
    [SerializeField] private GameObject HiddenText;
    [SerializeField] private Animator tranAnim;
    [SerializeField] private float waitAnim = 1f;
    [SerializeField] private GameObject playerRoom;
    [SerializeField] private GameObject player1;
    


    void Start()
    {
        //CharacterOneSwap();
        CharacterOne.SetActive(false);
        CharacterTwo.SetActive(false);
        CharacterTheRoom.SetActive(true);
        
    }

    void Update()
    {
        /*if (CharacterOne.activeSelf )
        {
            CharacterOneSwap();
            
        }

        else if(CharacterTheRoom.activeSelf)
        {
            CharacterTheRoomSwapInput();
            
        }*/
        
       
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            CharacterTwoSwap();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            CharacterTheRoomSwap();
        }
    }

    public void CharacterOneSwap()
    {
        
        StartCoroutine(TransitionCharacterOne());
        /*CharacterOne.SetActive(false);
        CharacterTwo.SetActive(false);
        CharacterTheRoom.SetActive(true);*/
        //Debug.Log("RRRR");
        
    }

    public void CharacterTwoSwap()
    {
        StartCoroutine(TransitionCharacterTwo());
        /*CharacterOne.SetActive(false);
        CharacterTwo.SetActive(true);
        CharacterTheRoom.SetActive(false);*/
        
    }

    public void CharacterTheRoomSwapInput()
    {
        StartCoroutine(TransitionTheRoomSwapInput());
        /*CharacterOne.SetActive(true);
        CharacterTwo.SetActive(false);
        CharacterTheRoom.SetActive(false);*/
        //Debug.Log("tTTTTt");

    }
    public void CharacterTheRoomSwap()
    {
        StartCoroutine(TransitionCharacterTheRoomSwap());
        /*CharacterOne.SetActive(true);
        CharacterTwo.SetActive(false);
        CharacterTheRoom.SetActive(false);*/
        
    }


    IEnumerator TransitionCharacterTheRoomSwap()
    {
        tranAnim.SetTrigger("Start");
        HiddenText.SetActive(false);
        yield return new WaitForSeconds(waitAnim);
        CharacterOne.SetActive(true);
        CharacterTwo.SetActive(false);
        CharacterTheRoom.SetActive(false);
        HiddenText.SetActive(true);
        tranAnim.SetTrigger("End");
    }
    
    
    IEnumerator TransitionTheRoomSwapInput()
    {
        tranAnim.SetTrigger("Start");
        yield return new WaitForSeconds(waitAnim);
        CharacterOne.SetActive(true);
        CharacterTwo.SetActive(false);
        CharacterTheRoom.SetActive(false);
        tranAnim.SetTrigger("End");
        player1.transform.rotation = quaternion.Euler(0f,+0f,0f); 
    }
    
    IEnumerator TransitionCharacterOne()
    {
        tranAnim.SetTrigger("Start");
        yield return new WaitForSeconds(waitAnim);
        CharacterOne.SetActive(false);
        CharacterTwo.SetActive(false);
        CharacterTheRoom.SetActive(true);
        tranAnim.SetTrigger("End");
        playerRoom.transform.rotation = quaternion.Euler(0f,+180f,0f); 
    }
    
    IEnumerator TransitionCharacterTwo()
    {
        tranAnim.SetTrigger("Start");
        HiddenText.SetActive(false);
        yield return new WaitForSeconds(waitAnim);
        CharacterOne.SetActive(false);
        CharacterTwo.SetActive(true);
        CharacterTheRoom.SetActive(false);
        HiddenText.SetActive(true);
        tranAnim.SetTrigger("End");
    }
    
    
}
