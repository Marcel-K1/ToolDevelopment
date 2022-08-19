using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static LevelEditor.MainWindow;

namespace LevelEditor.Controls
{
	[Serializable]
    public class Tile : INotifyPropertyChanged
    {

		private int x;
		public int X { get => x; set => OnPropertyChanged(ref x, value, nameof(X)); }

		private int y;
		public int Y { get => y; set => OnPropertyChanged(ref y, value, nameof(Y)); }

		private Tiles tileType;
		public Tiles TileType { get => tileType; set => OnPropertyChanged(ref tileType, value, nameof(TileType)); }


		public Tile(Tiles tileType)
		{
			X = 0;
			Y = 0;
			this.tileType = tileType;
		}


		[field: NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged<T>(ref T oldValue, T newValue, string propertyName)
		{
			if (oldValue.Equals(newValue)) return;
			oldValue = newValue;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
