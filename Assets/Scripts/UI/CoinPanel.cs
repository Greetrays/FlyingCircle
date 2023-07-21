using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]

public class CoinPanel : MonoBehaviour
{
    [SerializeField] private PlayerCoin _playerCoin;
    
    private TMP_Text _coinText;

    private void Start() => _coinText = GetComponent<TMP_Text>();

    private void OnEnable()
    {
        _playerCoin.Chached += OnChanged;
    }

    private void OnDisable()
    {
        _playerCoin.Chached -= OnChanged;
    }

    private void OnChanged(int coin)
    {
        _coinText.text = coin.ToString();
    }
}
