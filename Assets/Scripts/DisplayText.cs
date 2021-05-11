using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    /// <value>Text of self</value>
    public Text s;

    /// <summary>
    /// Displays text and fades it out
    /// </summary>
    /// <para name='txt'>Text to display</para>
    public void Display(string txt, int fadeDelay=1)
    {
        if (!string.IsNullOrEmpty(s.text))
			{
				StopCoroutine(FadeOut(fadeDelay));
			}
			s.text = txt;
			s.color = Color.white;
			StartCoroutine(FadeOut(fadeDelay));
    }

    // FadeOut enumerator
    private IEnumerator FadeOut(int delay)
	{
		yield return new WaitForSeconds(delay);
		float cTime = 0f;
		while (cTime < 0.5f)
		{
			float alpha = Mathf.Lerp(1f, 0f, cTime / 0.5f);
			s.color = new Color(s.color.r, s.color.g, s.color.b, alpha);
			cTime += Time.deltaTime;
			yield return null;
		}
		s.text = "";
		yield break;
	}
}
