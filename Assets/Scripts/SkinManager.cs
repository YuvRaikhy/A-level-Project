using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SkinManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> characters = new List<Sprite>();
    private int selectedCharacter = 0;
    public GameObject playercharacter;

    public void NextCharacter() // Functionality for the next button
    {
        selectedCharacter = selectedCharacter + 1;
        if (selectedCharacter == characters.Count) // If the list reaches its end
        {
            selectedCharacter = 0; // Return back to the first character
        }
        sr.sprite = characters[selectedCharacter];
    }

    public void BackCharacter() // Functionality for the back button works similar to NextCharacter() method
    {
        selectedCharacter = selectedCharacter - 1;
        if (selectedCharacter < 0)
        {
            selectedCharacter = characters.Count - 1;
        }
        sr.sprite = characters[selectedCharacter];
    }

    public void Choose()
    {
        PrefabUtility.SaveAsPrefabAsset(playercharacter, "Assets/Sprites/selectedcharacter.prefab"); // Updates prefab, selects the selectedCharacter as the new characater
    }
}
