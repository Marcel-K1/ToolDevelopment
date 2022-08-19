using LevelEditor.Controls;
using LevelEditor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
	public class LevelSerializer
	{
		public static void Save(string path, List<Tile> tileList)
		{

			try
			{
				using (FileStream fs = File.Create(path))
				{
					BinaryFormatter bs = new BinaryFormatter();
					bs.Serialize(fs, tileList);
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static List<Tile> Load(string path)
		{
			try
			{
				using (FileStream fs = File.OpenRead(path))
				{
					BinaryFormatter bs = new BinaryFormatter();
					return bs.Deserialize(fs) as List<Tile>;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static List<Tile> Load(byte[] bytes)
		{
			try
			{
				using (MemoryStream ms = new MemoryStream(bytes))
				{
					BinaryFormatter bf = new BinaryFormatter();
					return bf.Deserialize(ms) as List<Tile>;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
