using Game.Server.GameObjects;
using Game.Server.Quests;
using System;
namespace Game.Server.Achievement
{
	internal class QuestBlueCondition : BaseUserRecord
	{
		public QuestBlueCondition(GamePlayer player, int type) : base(player, type)
		{
			this.AddTrigger(player);
		}
		public override void AddTrigger(GamePlayer player)
		{
			player.PlayerQuestFinish += new GamePlayer.PlayerQuestFinishEventHandel(this.player_PlayerQuestFinish);
		}
		private void player_PlayerQuestFinish(BaseQuest baseQuest)
		{
			if (baseQuest.Data.RandDobule == 2)
			{
				this.m_player.AchievementInventory.UpdateUserAchievement(this.m_type, 1);
			}
		}
		public override void RemoveTrigger(GamePlayer player)
		{
			player.PlayerQuestFinish -= new GamePlayer.PlayerQuestFinishEventHandel(this.player_PlayerQuestFinish);
		}
	}
}
