using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pausemenu;

    [SerializeField]
    PlayerController player;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pausemenu.SetActive(!pausemenu.activeInHierarchy);
        }
    }

    public void Resume()
    {
        pausemenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SaveData.Save(new SaveData(Vector2.zero, new List<int>()));
        Quit();
    }
}
