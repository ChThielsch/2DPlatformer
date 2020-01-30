using UnityEngine;

public class GemController : MonoBehaviour
{
    /// <summary>
    /// Reference to the ScoreController script on the UI text
    /// </summary>
    private ScoreController _scoreController;

    void Awake()
    {
        _scoreController = GameObject.Find("Text_Gems").GetComponent(typeof(ScoreController)) as ScoreController;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            // Check list because OnTriggerEnter sometimes triggers twice before object is disabled
            if (!_scoreController.collectedGems.Contains(this.gameObject))
            {
                _scoreController.collectedGems.Add(this.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

}
