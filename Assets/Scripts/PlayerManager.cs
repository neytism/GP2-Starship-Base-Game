using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    //singleton end
    [SerializeField] private List<GameObject> _characters;
    [SerializeField] private List<String> _names;
    [SerializeField] private List<String> _description;
    [SerializeField] private SpriteRenderer _sr;
    private TextMeshProUGUI _characterName;
    private TextMeshProUGUI _characterDescription;

    public int selectedCharacter = 1;
    
    private GameObject _weaponPrefab1;
    private GameObject _weaponPrefab2;
    private GameObject _weaponPrefab3;

    [SerializeField] private AbilityManager _ability1;
    [SerializeField] private AbilityManager _ability2;
    [SerializeField] private AbilityManager _ability3;
    

    public GameObject SelectWeaponType(int index)
    {
        _weaponPrefab1 = GameObject.Find("RapidGun");
        _weaponPrefab2 = GameObject.Find("SpreadGun");
        _weaponPrefab3 = GameObject.Find("ExplodeGun");
        
        switch (index)
        {
            case 0:
                return _weaponPrefab1;
            case 1:
                return _weaponPrefab2;
            case 2:
                return _weaponPrefab3;
        }

        return _weaponPrefab1;
    }
    
    public AbilityManager SelectAbilityType(int index)
    {
        
        switch (index)
        {
            case 0:
                return _ability1;
            case 1:
                return _ability2;
            case 2:
                return _ability3;
        }

        return _ability1;
    }

    public Color SelectCharacterSprite(int index)
    {
        return _characters[index].GetComponent<SpriteRenderer>().color;
    }

    public void NextOption()
    {
        selectedCharacter += 1;
        if (selectedCharacter == _characters.Count)
        {
            selectedCharacter = 0;
        }

        _sr.color = _characters[selectedCharacter].GetComponent<SpriteRenderer>().color;
        _characterName = GameObject.Find("Name").GetComponent<TextMeshProUGUI>();
        _characterDescription = GameObject.Find("Description").GetComponent<TextMeshProUGUI>();
        _characterName.text = _names[selectedCharacter];
        _characterDescription.text = _description[selectedCharacter];
        Debug.Log($"Selected: {selectedCharacter}");
    }
    
    public void BackOption()
    {
        selectedCharacter -= 1;
        if (selectedCharacter < 0)
        {
            selectedCharacter = _characters.Count-1;
        }

        _sr.color = _characters[selectedCharacter].GetComponent<SpriteRenderer>().color;
        _characterName = GameObject.Find("Name").GetComponent<TextMeshProUGUI>();
        _characterDescription = GameObject.Find("Description").GetComponent<TextMeshProUGUI>();
        _characterName.text = _names[selectedCharacter];
        _characterDescription.text = _description[selectedCharacter];
        Debug.Log($"Selected: {selectedCharacter}");
    }

    public void PlayGame()
    {
        PrefabUtility.SaveAsPrefabAsset(gameObject, "Assets/Prefabs/PlayerManager.prefab");
        SceneManager.LoadScene("GameScene");
    }
    
    public void QuitGame()
    {
        //UIClickSound.Play();
        Application.Quit();
    }
}
