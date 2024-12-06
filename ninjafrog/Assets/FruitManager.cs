using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FruitManager : MonoBehaviour
{
    public Text levelCleared;
    

    private void Update()
    {
        AllFruitsCollected();
    }

    public void AllFruitsCollected()
    {

        if (transform.childCount==0)
        {
            Debug.Log("No quedan frutas, Victoria");
            levelCleared.gameObject.SetActive(true);
            Invoke("ChangeScene", 1);
        }
    }

    void ChangeScene()
    {
        PlayerPrefs.SetFloat("checkPointPositionX", 0);
        PlayerPrefs.SetFloat("checkPointPositionY", 0);

        if (SceneManager.GetActiveScene().buildIndex==1)
        {
            PlayerPrefs.SetFloat("checkPointPositionX", 1);
            PlayerPrefs.SetFloat("checkPointPositionY", -0.5f);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}

