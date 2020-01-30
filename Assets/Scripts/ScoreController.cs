using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> collectedGems;

    /// <summary>
    /// Reference to the text component 
    /// </summary>
    private TMP_Text _textComponent;

    private int _prevousScore = -1;
    private int _maxScore = 0;

    void Awake()
    {
        _textComponent = gameObject.GetComponent<TMP_Text>();
        _maxScore = GameObject.FindGameObjectsWithTag("Pickup").Length;
    }

    void Update()
    {
        if (collectedGems.Count > _prevousScore)
        {
            _textComponent.text = collectedGems.Count + "/" + _maxScore;
            _prevousScore = collectedGems.Count;
        }
    }
}
