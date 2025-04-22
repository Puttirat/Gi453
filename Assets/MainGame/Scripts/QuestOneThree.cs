using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class QuestOneThree : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questText;
    private int itemsCollected = 0;
    private int chairCollected = 0;
    [SerializeField] private int itemsToCollect = 5;
    [SerializeField] private int chairToCollect = 2;
    [SerializeField] private float runSpeed = 12f;
    [SerializeField] private GameObject campfireWood;
    [SerializeField] private GameObject campfireLight;
    [SerializeField] private GameObject chair;
    [SerializeField] private GameObject SoundWalls;
    [SerializeField] private GameObject explore;
    [SerializeField] private GameObject mary;
    [SerializeField] private GameObject maryPlayer;
    [SerializeField] private GameObject mirror;
    [SerializeField] private GameObject foods;
    [SerializeField] private GameObject foodsClone;
    [SerializeField] private GameObject lighterObj;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject maryDead;
    [SerializeField] private GameObject mytsMan;
    [FormerlySerializedAs("CameraStart")] 
    [SerializeField] private GameObject CameraCutScene;
    [SerializeField] private GameObject murderCar;
    [SerializeField] private GameObject jackPlaceCan;
    [SerializeField] private GameObject jackPlaceCanCantTalk;
    [SerializeField] private GameObject marySit;
    [SerializeField] private GameObject itemUI;
    [SerializeField] private GameObject marySideCar;
    [SerializeField] private GameObject maryCantTalk;
    [Header("Dialogue")]
    [SerializeField] private GameObject maryTalk;
    [SerializeField] private GameObject maryTalkSetChair;
    [SerializeField] private GameObject jackTalkAfterGotStick;
    [SerializeField] private GameObject jackTalkWaitMary;
    [SerializeField] private GameObject jackTalkAtLighter;
    [SerializeField] private GameObject foodsReady;
    [SerializeField] private GameObject mythSound;

    [Header("List<Disk>")] 
    [SerializeField] private List<GameObject> disk;
    [SerializeField] private GameObject diskBookshelf;
    //[SerializeField] private GameObject tutorial;

    [Header("CutScene")] 
    [SerializeField] private GameObject cutSceneStart;
    [SerializeField] private GameObject cutSceneFirst;
    [SerializeField] private GameObject cutSceneEndGameFirst;
    [SerializeField] private GameObject cutSceneEnd1;
    [SerializeField] private GameObject cutSceneMaryDead;
    [SerializeField] private GameObject cutSceneEnd2;
    [SerializeField] private GameObject imageBlack;
    [SerializeField] private GameObject questHide;
    [SerializeField] private GameObject cutsceneLigther;
    [SerializeField] private GameObject cutsceneMurder;
    [SerializeField] private GameObject cutSceneMarryGotKnife;
    [SerializeField] private GameObject MarryGotKnifeText;
    [SerializeField] private GameObject cutSceneEat;
    [SerializeField] private GameObject murderMirrorScare;
    

    [Header("Audio")] 
    [SerializeField] private AudioClip pickWood;
    [SerializeField] private AudioClip pushStick;
    [SerializeField] private AudioClip placeChair;
    [SerializeField] private AudioClip placeCanFoods;
    [SerializeField] private AudioClip pickLighter;
    [SerializeField] private AudioClip lightAFire;
    [SerializeField] private AudioClip openDoorCar;
    [SerializeField] private AudioClip door;
    [SerializeField] private AudioClip scare;
    [SerializeField] private AudioClip maryScram;
    [SerializeField] private AudioClip pickKnife;
    

    [Header("AudioSource")] 
    [SerializeField] private AudioSource scareMystMan;
    [SerializeField] private AudioSource maryScram3D;
    [SerializeField] private GameObject soundMaryDead;

    [Header("Text Interactive")] 
    [SerializeField]
    private GameObject interacText;
    [SerializeField] PlayerMovement playerController;
    
    private bool Quest1 = false;
    private bool Quest2 = false;
    private bool Quest3 = false;
    private bool Quest4 = false;
    private bool QuestCleanup = false;
    private bool QuestExplore = false;
    private bool event3 = false;
    private bool escape = false;
    private bool ending2 = false;
    private bool cutScene1;
    private bool lighter = false;
    private bool lighterFire = false;
    private bool gotKnife = false;
    private bool lighterActive = false;
    private bool eatFoods;
    private ChracterSwap swapScript;
    private CameraFollow _cameraFollow;
    private SkyBox _skyBox;
    //private PickUpItemQuest hightlightObj;

    [SerializeField] private float timecount = 0;
    [SerializeField] private Material highlightMaterial;

    private Material defaultMaterial;
    private Transform highlight;
    private Transform _selection;
    private RaycastHit raycastHit;
    




    private void Start()
    {
        Quest1 = false;
        Quest2 = false;
        Quest3 = false;
        Quest4 = false;
        QuestCleanup = false;
        QuestExplore = false;
        event3 = false;
        escape = false;
        ending2 = false;
        cutScene1 = false;
        lighter = false;
        lighterFire = false;
        gotKnife = false;
        eatFoods = false;
        lighterActive = lighterObj.activeSelf;
        
        foods.SetActive(false);
        foodsClone.SetActive(false);
        chair.SetActive(false);
        campfireWood.SetActive(false);
        campfireLight.SetActive(false);
        SoundWalls.SetActive(false);
        explore.SetActive(false);
        mary.SetActive(false);
        mirror.SetActive(false);
        maryDead.SetActive(false);
        mytsMan.SetActive(false);
        murderCar.SetActive(false);
        jackPlaceCan.SetActive(false);
        marySit.SetActive(false);
        diskBookshelf.SetActive(false);
        maryCantTalk.SetActive(false);
        jackPlaceCanCantTalk.SetActive(false);

        swapScript = GetComponent<ChracterSwap>();
        _cameraFollow = GetComponent<CameraFollow>();
        _skyBox = GetComponent<SkyBox>();
        //hightlightObj = GetComponent<PickUpItemQuest>();
        StartCoroutine(CutsceneStartGame());
        playerController = FindObjectOfType<PlayerMovement>();


    }


    void Update()
    {
        RaycastHitE();
        RaycastHitAuto();
        playerController = FindObjectOfType<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        HighlightMat();
    }


    void RaycastHitE()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5f))
            {
                if (hit.collider.CompareTag("Pickable") && !Quest1)
                {
                    GetComponent<AudioSource>().PlayOneShot(pickWood);
                    Destroy(hit.collider.gameObject);
                    itemsCollected++;
                    UpdateQuest();
                }

                if (hit.transform.CompareTag("Area") || hit.transform.CompareTag("Area2") && Quest1 && !Quest2)
                {
                    GetComponent<AudioSource>().PlayOneShot(placeChair);
                    //chair.SetActive(true);
                    //Destroy(chairClone);
                    chairCollected++;
                    questText.text = "Setup Chair " + chairCollected +"/" + chairToCollect;
                    if (chairCollected >= chairToCollect && !Quest2 )
                    {
                        questText.text = "Use sticks to setup campfire";
                        swapScript.CharacterTheRoomSwap();
                        _skyBox.AfternoonTime();
                        murderCar.SetActive(false);
                        StartCoroutine(waitSpawMarySit());
                        StartCoroutine(JackAfterGotStickWood());
                        diskBookshelf.SetActive(true);
                    }

                }

                if (hit.transform.CompareTag("Camp") && Quest2 && !lighter)
                {
                    GetComponent<AudioSource>().PlayOneShot(pushStick);
                    campfireWood.SetActive(true);
                    lighter = true;
                    questText.text = "Find Lighter and Light up the campfire";
                    Quest2 = false;
                    
                }

                if (hit.transform.CompareTag("Lighter") && lighter)
                {
                    GetComponent<AudioSource>().PlayOneShot(pickLighter);
                     lighterObj.SetActive(false);
                     lighter = false;
                     lighterFire = true;
                     questText.text = "Find Lighter and Light up the campfire";
                     StartCoroutine(PickupLigtherCutScene());
                     marySit.SetActive(false);
                     maryCantTalk.SetActive(true);

                }
                
                if (hit.transform.CompareTag("Camp") && !lighter && lighterFire)
                {
                    GetComponent<AudioSource>().PlayOneShot(lightAFire);
                    //playerBlock.SetActive(false);
                    campfireLight.SetActive(true);
                    foodsClone.SetActive(true);
                    Quest3 = true;
                    questText.text = "Preparing Food on the table";
                    lighterFire = false;
                }
                

                //Scream
                if (hit.transform.CompareTag("Table") && Quest3 && !eatFoods)
                {
                    GetComponent<AudioSource>().PlayOneShot(placeCanFoods);
                    foods.SetActive(true);
                    questText.text = "Eat food at the table.";
                    Debug.Log("55555");
                    Quest3 = false;
                    swapScript.CharacterTwoSwap();
                    StartCoroutine(waitSoundNight());
                    //LookSound
                    //soundActive.isPlay
                }

                if (hit.transform.CompareTag("Table") && eatFoods && !Quest4)
                {
                    GetComponent<AudioSource>().PlayOneShot(placeCanFoods);
                    questText.text = "Check the Mysterious sound on main road";
                    Quest4 = true;
                    eatFoods = false;
                    StartCoroutine(EatFoodsCutScene());

                }
                

                if (hit.transform.CompareTag("Table") && QuestCleanup && QuestExplore)
                {
                    GetComponent<AudioSource>().PlayOneShot(placeCanFoods);
                    //QuestCleanup = false;
                    QuestExplore = false;
                    questText.text = "Find Mary";
                    foods.SetActive(false);
                    foodsClone.SetActive(false);
                    explore.SetActive(false);
                    mary.SetActive(true);
                    StartCoroutine(MaryScreamSound());
                    playerController.ChangeSpeed(runSpeed);
                    //SoundMaryScream
                }

                if (hit.transform.CompareTag("Mary") && QuestCleanup && !QuestExplore)
                {
                    //dialog talk Mary
                    questText.text = "Escape or go find Mysterious man in forest ";
                    explore.SetActive(true);
                    escape = true;
                    QuestExplore = true;
                    playerController.ChangeSpeed(6f);

                }

                if (hit.transform.CompareTag("CarDoor") && escape && QuestCleanup && QuestExplore)
                {
                    GetComponent<AudioSource>().PlayOneShot(openDoorCar);
                    questText.text = "Ending 1";
                    QuestCleanup = false;
                    QuestExplore = false;
                    StartCoroutine(cutSceneEndFirst());
                }
                
                if (hit.transform.CompareTag("Car") && ending2 && !escape && !QuestCleanup && !QuestExplore)
                {
                    
                    if (!gotKnife)
                    {
                        GetComponent<AudioSource>().PlayOneShot(openDoorCar);
                        questText.text = "Ending 2";
                        ending2 = false;
                        StartCoroutine(CutsceneMaryDead());
                    }
                    else if (gotKnife)
                    {
                        GetComponent<AudioSource>().PlayOneShot(openDoorCar);
                        ending2 = false;
                        StartCoroutine(CutSceneKnife());

                    }
                }

                if (hit.transform.CompareTag("Knife") && !gotKnife)
                {
                    GetComponent<AudioSource>().PlayOneShot(pickKnife);
                    Destroy(hit.transform.gameObject);
                    gotKnife = true;
                }

                if (hit.transform.CompareTag("Door") && !cutScene1)
                {
                    GetComponent<AudioSource>().PlayOneShot(door);
                    Debug.Log("Cut Scene");
                    StartCoroutine(Cutscenefirst());
                    swapScript.CharacterTheRoomSwapInput();
                    cutScene1 = true;
                    UpdateQuest();
                    ActivateObjectsDisk();
                }
                
                else if (hit.transform.CompareTag("Door") && cutScene1)
                {
                    GetComponent<AudioSource>().PlayOneShot(door);
                    Debug.Log("Swap Player");
                    if (swapScript.CharacterOne.activeSelf )
                    {
                        swapScript.CharacterOneSwap();
            
                    }

                    else if(swapScript.CharacterTheRoom.activeSelf)
                    {
                        swapScript.CharacterTheRoomSwapInput();
                        if (lighterObj.activeSelf != lighterActive)
                        {
                            lighterActive = lighterObj.activeSelf;
                            if (lighterActive)
                            {
                                StartCoroutine(JackTalkToLighter());
                                Debug.Log("Object is now active");
                            }
                            
                        }
            
                    }
                    
                }
                


            }


        }
    }

    void RaycastHitAuto()
    {
        RaycastHit hitAuto;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitAuto, 5f))
        {
            if (hitAuto.transform.CompareTag("WallSound") && Quest4 && !QuestCleanup && !QuestExplore)
            {
                MysteriousSound();
                SoundWalls.SetActive(false);
                StartCoroutine(MurderCutScene());
                //soundNotActive
            }

            if (hitAuto.transform.CompareTag("Explore") && QuestCleanup && QuestExplore && escape)
            {
                explore.SetActive(false);
                mary.SetActive(false);
                QuestCleanup = false;
                QuestExplore = false;
                event3 = false;
                escape = false;
                ending2 = true;
                questText.text = "Find Mary in The Car";
                maryScram3D.PlayOneShot(maryScram);
                playerController.ChangeSpeed(runSpeed);
               

            }

            if (hitAuto.transform.CompareTag("Explore") && QuestCleanup && QuestExplore && event3 && !escape)
            {
                Debug.Log("Event 3");
                explore.SetActive(false);
                mirror.SetActive(true);
                mary.SetActive(false);
                QuestCleanup = false;
                QuestExplore = false;
                event3 = false;
                ending2 = true;
                questText.text = "Find Mysterious Sound";
                maryPlayer.transform.position = new Vector3(408, 133, 570);
                swapScript.CharacterTwoSwap();
                mytsMan.SetActive(true);

            }

            if (hitAuto.transform.CompareTag("Mirror") && !QuestCleanup && !QuestExplore && !event3 && ending2)
            {
                scareMystMan.PlayOneShot(scare);
                GetComponent<AudioSource>().PlayOneShot(maryScram);
                StartCoroutine(AfterLookMirror());
                mirror.SetActive(false);
                questText.text = "";
            }

            if (hitAuto.collider.CompareTag("Pickable") && !Quest1)
            {
                interacText.SetActive(true);
            }
            
            else if (hitAuto.transform.CompareTag("Item") && Quest1 && !Quest2)
            {
                interacText.SetActive(true);
            }
            else if (hitAuto.transform.CompareTag("Camp") && Quest2 && !lighter)
            {
                interacText.SetActive(true);
                    
            }
            
            else if (hitAuto.transform.CompareTag("Lighter") && lighter)
            {
                interacText.SetActive(true);
            }
            
            else if (hitAuto.transform.CompareTag("Camp") && !lighter && lighterFire)
            {
                interacText.SetActive(true);
            }
            
            else if (hitAuto.transform.CompareTag("Table") && Quest3 && !Quest4)
            {
                interacText.SetActive(true);   
            }
            else if (hitAuto.transform.CompareTag("Table") && eatFoods && !Quest4)
            {
                interacText.SetActive(true);  
            }

            else if (hitAuto.transform.CompareTag("Table") && QuestCleanup && QuestExplore)
            {
                interacText.SetActive(true);
            }

            else if (hitAuto.transform.CompareTag("Mary") && QuestCleanup && !QuestExplore)
            {
                interacText.SetActive(true);
            }

            else if (hitAuto.transform.CompareTag("CarDoor") && escape && QuestCleanup && QuestExplore)
            {
                interacText.SetActive(true);
            }
                
            else if (hitAuto.transform.CompareTag("Car") && ending2 && !escape && !QuestCleanup && !QuestExplore)
            {
                interacText.SetActive(true);
            }
            
            else
            {
                interacText.SetActive(false);
            }
            
        }
        else
        {
            interacText.SetActive(false);
        }
    }

    public void UpdateQuest()
    {
        questText.text = "Stick Collected: " + itemsCollected + "/" + itemsToCollect + " In The Forest";
        if (itemsCollected >= itemsToCollect && !Quest1)
        {

            CompleteQuest1();
            swapScript.CharacterTwoSwap();
            murderCar.SetActive(true);
            marySideCar.SetActive(false);
            StartCoroutine(MaryTalkSetToChair());
        }
    }

    public void CompleteQuest1()
    {
        
        questText.text = "Setup Chair " + chairCollected +"/" + chairToCollect;
        Quest1 = true;
    }
    

    void MysteriousSound()
    {
        Debug.Log("Sound");
        questHide.SetActive(false);
        Quest4 = false;
        QuestCleanup = true;
        QuestExplore = true;
        event3 = true;
        StartCoroutine(waitSwapPlayerJack());
        StartCoroutine(JackTalkAfterWaitMary());
        questText.text = "Exploration or cleanup campsite";
        //swapScript.CharacterTheRoomSwap();
        explore.SetActive(true);
        jackPlaceCan.SetActive(false);
        
    }
    void ActivateObjectsDisk()
    {
        // วนลูปผ่านทุก GameObject ใน List
        foreach (GameObject obj in disk)
        {
            obj.SetActive(true);
        }
    }

    IEnumerator MaryScreamSound()
    {
        yield return new WaitForSeconds(1);
        maryScram3D.PlayOneShot(maryScram);
    }

    

    IEnumerator AfterLookMirror()
    {
        murderMirrorScare.SetActive(true);
        yield return new WaitForSeconds(1);

        // ตรวจสอบว่า mytsMan ไม่ได้เป็น null ก่อนที่จะทำลาย
        if (mytsMan != null)
        {
            Destroy(mytsMan);
        }
        else
        {
            Debug.LogWarning("mytsMan is null before attempting to destroy it.");
        }

        //StartCoroutine(waitSwapPlayerJackAfterMirror());
        questText.text = "";
        murderMirrorScare.SetActive(false);
        swapScript.CharacterTheRoomSwap();

        // ให้ Unity ได้รับโอกาสที่จะอัปเดต UI ในแต่ละ frame
        yield return null;

        yield return new WaitForSeconds(5);

        maryScram3D.PlayOneShot(maryScram);
        playerController.ChangeSpeed(runSpeed);
        questText.text = "Find Mary In Car";
        
    }


    
    IEnumerator waitSwapPlayerJack()
    {
        Debug.Log("Wait Swap ");
        yield return new WaitForSeconds(3);
        swapScript.CharacterTheRoomSwap();
        Debug.Log("swap");
        

    }
    
    IEnumerator waitSwapPlayerJackAfterMirror()
    {
        Debug.Log("Wait Swap ");
        yield return new WaitForSeconds(1);
        swapScript.CharacterTheRoomSwap();
        Debug.Log("swap");

    }

    IEnumerator LookAtSound()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Look Sound");
        
    }
    IEnumerator EatFoodsCutScene()
    {
        player.SetActive(false);
        questHide.SetActive(false);
        cutSceneEat.SetActive(true);
        yield return new WaitForSeconds(19);
        SoundWalls.SetActive(true);
        player.SetActive(true);
        questHide.SetActive(true);
        cutSceneEat.SetActive(false);
        jackPlaceCan.SetActive(true);
        jackPlaceCanCantTalk.SetActive(false);
        yield return null;
        yield return new WaitForSeconds(1);
        mythSound.SetActive(true);
        Debug.Log("Look Sound");
        
    }


    IEnumerator CutsceneStartGame()
    {
        player.SetActive(false);
        cutSceneStart.SetActive(true);
        yield return new WaitForSeconds(19);
        player.SetActive(true);
        cutSceneStart.SetActive(false);
        CameraCutScene.SetActive(false);
        

    }
    
    
    
    IEnumerator Cutscenefirst()
    {
        player.SetActive(false);
        cutSceneFirst.SetActive(true);
        CameraCutScene.SetActive(true);
        questHide.SetActive(false);
        yield return null;
        yield return new WaitForSeconds(10);
        player.SetActive(true);
        cutSceneFirst.SetActive(false);
        //tutorial.SetActive(false);
        CameraCutScene.SetActive(false);
        imageBlack.SetActive(false);
        questHide.SetActive(true);
        yield return null;
        yield return new WaitForSeconds(1);
        maryTalk.SetActive(true);
        

    }

    IEnumerator cutSceneEndFirst()
    {
        player.SetActive(false);
        cutSceneEndGameFirst.SetActive(true);
        //CameraCutScene.SetActive(true);
        questHide.SetActive(false);
        itemUI.SetActive(false);
        mary.SetActive(false);
        yield return new WaitForSeconds(35);
        StartCoroutine(CutsceneEndGame1());
        cutSceneEndGameFirst.SetActive(false);
    }
    
    IEnumerator CutsceneEndGame1()
    {
        cutSceneEnd1.SetActive(true);
        CameraCutScene.SetActive(true);
        yield return new WaitForSeconds(23);
        player.SetActive(true);
        cutSceneEnd1.SetActive(false);
        CameraCutScene.SetActive(false);
        EndGame();
        
    }
    
    IEnumerator CutsceneEndGame2()
    {
        
        cutSceneEnd2.SetActive(true);
        yield return new WaitForSeconds(20);
        player.SetActive(true);
        cutSceneEnd2.SetActive(false);
        CameraCutScene.SetActive(false);
        EndGame();

    }
    
    IEnumerator CutsceneMaryDead()
    {
        soundMaryDead.SetActive(true);
        player.SetActive(false);
        maryDead.SetActive(true);
        cutSceneMaryDead.SetActive(true);
        CameraCutScene.SetActive(true);
        questHide.SetActive(false);
        itemUI.SetActive(false);
        yield return new WaitForSeconds(21);
        StartCoroutine(CutsceneEndGame2());
        cutSceneMaryDead.SetActive(false);


    }

    IEnumerator waitSoundNight()
    {
        yield return new WaitForSeconds(1);
        _skyBox.NightTime();
        jackPlaceCanCantTalk.SetActive(true);
        maryCantTalk.SetActive(false);
        yield return new WaitForSeconds(1);
        eatFoods = true;
        foodsReady.SetActive(true);
    }
    
    IEnumerator waitSpawMarySit()
    {
        yield return new WaitForSeconds(1);
        marySit.SetActive(true);
    }

    IEnumerator PickupLigtherCutScene()
    {
        
        cutsceneLigther.SetActive(true);
        player.SetActive(false);
        yield return new WaitForSeconds(18);
        cutsceneLigther.SetActive(false);
        player.SetActive(true);
        
    }
    
    IEnumerator MurderCutScene()
    {
        
        cutsceneMurder.SetActive(true);
        player.SetActive(false);
        yield return new WaitForSeconds(3);
        cutsceneMurder.SetActive(false);
        player.SetActive(true);
        
    }

    IEnumerator CutSceneKnife()
    {
        cutSceneMarryGotKnife.SetActive(true);
        player.SetActive(false);
        CameraCutScene.SetActive(true);
        questHide.SetActive(false);
        itemUI.SetActive(false);
        yield return new WaitForSeconds(10);
        cutSceneMarryGotKnife.SetActive(false);
        StartCoroutine(AfterCutSceneKnife());

    }

    IEnumerator AfterCutSceneKnife()
    {
        MarryGotKnifeText.SetActive(true);
        yield return new WaitForSeconds(7);
        CameraCutScene.SetActive(false);
        player.SetActive(true);
        MarryGotKnifeText.SetActive(false);
        EndGame();
    }

    IEnumerator MaryTalkSetToChair()
    {
        yield return new WaitForSeconds(3);
        maryTalkSetChair.SetActive(true);
    }
    
    IEnumerator JackAfterGotStickWood()
    {
        yield return new WaitForSeconds(3);
        jackTalkAfterGotStick.SetActive(true);
        Quest2 = true;
    }
    
    IEnumerator JackTalkAfterWaitMary()
    {
        yield return new WaitForSeconds(5);
        jackTalkWaitMary.SetActive(true);
    }
    
    IEnumerator JackTalkToLighter()
    {
        yield return new WaitForSeconds(3);
        jackTalkAtLighter.SetActive(true);
    }

    
    void HighlightMat()
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
        if(!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray , out raycastHit,5f ))
        {
            highlight = raycastHit.transform;
            if (highlight != null)
            {
                if (highlight.CompareTag("Pickable") && !Quest1 && highlight != _selection)
                {
                    HighlightDiskMat();
                }

                else if (highlight.transform.CompareTag("Item") && Quest1 && !Quest2 && highlight != _selection)
                {
                    HighlightDiskMat();

                }
                else if (highlight.transform.CompareTag("Table") && Quest3 && !eatFoods && highlight != _selection)
                {
                    HighlightDiskMat();
                }
                else if (highlight.transform.CompareTag("Table") && eatFoods && !Quest4 && highlight != _selection)
                {
                    HighlightDiskMat();
                }
                else if (highlight.transform.CompareTag("Table") && QuestCleanup && QuestExplore && highlight != _selection)
                {
                    HighlightDiskMat();
                }
                else if (highlight.transform.CompareTag("CarDoor") && escape && QuestCleanup && QuestExplore &&
                         highlight != _selection)
                {
                    HighlightDiskMat();
                }
                else if (highlight.transform.CompareTag("Car")&& ending2 && !escape && !QuestCleanup && !QuestExplore && highlight != _selection)
                {
                    HighlightDiskMat();
                }

                else
                {
                    highlight = null;

                }
            }


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
    
    public void EndGame()
    {
        

        /*#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
             Application.Quit();
        #endif*/
        SceneManager.LoadScene(0);
    }
    







}
