using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Factory
{
    public abstract class Tile
    {
        public abstract string Name { get; }
        public abstract void Create();
    }

    public class EmptyTile : Tile
    {
        public override string Name => "Empty";

        public override void Create()
        {
            UnityEngine.Debug.Log("Create Empty Tile");
        }
    }

    public class RobotTile : Tile
    {
        public override string Name => "Robot";

        public override void Create()
        {
            UnityEngine.Debug.Log("Create Robot Tile");
        }
    }

    public class HealthPackTile : Tile
    {
        public override string Name => "Health Pack";

        public override void Create()
        {
            UnityEngine.Debug.Log("Create Health Pack Tile");
        }
    }

    public class HealthUpgradeTile : Tile
    {
        public override string Name => "Health Upgrade";

        public override void Create()
        {
            UnityEngine.Debug.Log("Create Health Upgrade Tile");
        }
    }

    public class TileFactory
    {
        private static Dictionary<string, Type> tileNames;
        private static bool IsInitialized => tileNames != null;

        private static void InitializeFactory()
        {
            if (IsInitialized) return;
            
            var tileTypes = Assembly.GetAssembly(typeof(Tile)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Tile)));

            tileNames = new Dictionary<string, Type>();

            foreach (Type type in tileTypes)
            {
                Tile tempTile = Activator.CreateInstance(type) as Tile;
                tileNames.Add(tempTile.Name, type);
            }
        }
        
        public static Tile GetTile(string tileType)
        {
            InitializeFactory();

            if (tileNames.ContainsKey(tileType))
            {
                Type type = tileNames[tileType];
                Tile tile = Activator.CreateInstance(type) as Tile;
                return tile;
            }
            return null;
        }

        internal static IEnumerable<string> GetTileNames()
        {
            UnityEngine.Debug.Log($"Test");
            InitializeFactory();
            return tileNames.Keys;
        }

        internal static int GetTileCount()
        {
            InitializeFactory();
            return tileNames.Count;
        }
    }
}

