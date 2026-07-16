using UnityEngine;

/// <summary>
/// Generador de enemigos
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Character enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    
    private string[] enemyNames = 
    { 
        "Troll Fashion", 
        "Básica", 
        "Normie", 
        "Hater", 
        "Competidora",
        "Fashionista Rival"
    };

    public Character SpawnRandomEnemy(int playerLevel)
    {
        Character enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        
        string enemyName = enemyNames[Random.Range(0, enemyNames.Length)];
        int enemyLevel = Mathf.Max(1, playerLevel + Random.Range(-1, 2));
        
        CharacterStats stats = new CharacterStats(enemyName, enemyLevel);
        
        // Asignar stats al enemigo (deberías tener una forma de setear esto)
        // enemy.Stats = stats;
        
        return enemy;
    }
}