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
    private  Color[] m_colors = { new Color(0,1,0,1), new Color(1,0,0,1), new Color(1,1,1,1), new Color(0,1,1,1) }; //green,red,white,blue
    private float m_scaleToMainBody = 0.0016f;

    void Start()
    {
        m_outlineRenderer = CreateOutline(m_outlineMaterial, m_outlineScaleFactor, m_oultineColor);
        m_outlineRenderer.enabled = true;
    }

    Renderer CreateOutline(Material outMaterial, float scaleFactor, Color color)
    {
        GameObject outlineObject = Instantiate(this.gameObject, transform.position,transform.rotation, transform);
        outlineObject.transform.localScale =  new Vector3(
            outlineObject.transform.localScale.x * m_scaleToMainBody,
            outlineObject.transform.localScale.y * m_scaleToMainBody,
            outlineObject.transform.localScale.z * m_scaleToMainBody);
        Renderer rend = outlineObject.GetComponent<Renderer>();
        int colorChoose = Random.Range(0,4);
        rend.material = outMaterial;
        rend.material.SetColor("_OutlineColor", m_colors[colorChoose]);
        rend.material.SetColor("_Color", m_colors[colorChoose]);
        rend.material.SetFloat("_Scale", scaleFactor);
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        outlineObject.GetComponent<OutlineShader>().enabled = false;
        outlineObject.GetComponent<RotateEnemy>().enabled = false;

        return rend;
    }
}
