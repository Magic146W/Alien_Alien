using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineShader : MonoBehaviour
{
    [SerializeField]
    private Material m_outlineMaterial;
    [SerializeField]
    private float m_outlineScaleFactor;
    [SerializeField]
    private Color m_oultineColor;
    private Renderer m_outlineRenderer;

    void Start()
    {
        m_outlineRenderer = CreateOutline(m_outlineMaterial, m_outlineScaleFactor, m_oultineColor);
        m_outlineRenderer.enabled = true;
    }

    Renderer CreateOutline(Material outMaterial, float scaleFactor, Color color)
    {
        GameObject outlineObject = Instantiate(this.gameObject, transform.position,transform.rotation, transform);
        outlineObject.transform.localScale =  new Vector3(
            outlineObject.transform.localScale.x * 0.0016f,
            outlineObject.transform.localScale.y * 0.0016f,
            outlineObject.transform.localScale.z * 0.0016f);
        Renderer rend = outlineObject.GetComponent<Renderer>();
        
        rend.material = outMaterial;
        rend.material.SetColor("_OutlineColor", color);
        rend.material.SetFloat("_Scale", scaleFactor);
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        outlineObject.GetComponent<OutlineShader>().enabled = false;
        outlineObject.GetComponent<RotateEnemy>().enabled = false;

        return rend;
    }
}
