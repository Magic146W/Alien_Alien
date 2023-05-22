using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchivementPanel: MonoBehaviour
{
    [SerializeField] private Button m_backButton;
    [SerializeField] private GameObject m_mainMenuUI;
    [SerializeField] private GameObject m_enemyContainer;
    [SerializeField] private DataToSerialize m_dataToSerialize;
    [SerializeField] private TMP_Text m_kills;
    [SerializeField] private TMP_Text m_points;
    [SerializeField] private TMP_Text m_level;
    [SerializeField] private GameObject m_emptyObject;
    [SerializeField] private List<Sprite> m_enemyModels = new List<Sprite>();

    void Start()
    {
        Button btnBack = m_backButton.GetComponent<Button>();
        btnBack.onClick.AddListener(ClickBack);
    }

    private void OnEnable()
    {
        m_kills.text = m_dataToSerialize.Kills.ToString();
        m_points.text = m_dataToSerialize.Points.ToString();
        m_kills.text = m_dataToSerialize.Kills.ToString();
        m_level.text = m_dataToSerialize.Level.ToString();

        ClearChildren();
        int enemyNumber = (int)(m_dataToSerialize.Enemy);
        if (enemyNumber > 7)
            enemyNumber = 7;

        for (int i = 0; i <= enemyNumber; i++)
        {
            var emptyChild = Instantiate(m_emptyObject, m_enemyContainer.transform);
            var rectTransform = emptyChild.GetComponent<RectTransform>();
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 200);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 200);
            Image newImage = emptyChild.AddComponent<Image>();
            newImage.sprite = m_enemyModels[i];
        }
    }

    private void ClearChildren()
    {
        Transform parentTransform = m_enemyContainer.transform;

        for (int i = parentTransform.childCount - 1; i > -1; i--)
        {
            GameObject child = parentTransform.GetChild(i).gameObject;
            Destroy(child);
        }
    }

    private void ClickBack()
    {
        m_mainMenuUI.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
