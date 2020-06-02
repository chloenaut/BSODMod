using Terraria;
using Terraria.ModLoader;

namespace BSODMod
{
	class MyPlayer : ModPlayer
	{
		private bool playerDied = false;
		private int deathTimer = 180;

		public override void PreUpdate()
		{
			if (player.dead)
			{
				playerDied = true;
			}
		
			if(playerDied)
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