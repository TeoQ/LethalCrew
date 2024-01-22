using HarmonyLib;

namespace LethalCrew.Patches
{
	[HarmonyPatch(typeof(EnemyAI))]
	internal class KillEnemyPatch
	{
		[HarmonyPatch(typeof(EnemyAI), nameof(EnemyAI.KillEnemy))]
		[HarmonyPostfix]
		static void KillEnemyGrantQuotaPatch()
		{
			Terminal terminal = UnityEngine.Object.FindObjectOfType<Terminal>();
			terminal.groupCredits += 100;
			//TimeOfDay.Instance.quotaFulfilled += 100;
			HUDManager.Instance.UIAudio.PlayOneShot(HUDManager.Instance.reachedQuotaSFX);

		}
	}
}
