using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Maze.SceneController
{
	public class SceneTransition : MonoBehaviour
	{
		public Image FadeImage;
		public float FadeSpeed;
		public Button TransitionButton;

		private bool _fadingIn = true;
		private bool _fadingOut = false;
		private AsyncOperation _asyncLoad;
		
		// Start is called before the first frame update
		private void Start()
		{
			TransitionButton.onClick.AddListener(StartFadeInOut);
		}
		public void StartFadeInOut()
		{
			StartCoroutine(FadeInOut());
		}

		private IEnumerator FadeInOut()
		{
			while (true)
			{
				if (_fadingIn)
				{
					FadeImage.color = Color.Lerp(FadeImage.color, Color.clear, FadeSpeed * Time.deltaTime);
					if (FadeImage.color.a <= 0.05f)
					{
						FadeImage.color = Color.black;
						_fadingIn = false;
						_fadingOut = true;
					}
				}
				if (_fadingOut)
				{
					FadeImage.color = Color.Lerp(FadeImage.color, Color.black, FadeSpeed * Time.deltaTime);
					if (!(FadeImage.color.a >= 0.95f)) continue;
					FadeImage.color = Color.clear;
					_fadingOut = false;

					_asyncLoad = SceneManager.LoadSceneAsync("MainScene");
					_asyncLoad.allowSceneActivation = false;
					while (_asyncLoad.progress < 0.9f)
					{
						yield return null;
					}
					_asyncLoad.allowSceneActivation = true;
				}
			}
		}
		// public void TransitionToMainScene()
		// {
		// 	_fadingIn = false;
		// 	_fadingOut = true;
		//
		// 	_asyncLoad = SceneManager.LoadSceneAsync("MainScene");
		// 	_asyncLoad.allowSceneActivation = false;
		// 	while (_asyncLoad.progress < 0.9f)
		// 	{
		// 		WaitForEndOfFrame wait = new WaitForEndOfFrame();
		// 		StartCoroutine(wait);
		// 	}
		// 	_asyncLoad.allowSceneActivation = true;
		// }
	}
}
