using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Mainmenu : MonoBehaviour
{
    [SerializeField] AudioSource sound;

    [SerializeField] Camera mainCamera;
    [SerializeField] float rotationSpeed = 30f;

    [SerializeField] GameObject title;
    [SerializeField] Button startButton;
    [SerializeField] Button creditButton;
    [SerializeField] Button exitButton;
    [SerializeField] Button backButton;
    [SerializeField] GameObject GameObjectToHide;
    [SerializeField] float MinTime = 2.0f;
    [SerializeField] float MaxTime = 5.0f;


    private bool isRotating = false;
    private bool isRotatingBack = false;
    private float totalRotation = 0f;

    private void Start()
    {
        title.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        creditButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false);

        StartCoroutine(ToggleVisibilityCo(GameObjectToHide));
    }
    private void Update()
    {
        if (isRotating)
        {
            title.gameObject.SetActive(false);
            startButton.gameObject.SetActive(false);
            creditButton.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);

            mainCamera.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            totalRotation += rotationSpeed * Time.deltaTime;

            if (totalRotation >= 90f)
            {
                isRotating = false;
                backButton.gameObject.SetActive(true);
            }
        }

        if (isRotatingBack)
        {
            backButton.gameObject.SetActive(false);

            mainCamera.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            totalRotation += rotationSpeed * Time.deltaTime;

            if (totalRotation <= 0f)
            {
                isRotatingBack = false;
                rotationSpeed *= -1f;
                title.gameObject.SetActive(true);
                startButton.gameObject.SetActive(true);
                creditButton.gameObject.SetActive(true);
                exitButton.gameObject.SetActive(true);
            }
        }
    }

    public void StartGame()
    {
        sound.Play();
        SceneManager.LoadScene(1);
        Debug.Log("Start");
    }

    public void CreditGame()
    {
        sound.Play();
        isRotating = true;
    }

    public void QuitGame()
    {
        sound.Play();
        Application.Quit();
    }

    public void BackGame()
    {
        sound.Play();
        isRotatingBack = true;
        rotationSpeed *= -1f;
    }

    IEnumerator ToggleVisibilityCo(GameObject someObj)
    {
        if (someObj == null) yield break;

        while (true)
        {
            someObj.SetActive(!someObj.active);

            yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));
        }

    }
}
