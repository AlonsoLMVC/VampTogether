using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class LevelSelection : MonoBehaviour
{
    public GameObject buttonPrefab; // Assign a Button prefab in the Inspector
    public Transform buttonContainer; // Assign a UI Panel in the Inspector

    void Start()
    {
        GenerateLevelButtons();
    }

    void GenerateLevelButtons()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1); // Track unlocked levels

        for (int i = 0; i < sceneCount; i++)
        {
            string sceneName = GetSceneName(i);

            GameObject newButton = Instantiate(buttonPrefab, buttonContainer);
            newButton.name = "Button_" + sceneName;
            newButton.GetComponentInChildren<Text>().text = sceneName; // Set button text

            Button btn = newButton.GetComponent<Button>();
            int levelIndex = i; // Needed to avoid closure issues in delegate
            btn.onClick.AddListener(() => LoadLevel(levelIndex));

            // Lock levels based on progress
            /*
            if (levelIndex + 1 > unlockedLevel)
                btn.interactable = false;
            */
        }
    }

    string GetSceneName(int buildIndex)
    {
        string path = SceneUtility.GetScenePathByBuildIndex(buildIndex);
        return Path.GetFileNameWithoutExtension(path);
    }

    void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
