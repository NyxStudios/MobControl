using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TShockAPI;
using Terraria;
namespace TestPlugin
{
    [APIVersion(1, 12)]
    public class TShockBossModule : TerrariaPlugin
    {
        public TShockBossModule(Main game)
            : base(game)
        {
        }
        public override void Initialize()
        {
            Commands.ChatCommands.Add(new Command(Permissions.spawnboss, SpawnBoss, "boss", "eater", "king", "eye", "skeletron", "wof", "wallofflesh", "twins",
		        "destroyer", "prime", "skeletronp", "hardcore"));
            Commands.ChatCommands.Add(new Command(Permissions.spawnmob, SpawnMob, "spawnmob", "sm"));

        }
        public override Version Version
        {
            get { return new Version("4.0.0.0"); }
        }
        public override string Name
        {
            get { return "TShock - Boss Commands"; }
        }
        public override string Author
        {
            get { return "The Nyx Team"; }
        }
        public override string Description
        {
            get { return "Contains the commands for spawning bosses and mobs, that were once in the TShock core."; }
        }

        private static void SpawnBoss(CommandArgs args)
        {
            if (args.Parameters.Count == 0)
            {
                args.Player.SendMessage("As of TShock 4.0, all boss specific spawning commands are now in /boss.", Color.Yellow);
                args.Player.SendMessage("Invalid syntax. Syntax: /boss [name] [count]", Color.Green);
                args.Player.SendMessage("Bosses: eow, king, eye, skeletron, wof, twins, destroyer, prime, *", Color.Green);
                return;
            }
            int numberOfEnemies = 0;
            string boss = args.Parameters[0];
            int.TryParse(args.Parameters[1], out numberOfEnemies);
            numberOfEnemies = Math.Min(numberOfEnemies, Main.maxNPCs);

            if (boss.ToLower() == "eow" || boss.ToLower() == "eater")
            {
                NPC eater = TShock.Utils.GetNPCById(13);
                TSPlayer.Server.SpawnNPC(eater.type, eater.name, numberOfEnemies, args.Player.TileX, args.Player.TileY);
                TShock.Utils.Broadcast(string.Format("{0} has spawned the eater of worlds {1} time(s)!", args.Player.Name, numberOfEnemies));
                return;
            }

            if (boss.ToLower() == "eye")
            {
                NPC eye = TShock.Utils.GetNPCById(4);
                TSPlayer.Server.SetTime(false, 0.0);
                TSPlayer.Server.SpawnNPC(eye.type, eye.name, numberOfEnemies, args.Player.TileX, args.Player.TileY);
                TShock.Utils.Broadcast(string.Format("{0} has spawned the eye of cthulhu {1} time(s)!", args.Player.Name, numberOfEnemies));
                return;
            }

            if (boss.ToLower() == "king")
            {
                NPC king = TShock.Utils.GetNPCById(50);
                TSPlayer.Server.SpawnNPC(king.type, king.name, numberOfEnemies, args.Player.TileX, args.Player.TileY);
                TShock.Utils.Broadcast(string.Format("{0} has spawned the king of slimes {1} time(s)!", args.Player.Name, numberOfEnemies));
                return;
            }

            if (boss.ToLower() == "skeleton")
            {
                NPC skeletron = TShock.Utils.GetNPCById(35);
                TSPlayer.Server.SetTime(false, 0.0);
                TSPlayer.Server.SpawnNPC(skeletron.type, skeletron.name, numberOfEnemies, args.Player.TileX, args.Player.TileY);
                TShock.Utils.Broadcast(string.Format("{0} has spawned skeletron {1} time(s)!", args.Player.Name, numberOfEnemies));
                return;
            }

            if (boss.ToLower() == "wof" || boss.ToLower() == "flesh")
            {
                if (Main.wof >= 0 || (args.Player.Y / 16f < (Main.maxTilesY - 205)))
                {
                    args.Player.SendMessage("Can't spawn a wall of flesh!", Color.Red);
                    return;
                }
                NPC.SpawnWOF(new Vector2(args.Player.X, args.Player.Y));
                TShock.Utils.Broadcast(string.Format("{0} has spawned a wall of flesh!", args.Player.Name));
                return;
            }

            if (boss.ToLower() == "twins")
            {
                NPC retinazer = TShock.Utils.GetNPCById(125);
                NPC spaz = TShock.Utils.GetNPCById(126);
                TSPlayer.Server.SetTime(false, 0.0);
                TSPlayer.Server.SpawnNPC(retinazer.type, retinazer.name, numberOfEnemies, args.Player.TileX, args.Player.TileY);
                TSPlayer.Server.SpawnNPC(spaz.type, spaz.name, numberOfEnemies, args.Player.TileX, args.Player.TileY);
                TShock.Utils.Broadcast(string.Format("{0} has spawned the twins {1} time(s)!", args.Player.Name, numberOfEnemies));
                return;
            }

            if (boss.ToLower() == "destroyer")
            {
                NPC destroyer = TShock.Utils.GetNPCById(134);
                TSPlayer.Server.SetTime(false, 0.0);
                TSPlayer.Server.SpawnNPC(destroyer.type, destroyer.name, numberOfEnemies, args.Player.TileX, args.Player.TileY);
                TShock.Utils.Broadcast(string.Format("{0} has spawned the destroyer {1} time(s)!", args.Player.Name, numberOfEnemies));
                return;
            }

            if (boss.ToLower() == "prime")
            {
                NPC prime = TShock.Utils.GetNPCById(127);
                TSPlayer.Server.SetTime(false, 0.0);
                TSPlayer.Server.SpawnNPC(prime.type, prime.name, numberOfEnemies, args.Player.TileX, args.Player.TileY);
                TShock.Utils.Broadcast(string.Format("{0} has spawned skeletron prime {1} time(s)!", args.Player.Name, numberOfEnemies));
                return;
            }

            if (boss == "*")
            {
                NPC retinazer = TShock.Utils.GetNPCById(125);
                NPC spaz = TShock.Utils.GetNPCById(126);
                NPC destroyer = TShock.Utils.GetNPCById(134);
                NPC prime = TShock.Utils.GetNPCById(127);
                NPC eater = TShock.Utils.GetNPCById(13);
                NPC eye = TShock.Utils.GetNPCById(4);
                NPC king = TShock.Utils.GetNPCById(50);
                NPC skeletron = TShock.Utils.GetNPCById(35);
                TSPlayer.Server.SetTime(false, 0.0);
                TSPlayer.Server.SpawnNPC(retinazer.type, retinazer.name, numberOfEnemies, args.Player.TileX, args.Player.TileY);
                TSPlayer.Server.SpawnNPC(spaz.type, spaz.name, numberOfEnemies, args.Player.TileX, args.Player.TileY);
                TSPlayer.Server.SpawnNPC(destroyer.type, destroyer.name, numberOfEnemies, args.Player.TileX, args.Player.TileY);
                TSPlayer.Server.SpawnNPC(prime.type, prime.name, numberOfEnemies, args.Player.TileX, args.Player.TileY);
                TSPlayer.Server.SpawnNPC(eater.type, eater.name, numberOfEnemies, args.Player.TileX, args.Player.TileY);
                TSPlayer.Server.SpawnNPC(eye.type, eye.name, numberOfEnemies, args.Player.TileX, args.Player.TileY);
                TSPlayer.Server.SpawnNPC(king.type, king.name, numberOfEnemies, args.Player.TileX, args.Player.TileY);
                TSPlayer.Server.SpawnNPC(skeletron.type, skeletron.name, numberOfEnemies, args.Player.TileX, args.Player.TileY);
                TShock.Utils.Broadcast(string.Format("{0} has spawned all bosses {1} time(s)!", args.Player.Name, numberOfEnemies));
                return;
            }
        }

        private static void SpawnMob(CommandArgs args)
        {
            if (args.Parameters.Count < 1 || args.Parameters.Count > 2)
            {
                args.Player.SendMessage("Invalid syntax! Proper syntax: /spawnmob <mob name/id> [amount]", Color.Red);
                return;
            }
            if (args.Parameters[0].Length == 0)
            {
                args.Player.SendMessage("Missing mob name/id", Color.Red);
                return;
            }
            int amount = 1;
            if (args.Parameters.Count == 2 && !int.TryParse(args.Parameters[1], out amount))
            {
                args.Player.SendMessage("Invalid syntax! Proper syntax: /spawnmob <mob name/id> [amount]", Color.Red);
                return;
            }

            amount = Math.Min(amount, Main.maxNPCs);

            var npcs = TShock.Utils.GetNPCByIdOrName(args.Parameters[0]);
            if (npcs.Count == 0)
            {
                args.Player.SendMessage("Invalid mob type!", Color.Red);
            }
            else if (npcs.Count > 1)
            {
                args.Player.SendMessage(string.Format("More than one ({0}) mob matched!", npcs.Count), Color.Red);
            }
            else
            {
                var npc = npcs[0];
                if (npc.type >= 1 && npc.type < Main.maxNPCTypes && npc.type != 113)
                //Do not allow WoF to spawn, in certain conditions may cause loops in client
                {
                    TSPlayer.Server.SpawnNPC(npc.type, npc.name, amount, args.Player.TileX, args.Player.TileY, 50, 20);
                    TShock.Utils.Broadcast(string.Format("{0} was spawned {1} time(s).", npc.name, amount));
                }
                else if (npc.type == 113)
                    args.Player.SendMessage("Sorry, you can't spawn Wall of Flesh! Try /wof instead.");
                // Maybe perhaps do something with WorldGen.SpawnWoF?
                else
                    args.Player.SendMessage("Invalid mob type!", Color.Red);
            }
        }
    }
}