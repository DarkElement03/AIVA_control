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
        Queue<string> queue;
        int cycles;
        string command;
        IMyBlockGroup group;
        IMyProgrammableBlock AIVA;
        IMyCockpit mainCockpit;
        List<IMyDoor> doors;
        List<IMyInteriorLight> lights;
        IMyJumpDrive Jump;
        IMyGridJumpDriveSystem JumpSys;

        public Controller()
        {
            // It's recommended to set RuntimeInfo.UpdateFrequency 
            // here, which will allow your script to run itself without a 
            // timer block.
            Runtime.UpdateFrequency = UpdateFrequency.Update100;
            AIVA = (IMyProgrammableBlock)GridTerminalSystem.GetBlockWithName("Automaton Programmable Block AIVA");
            group = GridTerminalSystem.GetBlockGroupWithName("Doors");
            group.GetBlocksOfType(doors);
            group = GridTerminalSystem.GetBlockGroupWithName("Lights");
            group.GetBlocksOfType(lights);
            Jump = (IMyJumpDrive)GridTerminalSystem.GetBlockWithName("Jump Drive");
            JumpSys = (IMyGridJumpDriveSystem)GridTerminalSystem.GetBlockWithName("Jump Drive");
            Queue<string> queue = new Queue<string>();
            cycles = 3;//around 5 seconds
        }

        public void Save()
        {
            /*(string)Storage = <something>;*/
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
            command = queue.First();
            switch (argument) {
                case "EmergOn" : {
                    AIVA.TryRun("EnemyDetected");
                        Echo("1");
                    delay(5);

                    AIVA.TryRun("DoorsClosed");
                        Echo("2");
                    foreach(var door in doors)
                    {
                        door.CloseDoor();
                        door.Enabled=false;
                    }
                    delay(5);

                    AIVA.TryRun("LightsOff");
                        Echo("3");
                    foreach(var light in lights){light.Enabled=false;}
                    delay(5);

                    AIVA.TryRun("WeaponsSystemsReady");
                        Echo("4");
                    break;
                }
                case "EmergOff" : {
                    AIVA.TryRun("SystemsOnline");
                    delay(5);

                    AIVA.TryRun("DoorsOpen");
                    foreach(var door in doors){door.Enabled=true;}
                    delay(5);

                    AIVA.TryRun("LightsOn");
                    foreach(var light in lights){light.Enabled=true;}
                    delay(5);
                    break;
                }
                case "Jump" : {
                    Vector3D vector = mainCockpit.WorldMatrix.GetDirectionVector(Base6Directions.Direction.Forward);
                    int max = ((int)Jump.MaxJumpDistanceMeters);
                    JumpSys.FindSuitableJumpLocation(vector);//maybe not needed?
                    JumpSys.Jump(vector,mainCockpit.OwnerId,0);
                    AIVA.ApplyAction("Warp");
                    break;
                }
            }
        }

        #region PreludeFooter
    }
}
#endregion