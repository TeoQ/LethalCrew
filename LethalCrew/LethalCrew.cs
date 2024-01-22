using BepInEx;
using HarmonyLib;
using LethalCrew.Patches;
using BepInEx.Configuration;

namespace LethalCrew
{
	[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
	public class LethalCrew : BaseUnityPlugin
	{
		private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);

		// Config file binding
		public static ConfigEntry<bool> configRewardCredits;
		public static ConfigEntry<bool> configRewardQuota;

		public static ConfigEntry<int> configCentipedeReward;
		public static ConfigEntry<int> configSpiderReward;
		public static ConfigEntry<int> configHoarderBugReward;
		public static ConfigEntry<int> configFlowerManReward;
		public static ConfigEntry<int> configCrawlerReward;
		public static ConfigEntry<int> configNutcrackerReward;
		public static ConfigEntry<int> configMaskedPlayerReward;
		public static ConfigEntry<int> configDogReward;
		public static ConfigEntry<int> configBaboonReward;


		private void Awake()
		{
			Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

			// Config initialization
			configRewardCredits = Config.Bind("__General__", "DoRewardsGrantCredits", true, "Does killing an enemy grants credits ?");
			configRewardQuota = Config.Bind("__General__", "DoRewardsGrantQuota", true, "Does killing an enemy grants quota ?");

			configCentipedeReward = Config.Bind("__Rewards__", "CentipedeReward", 15, "How much does a Centipede/Snare flea grants upon death.");
			configSpiderReward = Config.Bind("__Rewards__", "SpiderReward", 45, "How much does a Spider grants upon death.");
			configHoarderBugReward = Config.Bind("__Rewards__", "HoarderBugReward", 25, "How much does a Hoarder bug grants upon death.");
			configFlowerManReward = Config.Bind("__Rewards__", "FlowerManReward", 150, "How much does a Flower Man/Bracken grants upon death.");
			configCrawlerReward = Config.Bind("__Rewards__", "CrawlerReward", 75, "How much does a Crawler/Thumper grants upon death.");
			configNutcrackerReward = Config.Bind("__Rewards__", "NutcrackerReward", 250, "How much does a Nutcracker grants upon death.");
			configMaskedPlayerReward = Config.Bind("__Rewards__", "MaskedPlayerReward", 35, "How much does a MaskedPlayer/Zombie grants upon death.");
			configDogReward = Config.Bind("__Rewards__", "DogReward", 300, "How much does a Dog grants upon death.");
			configBaboonReward = Config.Bind("__Rewards__", "BaboonHawkReward", 50, "How much does Baboon Hawk grants upon death.");

			// Harmony patching
			harmony.PatchAll(typeof(LethalCrewPatch));
		}
	}
}
