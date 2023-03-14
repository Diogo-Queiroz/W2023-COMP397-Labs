using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using System.Linq;

namespace Factory
{
    public abstract class Tile
    {
        public abstract string name { get; }
        public abstract void Create();
    }

    public class EmptyTile : Tile
    {
        public override string name => "Empty Tile";

        public override void Create()
        {
            Debug.Log("Empty Tile Created");
        }
    }

    public class RobotTile : Tile
    {
        public override string name => "Robot Tile";

        public override void Create()
        {
            Debug.Log("Robot Tile Created");
        }
    }

    public class HealthPackTile : Tile
    {
        public override string name => "Health Pack Tile";

        public override void Create()
        {
            Debug.Log("Health Pack Tile Created");
        }
    }

    public class HealthUpgradeTile : Tile
    {
        public override string name => "Health Upgrade Tile";

        public override void Create()
        {
            Debug.Log("Health Upgrade Tile Created");
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

            foreach (var type in tileTypes)
            {
                var tempTile = Activator.CreateInstance(type) as Tile;
                tileNames.Add(tempTile.name, type);
            }
        }

        public static Tile GetTile(string tileType)
        {
            InitializeFactory();
            if (tileNames.ContainsKey(tileType))
            {
                Type type = tileNames[tileType];
                var tile = Activator.CreateInstance(type) as Tile;
                return tile;
            }
            return null;
        }

        internal static IEnumerable<string> GetTileNames()
        {
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

