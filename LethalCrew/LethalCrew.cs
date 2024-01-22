using BepInEx;
using HarmonyLib;
using LethalCrew.Patches;

namespace LethalCrew
{
	[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
	public class LethalCrew : BaseUnityPlugin
	{
		private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);

		private void Awake()
		{
			// Plugin startup logic
			Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

			harmony.PatchAll(typeof(LethalCrew));
			harmony.PatchAll(typeof(KillEnemyPatch));
		}
	}
}
