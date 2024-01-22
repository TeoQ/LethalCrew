using HarmonyLib;

namespace LethalCrew.Patches
{
	[HarmonyPatch]
	internal class LethalCrewPatch
	{
		static void RewardEnemyKill(int _rewardValue, string _enemyName)
		{
			if (_rewardValue <= 0 || (LethalCrew.configRewardCredits.Value == false && LethalCrew.configRewardQuota.Value == false))
				return;

			if (LethalCrew.configRewardCredits.Value)
			{
				Terminal terminal = UnityEngine.Object.FindObjectOfType<Terminal>();
				terminal.groupCredits += _rewardValue;
			}

			if (LethalCrew.configRewardQuota.Value)
			{
				TimeOfDay.Instance.quotaFulfilled += _rewardValue;
				TimeOfDay.Instance.UpdateProfitQuotaCurrentTime();
			}

			HUDManager.Instance.UIAudio.PlayOneShot(HUDManager.Instance.reachedQuotaSFX);
			HUDManager.Instance.DisplayTip("Congratulations !", "You killed " + _enemyName + " ! The Company granted you " + _rewardValue + " credits !");
		}

		// ___ Patching CENTIPEDE ___ //
		[HarmonyPostfix]
		[HarmonyPatch(typeof(CentipedeAI), nameof(CentipedeAI.KillEnemy))]
		static void KillCentipedePatch()
		{
			RewardEnemyKill(LethalCrew.configCentipedeReward.Value, "a Snare flea");
		}

		// ___ Patching SPIDER ___ //
		[HarmonyPostfix]
		[HarmonyPatch(typeof(SandSpiderAI), nameof(SandSpiderAI.KillEnemy))]
		static void KillSpiderPatch()
		{
			RewardEnemyKill(LethalCrew.configSpiderReward.Value, "a Spider");
		}

		// ___ Patching HOARDER BUG *YIPEEEEEE* ___ //
		[HarmonyPostfix]
		[HarmonyPatch(typeof(HoarderBugAI), nameof(HoarderBugAI.KillEnemy))]
		static void KillHoarderBugPatch()
		{
			RewardEnemyKill(LethalCrew.configHoarderBugReward.Value, "a Hoarding Bug");
		}

		// ___ Patching FLOWER MAN ___ //
		[HarmonyPostfix]
		[HarmonyPatch(typeof(FlowermanAI), nameof(FlowermanAI.KillEnemy))]
		static void KillFlowerManPatch()
		{
			RewardEnemyKill(LethalCrew.configFlowerManReward.Value, "a Bracken");
		}

		// ___ Patching CRAWLER  ___ //
		[HarmonyPostfix]
		[HarmonyPatch(typeof(CrawlerAI), nameof(CrawlerAI.KillEnemy))]
		static void KillCrawlerPatch()
		{
			RewardEnemyKill(LethalCrew.configCrawlerReward.Value, "a Thumper");
		}

		// ___ Patching NUTCRACKER  ___ //
		[HarmonyPostfix]
		[HarmonyPatch(typeof(NutcrackerEnemyAI), nameof(NutcrackerEnemyAI.KillEnemy))]
		static void KillNutcrackerPatch()
		{
			RewardEnemyKill(LethalCrew.configNutcrackerReward.Value, "a Nutcracker");
		}

		// ___ Patching MASKED PLAYER  ___ //
		[HarmonyPostfix]
		[HarmonyPatch(typeof(MaskedPlayerEnemy), nameof(MaskedPlayerEnemy.KillEnemy))]
		static void KillMaskedPlayerPatch()
		{
			RewardEnemyKill(LethalCrew.configMaskedPlayerReward.Value, "a Nutcracker");
		}

		// ___ Patching DOG  ___ //
		[HarmonyPostfix]
		[HarmonyPatch(typeof(MouthDogAI), nameof(MouthDogAI.KillEnemy))]
		static void KillDogPatch()
		{
			RewardEnemyKill(LethalCrew.configDogReward.Value, "an Eyeless Dog");
		}

		// ___ Patching BABOON BIRD ___ //
		[HarmonyPostfix]
		[HarmonyPatch(typeof(BaboonBirdAI), nameof(BaboonBirdAI.KillEnemy))]
		static void KillBaboonBirdPatch()
		{
			RewardEnemyKill(LethalCrew.configBaboonReward.Value, "a Baboon hawk");
		}
	}
}
