using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

/// <summary>
/// Interfaz de usuario del combate
/// </summary>
public class CombatUI : MonoBehaviour
{
    [SerializeField] private Canvas combatCanvas;
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI enemyNameText;
    [SerializeField] private Slider playerHealthBar;
    [SerializeField] private Slider enemyHealthBar;
    [SerializeField] private TextMeshProUGUI combatLogText;
    [SerializeField] private Button attackButton;
    [SerializeField] private Button skillButton;
    [SerializeField] private Button healButton;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject defeatPanel;
    
    private Queue<string> combatLog = new Queue<string>();
    private const int maxLogLines = 5;

    private void Start()
    {
        attackButton.onClick.AddListener(() => GetComponent<CombatSystem>().PlayerAttack());
        skillButton.onClick.AddListener(() => GetComponent<CombatSystem>().PlayerSkill("StyleBomb"));
        healButton.onClick.AddListener(() => GetComponent<CombatSystem>().PlayerSkill("Heal"));
    }

    public void ShowCombat(CharacterStats player, CharacterStats enemy)
    {
        combatCanvas.enabled = true;
        playerNameText.text = player.name;
        enemyNameText.text = enemy.name;
    }

    public void UpdateStats(CharacterStats player, CharacterStats enemy)
    {
        playerHealthBar.maxValue = player.maxHp;
        playerHealthBar.value = player.hp;
        
        enemyHealthBar.maxValue = enemy.maxHp;
        enemyHealthBar.value = enemy.hp;
    }

    public void ShowDamageText(int damage, Vector3 position, bool isCritical)
    {
        string text = isCritical ? $"¡{damage}! ✨" : damage.ToString();
        Color color = isCritical ? Color.yellow : Color.white;
        
        // Aquí irían efectos de texto flotante
        Debug.Log($"Daño: {text} en {position}");
    }

    public void LogAction(string action)
    {
        combatLog.Enqueue(action);
        if (combatLog.Count > maxLogLines)
            combatLog.Dequeue();

        UpdateCombatLog();
    }

    private void UpdateCombatLog()
    {
        combatLogText.text = string.Join("\n", combatLog);
    }

    public void ShowVictory()
    {
        victoryPanel.SetActive(true);
        LogAction("¡GANASTE! 🎉");
    }

    public void ShowDefeat()
    {
        defeatPanel.SetActive(true);
        LogAction("GAME OVER");
    }

    public void HideCombat()
    {
        combatCanvas.enabled = false;
        victoryPanel.SetActive(false);
        defeatPanel.SetActive(false);
    }
}