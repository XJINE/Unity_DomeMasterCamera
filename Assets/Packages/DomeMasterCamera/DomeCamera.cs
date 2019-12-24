using UnityEngine;

public class DomeCamera : MonoBehaviour
{
    #region Field

    public Vector3Int resolution   = new Vector3Int(1024, 1024, 0); // Z in 0, 16, 24.
    public FilterMode filterMode   = FilterMode.Bilinear;
    public int        antiAliasing = 2;

    [SerializeField] protected Camera cameraTop;
    [SerializeField] protected Camera cameraLeft;
    [SerializeField] protected Camera cameraRight;
    [SerializeField] protected Camera cameraBottom;

    [SerializeField] protected Material materialTop;
    [SerializeField] protected Material materialLeft;
    [SerializeField] protected Material materialRight;
    [SerializeField] protected Material materialBottom;

    protected RenderTexture renderTextureTop;
    protected RenderTexture renderTextureLeft;
    protected RenderTexture renderTextureRight;
    protected RenderTexture renderTextureBottom;

    #endregion Field

    #region Method

    protected virtual void Awake()
    {
        UpdateTextureSettings();
    }

    [ContextMenu("UpdateTextureSettings")]
    public void UpdateTextureSettings()
    {
        if (this.renderTextureTop != null)
        {
            this.renderTextureTop.Release();
            this.renderTextureLeft.Release();
            this.renderTextureRight.Release();
            this.renderTextureBottom.Release();

            DestroyImmediate(this.renderTextureTop);
            DestroyImmediate(this.renderTextureLeft);
            DestroyImmediate(this.renderTextureRight);
            DestroyImmediate(this.renderTextureBottom);
        }

        this.renderTextureTop = new RenderTexture(this.resolution.x, this.resolution.y, this.resolution.z)
        { 
            filterMode       = this.filterMode,
            antiAliasing     = this.antiAliasing,
            hideFlags        = HideFlags.HideAndDontSave,
            wrapMode         = TextureWrapMode.Clamp,
            autoGenerateMips = false,
            anisoLevel       = 0,
        };

        this.renderTextureLeft   = new RenderTexture(this.renderTextureTop.descriptor);
        this.renderTextureRight  = new RenderTexture(this.renderTextureTop.descriptor);
        this.renderTextureBottom = new RenderTexture(this.renderTextureTop.descriptor);

        this.cameraTop.targetTexture    = this.renderTextureTop;
        this.cameraLeft.targetTexture   = this.renderTextureLeft;
        this.cameraRight.targetTexture  = this.renderTextureRight;
        this.cameraBottom.targetTexture = this.renderTextureBottom;

        this.materialTop.mainTexture    = this.renderTextureTop;
        this.materialLeft.mainTexture   = this.renderTextureLeft;
        this.materialRight.mainTexture  = this.renderTextureRight;
        this.materialBottom.mainTexture = this.renderTextureBottom;
    }

    #endregion Method
}