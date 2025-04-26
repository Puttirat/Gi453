using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance;
    private float startTime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ให้ GameObject นี้อยู่ทุกฉาก
            Debug.Log(" GameTimer initialized!");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        startTime = Time.time;
        Debug.Log($" Timer started at {startTime} seconds");
    }

    public float GetElapsedTime()
    {
        return Time.time - startTime;
    }
}