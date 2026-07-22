using UnityEngine;

[CreateAssetMenu(fileName = "MaterialVariantSettings", menuName = "Scriptable Objects/MaterialVariantSettings")]
public class MaterialVariantSettings : ScriptableObject
{
    [Header("Base")]
    [ColorUsage(true, true)]
    [Tooltip("Main color of the crystal")]
    [SerializeField] private Color baseColor = Color.white;

    [Range(0f, 1f)]
    [Tooltip("Overall opacity of the crystal surface")]
    [SerializeField] private float alpha = 1.0f;

    [Header("Emission")]
    [ColorUsage(true, true)]
    [Tooltip("Emissive glow color")]
    [SerializeField] private Color emissionColor = Color.black;

    [Header("Gradient")]
    [ColorUsage(true, true)]
    [Tooltip("Bottom to top gradient color")]
    [SerializeField] private Color gradientColor = Color.white;

    [Tooltip("Start and end position of the gradient")]
    [SerializeField] private Vector2 gradientRange = new Vector2(0f, 1f);

    [Tooltip("How soft the edge of the gradient is")]
    [SerializeField] private float gradientSoftness = 1.0f;

    [Header("Edges")]
    [ColorUsage(true, true)]
    [Tooltip("Color of the edge highlights")]
    [SerializeField] private Color edgeColor = Color.white;

    [Tooltip("How soft the edges of edge highlights are")]
    [SerializeField] private float edgeSoftness = 1.0f;

    [Header("Vornoi Var")]
    [ColorUsage(true, true)]
    [Tooltip("Color of the Vornoi color variants")]
    [SerializeField] private Color vornoiVarColor = Color.white;

    [Tooltip("How disorganized the cell shapes are packed")]
    [SerializeField] private float vornoiVarAngleOffset = 10.0f;

    [Tooltip("How many cells there are")]
    [SerializeField] private float vornoiVarCellDensity = 5.0f;

    [Tooltip("How soft the edges of each cell are")]
    [SerializeField] private float vornoiSoftness = 2.0f;

    [Tooltip("Remap black and white level values")]
    [SerializeField] private Vector2 vornoiLevelRemap = new Vector2(0f, 1f);

    [Header("Caustic")]
    [Tooltip("Height amplitude for parallax caustic mapping")]
    [SerializeField] private float amplitude = 1.0f;

    [Tooltip("Number of parallax steps")]
    [SerializeField] private float steps = 1.0f;

    [Tooltip("UV tiling of the caustic texture")]
    [SerializeField] private Vector2 tiling = Vector2.one;

    [Tooltip("UV offset of the caustic texture")]
    [SerializeField] private Vector2 offset = Vector2.zero;

    /// <summary>Main color of the crystal.</summary>
    public Color BaseColor => baseColor;

    /// <summary>Overall opacity of the crystal surface.</summary>
    public float Alpha => alpha;

    /// <summary>Emissive glow color.</summary>
    public Color EmissionColor => emissionColor;

    /// <summary>Bottom to top gradient color.</summary>
    public Color GradientColor => gradientColor;

    /// <summary>Start and end position of the gradient.</summary>
    public Vector2 GradientRange => gradientRange;

    /// <summary>How soft the edge of the gradient is.</summary>
    public float GradientSoftness => gradientSoftness;

    /// <summary>Color of the edge highlights.</summary>
    public Color EdgeColor => edgeColor;

    /// <summary>How soft the edges of edge highlights are.</summary>
    public float EdgeSoftness => edgeSoftness;

    /// <summary>Color of the Vornoi color variants.</summary>
    public Color VornoiVarColor => vornoiVarColor;

    /// <summary>How disorganized the cell shapes are packed.</summary>
    public float VornoiVarAngleOffset => vornoiVarAngleOffset;

    /// <summary>How many cells there are.</summary>
    public float VornoiVarCellDensity => vornoiVarCellDensity;

    /// <summary>How soft the edges of each cell are.</summary>
    public float VornoiSoftness => vornoiSoftness;

    /// <summary>Remap black and white level values.</summary>
    public Vector2 VornoiLevelRemap => vornoiLevelRemap;

    /// <summary>Height amplitude for parallax caustic mapping.</summary>
    public float Amplitude => amplitude;

    /// <summary>Number of parallax steps.</summary>
    public float Steps => steps;

    /// <summary>UV tiling of the caustic texture.</summary>
    public Vector2 Tiling => tiling;

    /// <summary>UV offset of the caustic texture.</summary>
    public Vector2 Offset => offset;
}
