using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField] private Button m_Restart;
	void Start()
	{
		Button btn = m_Restart.GetComponent<Button>();
		btn.onClick.AddListener(RestartGame);


	}

	private void RestartGame()
	{
		Application.LoadLevel(Application.loadedLevel);
	}


}
