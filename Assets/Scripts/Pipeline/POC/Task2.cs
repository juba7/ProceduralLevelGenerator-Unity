﻿namespace Assets.Scripts.Pipeline.POC
{
	using UnityEngine;

	[CreateAssetMenu]
	public class Task2 : PipelineTask, IPipelineTask<Payload2>
	{
		public void Process(Payload2 payload)
		{
			Debug.Log(GetType());
		}
	}
}