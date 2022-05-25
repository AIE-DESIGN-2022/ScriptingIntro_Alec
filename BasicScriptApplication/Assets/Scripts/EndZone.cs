using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
    public GameObject endZonePanel;

    void Start()
    {
        endZonePanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            endZonePanel.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
