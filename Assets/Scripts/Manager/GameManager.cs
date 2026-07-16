using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Gestor principal del juego
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private Character playerCharacter;
    [SerializeField] private CombatSystem combatSystem;
    [SerializeField] private EnemySpawner enemySpawner;
    
    private int score = 0;
    private int gyaruLevel = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EncounterEnemy()
    {
        Character enemy = enemySpawner.SpawnRandomEnemy(playerCharacter.Stats.level);
        combatSystem.StartCombat(playerCharacter, enemy);
    }

    public void AddScore(int points)
    {
        score += points;
        
        // Aumentar nivel de Gyaru cada 100 puntos
        if (score % 100 == 0)
        {
            gyaruLevel++;
            playerCharacter.Stats.gyaruStyle += 10;
        }
    }

    public void LevelUp()
    {
        playerCharacter.Stats.level++;
        playerCharacter.Stats.maxHp += 10;
        playerCharacter.Stats.atk += 2;
        playerCharacter.Stats.def += 1;
        playerCharacter.Stats.spd += 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int GetScore() => score;
    public int GetGyaruLevel() => gyaruLevel;
}