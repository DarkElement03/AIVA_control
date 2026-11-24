/*
TODO

landing gear check:
    on/off
    un/locked

connector un/locked(docking)
thrusters on/off
    atmo
    hydro
    ion

*/
#region Prelude
using System.Collections.Generic;
using Sandbox.ModAPI.Ingame;
using System;
using System.Linq;
using VRageMath;
using System.Text;
using SpaceEngineers.CommonLibs;
using SpaceEngineers.Game.ModAPI;
using VRage.Game.ModAPI;
using Sandbox.ModAPI.Interfaces;
using System.Runtime.InteropServices;

namespace SpaceEngineers.UWBlockPrograms.SampleMainNs
{
    public sealed class Controller : MyGridProgram
    {
        #endregion
        
        //space engineers script to monitor the status of a ship and send command to main.cs to play sound
        int cycles;
        string[] command;
        IMyBlockGroup group;
        IMyProgrammableBlock AIVA;
        IMyTimerBlock WSRdy;
        IMyCockpit mainCockpit;
        List<IMyDoor> doors;
        List<IMyInteriorLight> lights;
        List<IMyThrust> Athrusters;
        IMyJumpDrive Jump;
        IMyGridJumpDriveSystem JumpSys;

        public Controller()
        {
            // It's recommended to set RuntimeInfo.UpdateFrequency 
            // here, which will allow your script to run itself without a 
            // timer block.
            Runtime.UpdateFrequency = UpdateFrequency.Update100;
            AIVA = (IMyProgrammableBlock)GridTerminalSystem.GetBlockWithName("Automaton Programmable Block AIVA");

            WSRdy = (IMyTimerBlock)GridTerminalSystem.GetBlockWithName("Automaton Timer Block WSRdy");

            group = GridTerminalSystem.GetBlockGroupWithName("Doors");
            group.GetBlocksOfType(doors);

            group = GridTerminalSystem.GetBlockGroupWithName("Lights");
            group.GetBlocksOfType(lights);

            Jump = (IMyJumpDrive)GridTerminalSystem.GetBlockWithName("Jump Drive");
            JumpSys = (IMyGridJumpDriveSystem)GridTerminalSystem.GetBlockWithName("Jump Drive");
            cycles = 3;//around 5 seconds
        }

        public void Save()
        {
            Storage = command[1];
            // Called when the program needs to save its state. Use
            // this method to save your state to the Storage field
            // or some other means. 
            // 
            // This method is optional and can be removed if not
            // needed.
        }

        void delay(int seconds) {
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalSeconds < seconds) {}
        }

        public void Main(string argument, UpdateType updateSource)
        {
            if (argument == null)
            Storage += argument + ',';
            command = Storage.Split(';',2);
            if (command.Length == 1) { command[1] = "\0"; }
            switch (command[0]) {
                case "EmergOn" :
                    {
                        AIVA.TryRun("EnemyDetected");
                        command[1] += "CloseDoor;LightsOff;WeapSysRdy;";
                        break;
                    }
                case "CloseDoor":
                    {
                        AIVA.TryRun("DoorsClosed");
                        foreach (var door in doors)
                        {
                            door.CloseDoor();
                            door.Enabled = false;
                        }
                        break;
                    }
                case "LightsOff":
                    {

                        AIVA.TryRun("LightsOff");
                        foreach (var light in lights) { light.Enabled = false; }
                        break;
                    }
                case "WeapSysRdy":
                    {
                        AIVA.TryRun("WeaponsSystemsReady");
                        WSRdy.Trigg
                        break;
                    }
                case "EmergOff" :
                    {
                        AIVA.TryRun("SystemsOnline");
                        command[1] += "OpenDoor;LightsOn;";
                        break;
                    }
                case "OpenDoor":
                    {
                        AIVA.TryRun("DoorsOpen");
                        foreach (var door in doors) { door.Enabled = true; }
                        break;
                    }
                case "lightsOn":
                    {
                        AIVA.TryRun("LightsOn");
                        foreach(var light in lights){light.Enabled=true;}
                        delay(5);
                        break;
                    }
                case "Land":
                    {
                        AIVA.TryRun("");
                        break;
                    }


                /*case "Jump" : {
                    Vector3D vector = mainCockpit.WorldMatrix.GetDirectionVector(Base6Directions.Direction.Forward);
                    int max = ((int)Jump.MaxJumpDistanceMeters);
                    JumpSys.FindSuitableJumpLocation(vector);//maybe not needed?
                    JumpSys.Jump(vector,mainCockpit.OwnerId,0);
                    AIVA.ApplyAction("Warp");
                    break;
                }*/
            }
        }

        #region PreludeFooter
    }
}
#endregion