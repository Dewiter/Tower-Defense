using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour {

	public Image img;
	public AnimationCurve curve;

	void Start ()
	{
		StartCoroutine(FadeIn());
	}

	public void FadeTo(string scene)
	{
		StartCoroutine(FadeOut(scene));
	}

	IEnumerator FadeIn ()
	{
		float t = 1f;
		while (t > 0f)
		{
			t 			-= Time.deltaTime * .5f;
			float alpha	= curve.Evaluate(t);
			img.color 	= new Color (0f, 0f, 0f, alpha);
			yield return 0;
		}
	}

	IEnumerator FadeOut (string scene)
	{
		float t = 0f;
		while (t < 1f)
		{
			t 			+= Time.deltaTime * .5f;
			float alpha	= curve.Evaluate(t);
			img.color 	= new Color (0f, 0f, 0f, alpha);
			yield return 0;
		}
		SceneManager.LoadScene(scene);
	}
}
