﻿using CosmicFishingBuddies.BaseSync;
using FluffyUnderware.DevTools.Extensions;
using System;
using UnityEngine;

namespace CosmicFishingBuddies.PlayerSync
{
	internal class PlayerTransformSync : TransformSync
	{
		public static PlayerTransformSync LocalInstance { get; private set; }

		public static GameObject PlayerPrefab { get; private set; }

		private static void CreatePrefab()
		{
			try
			{
				PlayerPrefab = new GameObject("PlayerPrefab");

				var boatModel = GameObject.Instantiate(GameManager.Instance.Player.transform.Find("Boat1"));
				boatModel.transform.parent = PlayerPrefab.transform;
				boatModel.transform.localPosition = Vector3.zero;
				boatModel.transform.localRotation = Quaternion.identity;
				boatModel.gameObject.SetActive(true);

				var wake = GameObject.Instantiate(GameManager.Instance.Player.transform.Find("BoatTrailParticles"));
				wake.transform.parent = PlayerPrefab.transform;
				wake.transform.localPosition = Vector3.zero;
				wake.transform.localRotation = Quaternion.identity;

				// TODO: Fix the tyres
				boatModel.GetComponentsInChildren<Rigidbody>().ForEach(x => x.gameObject.SetActive(false));

				PlayerPrefab.SetActive(false);
				GameObject.DontDestroyOnLoad(PlayerPrefab);
			}
			catch (Exception e)
			{
				CFBCore.LogError($"Failed to make player prefab - multiplayer will not function {e}");
			}
		}

		protected override Transform InitLocalTransform()
		{
			CFBCore.LogInfo($"Creating local {nameof(PlayerTransformSync)}");

			LocalInstance = this;
			return GameManager.Instance.Player.transform;
		}

		protected override Transform InitRemoteTransform()
		{
			CFBCore.LogInfo($"Creating remote {nameof(PlayerTransformSync)}");

			if (PlayerPrefab == null) CreatePrefab();
			var remotePlayer = Instantiate(PlayerPrefab).transform;
			remotePlayer.gameObject.SetActive(true);
			remotePlayer.name = "RemotePlayer";
			remotePlayer.transform.parent = transform;
			remotePlayer.transform.localPosition = Vector3.zero;
			remotePlayer.transform.localRotation = Quaternion.identity;

			var networkPlayer = GetComponent<NetworkPlayer>();
			networkPlayer.boatModelProxy = remotePlayer.GetComponentInChildren<BoatModelProxy>();

			return remotePlayer;
		}
	}
}
