using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypewriterUI : MonoBehaviour
{
	 TMP_Text _tmpProText;
	 string writer;

	[SerializeField]  float delayBeforeStart = 0f;
	[SerializeField]  float timeBtwChars = 0.1f;
	[SerializeField]  string leadingChar = "";
	[SerializeField]  bool leadingCharBeforeDelay = false;
	
	[SerializeField]  float endwait;
	[SerializeField]  GameObject textbox;
	public static bool active;
	public GameObject actualtext;
	public bool running;


	// Use this for initialization
	void Start()
	{
		running = false;
		_tmpProText = actualtext.GetComponent<TMP_Text>()!;

		if (_tmpProText != null)
		{
			writer = _tmpProText.text;
			_tmpProText.text = "";
		}
	}

    private void Update()
    {
        if(active == true)
		{
			if(running == false)
            {
				StartCoroutine("TypeWriterTMP");
				return;
            }
		}
		else
			_tmpProText.text = writer;
	}

	 IEnumerator TypeWriterTMP()
	{
		running = true;
		textbox.gameObject.SetActive(true);
		_tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";

		yield return new WaitForSeconds(delayBeforeStart);

		foreach (char c in writer)
		{
			if (_tmpProText.text.Length > 0)
			{
				_tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
			}
			_tmpProText.text += c;
			_tmpProText.text += leadingChar;
			yield return new WaitForSeconds(timeBtwChars);
		}

		if (leadingChar != "")
		{
			_tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
		}
		yield return new WaitForSeconds(endwait);
		running = false;
		active = false;
	 }
}