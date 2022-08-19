using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LevelEditor.Controls
{
	[Serializable]
    public class Tile
    {

		private int x;
		public int X { get => x; set => x = value; }

		private int y;
		public int Y { get => y; set => y = value; }

        public ImageSource TileImageSource { get; set; }

        //public TileControl TileControl { get => tileControl; set => tileControl = value; }

        //private TileControl tileControl;

        public Tile(ImageSource imageSource)
		{
			X = 0;
			Y = 0;
			TileImageSource = imageSource;
		}

		//public Tile(MainWindow window)
		//{
  //          TileControl = new TileControl(window);
  //          X = 0;
		//	Y = 0;
		//}
	}
}
