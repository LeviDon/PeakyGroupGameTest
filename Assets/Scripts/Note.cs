using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    private GameObject notePanel;
    private Button noteButton;

    void Start()
    {
        Transform[] allObjects = GameObject.FindObjectsOfType<Transform>(true);
        foreach (Transform t in allObjects)
        {
            if (t.name == "NotePanel")
            {
                notePanel = t.gameObject;
                break;
            }
        }

        if (notePanel != null)
        {
            noteButton = notePanel.GetComponentInChildren<Button>(true);
            noteButton.onClick.AddListener(CloseNote);
        }
        else
        {
            Debug.LogWarning("NotePanel не найден в сцене!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && notePanel != null)
        {
            notePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void CloseNote()
    {
        notePanel.SetActive(false);
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}
