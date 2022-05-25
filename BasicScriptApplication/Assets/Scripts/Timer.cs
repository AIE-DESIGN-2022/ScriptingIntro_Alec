using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timerText;
    public float timer;

    void Start()
    {
        timerText = GetComponent<Text>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = timer.ToString("F1");
    }
}
