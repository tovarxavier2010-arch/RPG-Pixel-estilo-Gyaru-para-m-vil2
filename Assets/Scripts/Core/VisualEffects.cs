using UnityEngine;

/// <summary>
/// Sistema de efectos visuales (daño flotante, críticos, etc)
/// </summary>
public class VisualEffects : MonoBehaviour
{
    public static void FloatingDamage(Vector3 position, int damage, bool isCritical = false)
    {
        Debug.Log($"Daño flotante: {damage} en {position} | Crítico: {isCritical}");
    }

    public static void CriticalHit(Vector3 position)
    {
        Debug.Log($"¡GOLPE CRÍTICO! en {position} ✨");
    }

    public static void Heal(Vector3 position, int amount)
    {
        Debug.Log($"Curación: +{amount} en {position} 💅");
    }

    public static void SkillEffect(string skillName, Vector3 position)
    {
        Debug.Log($"Efecto de habilidad: {skillName} en {position}");
    }
}