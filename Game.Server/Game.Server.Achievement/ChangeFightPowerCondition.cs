using Game.Server.GameObjects;
using SqlDataProvider.Data;
using System;
namespace Game.Server.Achievement
{
	public class ChangeFightPowerCondition : BaseUserRecord
	{
		public ChangeFightPowerCondition(GamePlayer player, int type) : base(player, type)
		{
			this.AddTrigger(player);
		}
		public override void AddTrigger(GamePlayer player)
		{
			player.PlayerPropertyChanged += new GamePlayer.PlayerPropertyChangedEventHandel(this.player_PlayerPropertyChanged);
		}
		private void player_PlayerPropertyChanged(PlayerInfo character)
		{
			this.m_player.AchievementInventory.UpdateUserAchievement(this.m_type, character.FightPower, 1);
		}
		public override void RemoveTrigger(GamePlayer player)
		{
			player.PlayerPropertyChanged -= new GamePlayer.PlayerPropertyChangedEventHandel(this.player_PlayerPropertyChanged);
		}
	}
}
