using UnityEngine;

[CreateAssetMenu(fileName = "SelectionFXParticleStartColorPresets", menuName = "Scriptable Objects/SelectionFXParticleStartColorPresets")]
public class SelectionFXParticleStartColorPresets : ScriptableObject
{
    [Header("Particle Start Colors Using Random Between Two Color")]
    [Tooltip("First color in range")]
    [SerializeField] private Color color1 = Color.white;

    [Tooltip("Second color in range")]
    [SerializeField] private Color color2 = Color.white;

    /// <summary>First color in the Random Between Two Colors range.</summary>
    public Color Color1 => color1;

    /// <summary>Second color in the Random Between Two Colors range.</summary>
    public Color Color2 => color2;
}
