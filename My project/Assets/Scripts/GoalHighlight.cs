using UnityEngine;

public class GoalHighlight : MonoBehaviour
{
    public Cube.PackageColor goalColor;

    private Renderer rend;

    private Color normalColor;
    private Material mat;

    void Start()
    {
        rend = GetComponent<Renderer>();

       // mat = rend.material;

        normalColor = mat.color;
    }

    public void SetHighlight(bool active)
    {
        if (active)
        {
            mat.EnableKeyword("_EMISSION");

            Color emission = normalColor * 3f;

            mat.SetColor("_EmissionColor", emission);
        }
        else
        {
            mat.SetColor("_EmissionColor", Color.black);
        }
    }
}