using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeLoading : MonoBehaviour
{
	[SerializeField] private Transform cube;

	public void StartFakeLoading()
	{
		cube.gameObject.SetActive(true);
		StartCoroutine(MoveCube_Loading());
	}

	IEnumerator MoveCube_Loading()
	{
		yield return null;
		float startX = cube.position.x;
		float endX = startX * -1;
		while (cube.position.x <= endX)
		{
			Vector3 cubePosition = cube.position;
			cubePosition.x += 0.4f;
			cube.position = cubePosition;
			yield return new WaitForSeconds(0.05f);
		}
		yield return null; // Waiting for next frame
		GetComponent<StartSceneController>().ChangeToGameScene();
	}
	
}
