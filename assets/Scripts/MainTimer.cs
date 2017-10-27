using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTimer : MonoBehaviour
{
	
	enum CountStatus
	{

		None,
		Ready,
		Eight,
		Twelve,
		End,
	}

	[SerializeField] private CountStatus m_status;
	[SerializeField] private float m_readyTime;
	private float m_timeCount = 0f;
	private const float eight = 8f;
	private const float twelve = 12f;

	// Use this for initialization
	void Start ()
	{
		
	}

	void Initialize ()
	{

		m_status = CountStatus.None;
		m_timeCount = 0f;


	}

	void ChangeCountStatus (CountStatus status)
	{

		switch (status) {
			case CountStatus.None:
				Initialize();
				break;
			case CountStatus.Ready:
				SeManager.Instance.Play("Count");
				break;
			case CountStatus.Eight:
				break;
			case CountStatus.Twelve:
				SeManager.Instance.Play("eight");
				break;
			case CountStatus.End:
				SeManager.Instance.Play("juni");
				break;
		}

		m_status = status;

	}

	// Update is called once per frame
	void Update ()
	{

		if (m_status == CountStatus.None) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				ChangeCountStatus(CountStatus.Ready);
			}
		}

		switch (m_status) {
			case CountStatus.Ready:
				if (m_timeCount >= m_readyTime) {
					ChangeCountStatus(CountStatus.Eight);
				}
				break;
			case CountStatus.Eight:
				if (m_timeCount >= eight + m_readyTime) {
					ChangeCountStatus(CountStatus.Twelve);
				}
				break;
			case CountStatus.Twelve:
				if (m_timeCount >= twelve + m_readyTime) {
					ChangeCountStatus(CountStatus.End);
				}
				break;
			case CountStatus.End:
				ChangeCountStatus(CountStatus.None);
				break;
		}

		if (m_status != CountStatus.None) {
			m_timeCount += Time.deltaTime;
		}

		if (Input.GetKeyDown(KeyCode.Return)) {
			ChangeCountStatus(CountStatus.None);
		}

	}
				
}