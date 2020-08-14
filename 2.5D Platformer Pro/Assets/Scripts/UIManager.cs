using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinDisplayText, _livesDisplayText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //update coin display text
    public void UpdateCoinDisplay(int coins)
    {
        _coinDisplayText.text = "Coins: " + coins;
    }

    public void UpdateLivesDisplay(int lives)
    {
        _livesDisplayText.text = "Lives: " + lives;
    }
}
