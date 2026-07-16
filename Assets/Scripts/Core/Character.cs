using UnityEngine;

/// <summary>
/// Datos del personaje (stats y atributos)
/// </summary>
[System.Serializable]
public class CharacterStats
{
    public string name;
    public int level;
    public int hp;
    public int maxHp;
    public int atk;
    public int def;
    public int spd;
    public int gyaruStyle; // Stat especial de Gyaru 💅

    public CharacterStats(string charName, int lvl = 1)
    {
        name = charName;
        level = lvl;
        maxHp = 50 + (lvl * 10);
        hp = maxHp;
        atk = 10 + (lvl * 2);
        def = 5 + (lvl * 1);
        spd = 8 + lvl;
        gyaruStyle = 15 + (lvl * 3);
    }

    public void TakeDamage(int damage)
    {
        int reducedDamage = Mathf.Max(1, damage - def);
        hp -= reducedDamage;
        hp = Mathf.Max(0, hp);
    }

    public void Heal(int amount)
    {
        hp += amount;
        hp = Mathf.Min(hp, maxHp);
    }
}

/// <summary>
/// Componente base para personajes (jugador y enemigos)
/// </summary>
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterStats stats;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    public CharacterStats Stats => stats;
    public bool IsAlive => stats.hp > 0;

    private void Start()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        stats.TakeDamage(damage);
        
        // Efecto visual de daño
        StartCoroutine(DamageFlash());
    }

    public void Heal(int amount)
    {
        stats.Heal(amount);
    }

    private System.Collections.IEnumerator DamageFlash()
    {
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor;
    }

    public int GetAttackDamage()
    {
        // Daño = ATK + factor aleatorio + bonus de estilo Gyaru
        return stats.atk + Random.Range(0, 5) + (stats.gyaruStyle / 10);
    }
}