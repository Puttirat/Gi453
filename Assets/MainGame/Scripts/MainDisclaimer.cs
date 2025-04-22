using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDisclaimer : MonoBehaviour
{
    public GameObject Disclaimer;

    public void Close()
    {
        Disclaimer.SetActive(false);
    }
}
