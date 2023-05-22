using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class FinishPanelManager: MonoBehaviour
{
	[SerializeField] private Button m_Restart;
	[SerializeField] private Button m_Exit;
	[SerializeField] private TMP_Text m_Informarion;
	[SerializeField] private JSON_Manager m_JSON_Manager;
	[SerializeField] private DataToSerialize m_dataToSerialize;
	[SerializeField] private GameObject m_expBar;
	[SerializeField] private List<GameObject> m_closeUI = new List<GameObject>();

	void Start()
	{
		Button btnR = m_Restart.GetComponent<Button>();
		btnR.onClick.AddListener(RestartGame);
		Button btnE = m_Exit.GetComponent<Button>();
		btnE.onClick.AddListener(ExitGame);
		m_expBar.SetActive(false);
	}
    private void OnEnable()
    {
        foreach (var item in m_closeUI)
        {
			item.SetActive(false);
        }
    }

    private void RestartGame()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	private void ExitGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}

	public void InformationUpdate()
	{
		m_Informarion.text = "All Enemies killed: "+m_dataToSerialize.Kills+"\nAll points earned: "+m_dataToSerialize.Points+"\nGood luck next time!";
	}
}
