using Terraria;
using Terraria.ModLoader;

namespace BSODMod
{
	class MyPlayer : ModPlayer
	{
		private int deathTimer = 180;
		public override void PreUpdate()
		{
			if (player.dead)
			{
				deathTimer -= 1;
				if (deathTimer == 0)
				{
					Main.instance.Exit();
				}
			}
			base.PreUpdate();
		}

	}
}