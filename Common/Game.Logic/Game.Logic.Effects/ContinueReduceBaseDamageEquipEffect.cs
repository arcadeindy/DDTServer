using Bussiness;
using Game.Logic.Actions;
using Game.Logic.Phy.Object;
using System;

namespace Game.Logic.Effects
{
	public class ContinueReduceBaseDamageEquipEffect : BasePlayerEffect
	{
		private int m_count = 0;
		private int m_probability = 0;
		public ContinueReduceBaseDamageEquipEffect(int count, int probability) : base(eEffectType.ContinueReduceBaseDamageEquipEffect)
		{
			this.m_count = count;
			this.m_probability = probability;
		}
		public override bool Start(Living living)
		{
			ContinueReduceBaseDamageEquipEffect effect = living.EffectList.GetOfType(eEffectType.ContinueReduceBaseDamageEquipEffect) as ContinueReduceBaseDamageEquipEffect;
			bool result;
			if (effect != null)
			{
				effect.m_probability = ((this.m_probability > effect.m_probability) ? this.m_probability : effect.m_probability);
				result = true;
			}
			else
			{
				result = base.Start(living);
			}
			return result;
		}
		protected override void OnAttachedToPlayer(Player player)
		{
			player.BeforePlayerShoot += new PlayerShootEventHandle(this.ChangeProperty);
			player.AfterKillingLiving += new KillLivingEventHanlde(this.player_AfterKillingLiving);
		}
		private void player_AfterKillingLiving(Living living, Living target, int damageAmount, int criticalAmount, int delay)
		{
			if (this.IsTrigger)
			{
				if (target is Player)
				{
					target.AddEffect(new ContinueReduceBaseDamageEffect(2, this.m_count), 0);
				}
			}
		}
		protected override void OnRemovedFromPlayer(Player player)
		{
			player.BeforePlayerShoot -= new PlayerShootEventHandle(this.ChangeProperty);
			player.AfterKillingLiving -= new KillLivingEventHanlde(this.player_AfterKillingLiving);
		}
		private void ChangeProperty(Player player, int ball)
		{
			this.IsTrigger = false;
			if (AbstractEffect.random.Next(1000000) < this.m_probability * 10000)
			{
				this.IsTrigger = true;
				player.AttackEffectTrigger = true;
				player.Game.AddAction(new LivingSayAction(player, LanguageMgr.GetTranslation("ContinueReduceBaseDamageEquipEffect.msg", new object[0]), 9, 0, 1000));
			}
		}
	}
}
