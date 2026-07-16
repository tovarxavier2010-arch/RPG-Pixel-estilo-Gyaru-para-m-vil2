using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Sistema de combate por turnos
/// </summary>
public class CombatSystem : MonoBehaviour
{
    [SerializeField] private Character playerCharacter;
    [SerializeField] private Character enemyCharacter;
    [SerializeField] private CombatUI combatUI;
    
    private bool isPlayerTurn = true;
    private bool combatActive = false;

    public void StartCombat(Character player, Character enemy)
    {
        playerCharacter = player;
        enemyCharacter = enemy;
        combatActive = true;
        isPlayerTurn = true;
        
        combatUI.ShowCombat(playerCharacter.Stats, enemyCharacter.Stats);
        combatUI.UpdateStats(playerCharacter.Stats, enemyCharacter.Stats);
    }

    public void PlayerAttack()
    {
        if (!isPlayerTurn || !combatActive) return;

        int damage = playerCharacter.GetAttackDamage();
        enemyCharacter.TakeDamage(damage);
        
        combatUI.ShowDamageText(damage, enemyCharacter.transform.position, false);
        combatUI.LogAction($"{playerCharacter.Stats.name} ataca por {damage} daño!");

        if (!enemyCharacter.IsAlive)
        {
            EndCombat(true);
            return;
        }

        isPlayerTurn = false;
        Invoke(nameof(EnemyTurn), 1f);
    }

    public void PlayerSkill(string skillName)
    {
        if (!isPlayerTurn || !combatActive) return;

        switch (skillName)
        {
            case "StyleBomb":
                StyleBombSkill();
                break;
            case "Heal":
                HealSkill();
                break;
        }

        isPlayerTurn = false;
        Invoke(nameof(EnemyTurn), 1.5f);
    }

    private void StyleBombSkill()
    {
        int damage = playerCharacter.Stats.gyaruStyle;
        enemyCharacter.TakeDamage(damage);
        
        combatUI.ShowDamageText(damage, enemyCharacter.transform.position, true);
        combatUI.LogAction($"{playerCharacter.Stats.name} usa ¡STYLE BOMB! ✨ ({damage} daño)");
    }

    private void HealSkill()
    {
        int healAmount = 30;
        playerCharacter.Heal(healAmount);
        
        combatUI.LogAction($"{playerCharacter.Stats.name} se cura por {healAmount} HP! 💅");
    }

    private void EnemyTurn()
    {
        if (!combatActive) return;

        // IA simple: 70% ataque, 30% defensa
        if (Random.value > 0.3f)
        {
            int damage = enemyCharacter.GetAttackDamage();
            playerCharacter.TakeDamage(damage);
            
            combatUI.ShowDamageText(damage, playerCharacter.transform.position, false);
            combatUI.LogAction($"{enemyCharacter.Stats.name} ataca por {damage} daño!");

            if (!playerCharacter.IsAlive)
            {
                EndCombat(false);
                return;
            }
        }
        else
        {
            combatUI.LogAction($"{enemyCharacter.Stats.name} se defiende...");
        }

        combatUI.UpdateStats(playerCharacter.Stats, enemyCharacter.Stats);
        isPlayerTurn = true;
    }

    private void EndCombat(bool playerWon)
    {
        combatActive = false;
        
        if (playerWon)
        {
            combatUI.ShowVictory();
            combatUI.LogAction("¡VICTORIA! ¡Lo hiciste con estilo! ✨💅");
        }
        else
        {
            combatUI.ShowDefeat();
            combatUI.LogAction("¡DERROTA! Intenta de nuevo...");
        }
    }
}