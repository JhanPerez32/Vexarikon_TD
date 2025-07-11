using NF.TD.BuildArea;
using NF.TD.PlayerCore;
using NF.TD.Upgrade;
using TMPro;
using UnityEngine;

namespace NF.TD.UICore
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        [Header("UI References")]
        [Header("HUD")]
        [SerializeField] private TextMeshProUGUI moneyText;
        [SerializeField] private TextMeshProUGUI waveCountdownText;
        [SerializeField] private TextMeshProUGUI waveNumber;
        [SerializeField] private TextMeshProUGUI liveText;

        [Header("Game Over Screen")]
        [SerializeField] private GameObject gameOverScreen;
        [SerializeField] private TextMeshProUGUI waveSurvived;

        [Header("Pause Screen")]
        [SerializeField] private GameObject pauseScreen;

        [Header("Upgrade Shop")]
        [SerializeField] private UpgradeShopUI upgradeShopScript;
        [SerializeField] private GameObject upgradeShopUI;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        public void UpdateMoneyUI(int amount)
        {
            if (moneyText != null)
            {
                moneyText.text = amount.ToString();
            }
        }

        public void UpdateWaveCountdown(float countdown)
        {
            int seconds = Mathf.FloorToInt(countdown);
            int milliseconds = Mathf.FloorToInt((countdown - seconds) * 100);

            waveCountdownText.text = string.Format("{0:00}:{1:00}", seconds, milliseconds);
        }

        public void UpdateLivesUI(int amount)
        {
            if (liveText != null)
            {
                liveText.text = $"Lives: {amount}";
            }
        }

        public void UpdateWaveNumberUI(int wave)
        {
            if (waveNumber != null)
            {
                waveNumber.text = $"Wave: {wave}";
            }
        }

        public void ShowGameOverUI()
        {
            if (gameOverScreen != null)
            {
                gameOverScreen.SetActive(true);
                waveSurvived.text = PlayerStats.Rounds.ToString();
            }

        }

        public void HideGameOverUI()
        {
            if (gameOverScreen != null)
            {
                gameOverScreen.SetActive(false);
            }
        }

        public void ShowPauseScreen()
        {
            if (pauseScreen != null)
            {
                pauseScreen.SetActive(true);
            }
        }

        public void HidePauseScreen()
        {
            if (pauseScreen != null)
            {
                pauseScreen.SetActive(false);
            }
        }

        public void ShowUpgradeShop(Node node)
        {
            upgradeShopUI.gameObject.SetActive(true);
            upgradeShopScript.SetTarget(node);
        }

        public void HideUpgradeShop()
        {
            upgradeShopUI.gameObject.SetActive(false);
        }
    }
}