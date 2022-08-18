using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor.Controls
{
	[Serializable]
    public class Tile
    {
		private int x;
		public int X { get => x; set => x = value; }

		private int y;
		public int Y { get => y; set => y = value; }
        public TileControl TileControl { get => tileControl; set => tileControl = value; }

        private TileControl tileControl;

		public Tile(MainWindow window)
		{
			TileControl = new TileControl(window);
			X = 0;
			Y = 0;
		}
	}
}
