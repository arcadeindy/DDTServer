using Game.Server.GameObjects;
using SqlDataProvider.Data;
using System;
namespace Game.Server.Buffer
{
	public class KickProtectBuffer : AbstractBuffer
	{
		public KickProtectBuffer(BufferInfo info) : base(info)
		{
		}
		public override void Start(GamePlayer player)
		{
			KickProtectBuffer buffer = player.BufferList.GetOfType(typeof(KickProtectBuffer)) as KickProtectBuffer;
			if (buffer != null)
			{
				buffer.Info.ValidDate += base.Info.ValidDate;
				player.BufferList.UpdateBuffer(buffer);
			}
			else
			{
				base.Start(player);
				player.KickProtect = true;
			}
		}
		public override void Stop()
		{
			this.m_player.KickProtect = false;
			base.Stop();
		}
	}
}
