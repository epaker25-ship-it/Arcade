using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public int coins = 0;
    public int coinsNeeded = 5;

    public TextMeshProUGUI coinText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddCoin(int amount)
    {
        coins += amount;
        UpdateUI();
    }

    public bool CanUseSpecial()
    {
        return coins >= coinsNeeded;
    }

    public void SpendCoins()
    {
        coins -= coinsNeeded;
        UpdateUI();
    }

    void UpdateUI()
    {
        coinText.text = coins.ToString();
    }
}
