using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace BSODMod
{
	public class BsodMod : Mod
	{
		private Texture2D BSODTEX;
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int inventoryIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Interface Logic 4"));
			if (inventoryIndex != -1)
			{
				layers.Insert(inventoryIndex, new LegacyGameInterfaceLayer(
					"BSOD: CrashScreen",
					delegate
					{
						if (Main.LocalPlayer.GetModPlayer<MyPlayer>().playerDied)
						{
							Color color = Color.Blue;
							Texture2D tex = this.BSODTEX;
							Rectangle sourceRectangle = new Rectangle(
								x: 0,
								y: 0,
								width: tex.Width,
								height: tex.Height
							);
							
							Main.spriteBatch.Draw(
								texture: tex,
								destinationRectangle: new Rectangle(-2, -2, Main.screenWidth + 4, Main.screenHeight + 4),
								sourceRectangle: sourceRectangle,
								color: Color.White,
								rotation: default,
								origin: default,
								effects: SpriteEffects.None,
								layerDepth: 1f
							);
						}

						return true;
					},
					InterfaceScaleType.Game)
				);
			}

			base.ModifyInterfaceLayers(layers);
		}

		public override void PostSetupContent()
		{
			if (!Main.dedServ && Main.netMode != 2)
			{
				this.BSODTEX = this.GetTexture("fakebsod");
			}
		}
	}
}