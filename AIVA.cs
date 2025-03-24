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

namespace SpaceEngineers.UWBlockPrograms.SampleMainNs
{
    public sealed class AIVA : MyGridProgram
    {
        #endregion

        string[] Greetings = {"A-GRNG Clr Greetings (A133)",
        "A-GRNG Greetings Funny 1 (A134)",
        "A-GRNG Greetings Funny 2 (A135)",
        "A-GRNG Greetings Funny 3 (A136)",
        "A-GRNG Greetings Funny 4 (A137)",
        "A-GRNG Greetings Funny 5 (A138)",
        "A-GRNG Greetings Funny 6 (A139)",
        "A-GRNG Greetings Phrase 1 (A140)",
        "A-GRNG Greetings Phrase 2 (A141)",
        "A-GRNG Greetings Phrase 3 (A142)",
        "A-GRNG Greetings Phrase 4 (A143)"
        };

        string[] Warps = {"A-WARP Warp Jump successful (A063)",
        "A-WARP Warp Jump phrase (A064)"
        };

        int time;
        public void Main(string argument,UpdateType updateSource)
        {       
            IMySoundBlock block = (IMySoundBlock)GridTerminalSystem.GetBlockWithName("Sound Block AIVA");
            switch (argument)
            {
            //basics
                case "AirlockOpen":{block.SelectedSound = "A-BSIC Airlock open (A001)";break;}
                case "AirlockClose":{block.SelectedSound = "A-BSIC Airlock close (A002)";break;}
                case "DoorsOpen":{block.SelectedSound = "A-BSIC Doors open (A003)";break;}
                case "DoorsClose":{block.SelectedSound = "A-BSIC Doors close (A004)";break;}
                case "HangarDoorsOpen":{block.SelectedSound = "A-BSIC Hangar doors open (A005)";break;}
                case "HangarDoorsClose":{block.SelectedSound = "A-BSIC Hangar doors close (A006)";break;}
                case "LightsOn":{block.SelectedSound = "A-BSIC Lights on (A007)";break;}
                case "LightsOff":{block.SelectedSound = "A-BSIC Lights off (A008)";break;}
                case "ObjectiveStarted":{block.SelectedSound = "A-BSIC Objective started (A009)";break;}
                case "ObjectiveComplete":{block.SelectedSound = "A-BSIC Objective complete (A010)";break;}
                case "ObjectiveFailed":{block.SelectedSound = "A-BSIC Objective failed (A011)";break;}
                case "SystemsOnline":{block.SelectedSound = "A-BSIC Systems online (A012)";break;}
            //notifications
                case "FuelLow":{block.SelectedSound = "A-NOTS Fuel low (A013)";break;}
                case "FuelCritical":{block.SelectedSound = "A-NOTS Fuel critical (A014)";break;}
                case "FuelRestored":{block.SelectedSound = "A-NOTS Fuel restored (A015)";break;}
                case "OxygenLow":{block.SelectedSound = "A-NOTS Oxygen low (A016)";break;}
                case "OxygenRestored":{block.SelectedSound = "A-NOTS Oxygen restored (A017)";break;}
                case "BatteryLow":{block.SelectedSound = "A-NOTS Battery low (A018)";break;}
                case "BatteryCritical":{block.SelectedSound = "A-NOTS Battery critical (A019)";break;}
                case "BatteryCharged":{block.SelectedSound = "A-NOTS Battery charged (A020)";break;}
                case "EnergyConsumptionCritical":{block.SelectedSound = "A-NOTS Energy consumption critical (A021)";break;}
                case "CargoFull":{block.SelectedSound = "A-NOTS Cargo full (A022)";break;}
                case "CargoEmptied":{block.SelectedSound = "A-NOTS Cargo emptied (A023)";break;}
                case "ShipOverloaded":{block.SelectedSound = "A-NOTS Ship overloaded (A024)";break;}
                case "EnShieldCharged":{block.SelectedSound = "A-NOTS EnShield charged (A025)";break;}
                case "EnShieldCritical":{block.SelectedSound = "A-NOTS EnShield critical (A026)";break;}
                case "RefineryFinal":{block.SelectedSound = "A-NOTS Refinery final (A027)";break;}
                case "RefineryFull":{block.SelectedSound = "A-NOTS Refinery full (A028)";break;}
                case "AssemblerFull":{block.SelectedSound = "A-NOTS Assembler full (A029)";break;}
            //flight
                case "ThrustersEngaged":{block.SelectedSound = "A-FLGT Thrusters engaged (A030)";break;}
                case "ThrustersDeactivated":{block.SelectedSound = "A-FLGT Thrusters deactivated (A031)";break;}
                case "AtmosThrustersEngaged":{block.SelectedSound = "A-FLGT Atmos thrusters engaged (A032)";break;}
                case "AtmosThrustersDeactivated":{block.SelectedSound = "A-FLGT Atmos thrusters deactivated (A033)";break;}
                case "AtmosThrustersInefficient":{block.SelectedSound = "A-FLGT Atmos thrusters inefficient (A034)";break;}
                case "HydroThrustersEngaged":{block.SelectedSound = "A-FLGT Hydro thrusters engaged (A035)";break;}
                case "HydroThrustersDeactivated":{block.SelectedSound = "A-FLGT Hydro thrusters deactivated (A036)";break;}
                case "IonThrustersEngaged":{block.SelectedSound = "A-FLGT Ion thrusters engaged (A037)";break;}
                case "IonThrustersDeactivated":{block.SelectedSound = "A-FLGT Ion thrusters deactivated (A038)";break;}
                case "IonThrustersInefficient":{block.SelectedSound = "A-FLGT Ion thrusters inefficient (A039)";break;}
                case "InertialThrustersActivate":{block.SelectedSound = "A-FLGT Inertial thrusters activate (A040)";break;}
                case "InertialThrustersDeactivated":{block.SelectedSound = "A-FLGT Inertial thrusters deactivated (A041)";break;}
                case "CruiseControlActivate":{block.SelectedSound = "A-FLGT Cruise control activate (A042)";break;}
                case "CruiseControlDeactivate":{block.SelectedSound = "A-FLGT Cruise control deactivate (A043)";break;}
                case "AutopilotActivate":{block.SelectedSound = "A-FLGT Autopilot activate (A044)";break;}
                case "AutopilotDeactivated":{block.SelectedSound = "A-FLGT Autopilot deactivated (A045)";break;}
                case "WaypointSet":{block.SelectedSound = "A-FLGT Waypoint set (A046)";break;}
                case "EnteringGravityField":{block.SelectedSound = "A-FLGT Entering a gravity field (A047)";break;}
                case "ExitingGravityField":{block.SelectedSound = "A-FLGT Exiting gravity field (A048)";break;}
                case "GravityFieldDetected":{block.SelectedSound = "A-FLGT Gravity field detected (A049)";break;}
                case "GravityFieldLeft":{block.SelectedSound = "A-FLGT Gravity field left (A050)";break;}
                case "HighSpeed":{block.SelectedSound = "A-FLGT High speed (A051)";break;}
                case "MaximumSpeedReached":{block.SelectedSound = "A-FLGT Maximum speed reached (A052)";break;}
                case "SlowDown":{block.SelectedSound = "A-FLGT Slow down (A053)";break;}
                case "Alt100m":{block.SelectedSound = "A-FLGT Alt 100m (A054)";break;}
                case "Alt500m":{block.SelectedSound = "A-FLGT Alt 500m (A055)";break;}
                case "Alt1km":{block.SelectedSound = "A-FLGT Alt 1km (A056)";break;}
                case "Alt2km":{block.SelectedSound = "A-FLGT Alt 2km (A057)";break;}
                case "Alt10km":{block.SelectedSound = "A-FLGT Alt 10km (A058)";break;}
                case "Alt20km":{block.SelectedSound = "A-FLGT Alt 20km (A059)";break;}
                case "Alt30km":{block.SelectedSound = "A-FLGT Alt 30km (A060)";break;}
            //warp
                case "WarpDriveCharged":{block.SelectedSound = "A-WARP Warp drive charged (A061)";break;}
                case "WarpJumpCountdown":{block.SelectedSound = "A-WARP Warp Jump Countdown (A062)";break;}
                case "Warp":
                {
                    time = (int) System.DateTime.Now.ToBinary();
                    block.SelectedSound = Warps[Math.Abs(time%2)];
                    break;
                }
            //parking
                case "Landing":{block.SelectedSound = "A-PRKG Landing (A065)";break;}
                case "LandingEmergency":{block.SelectedSound = "A-PRKG Landing emergency (A066)";break;}
                case "LandingGearExtended":{block.SelectedSound = "A-PRKG Landing gear extended (A067)";break;}
                case "LandingGearRetracted":{block.SelectedSound = "A-PRKG Landing gear retracted (A068)";break;}
                case "Liftoff":{block.SelectedSound = "A-PRKG Liftoff (A069)";break;}
                case "Docking":{block.SelectedSound = "A-PRKG Docking (A070)";break;}
                case "DockingCargoLoading":{block.SelectedSound = "A-PRKG Docking Cargo loading (A071)";break;}
                case "DockingCargoUnloading":{block.SelectedSound = "A-PRKG Docking Cargo unloading (A072)";break;}
                case "DockingCharging":{block.SelectedSound = "A-PRKG Docking Charging (A073)";break;}
                case "DockingRefueling":{block.SelectedSound = "A-PRKG Docking Refueling (A074)";break;}
                case "DockingPhrase":{block.SelectedSound = "A-PRKG Docking Phrase (A075)";break;}
                case "UnDocking":{block.SelectedSound = "A-PRKG UnDocking (A076)";break;}
            //combat
                case "EnemyDetected":{block.SelectedSound = "A-CMBT Enemy detected (A077)";break;}
                case "EnemyOnBoard":{block.SelectedSound = "A-CMBT Enemy on board (A078)";break;}
                case "WeaponsSystemsReady":{block.SelectedSound = "A-CMBT Weapons systems ready (A079)";break;}
                case "LaunchingEscapePod":{block.SelectedSound = "A-CMBT Launching escape pod (A080)";break;}
                case "LowAmmoGatling":{block.SelectedSound = "A-CMBT Low ammo Gatling (A081)";break;}
                case "LowAmmoAutocannon":{block.SelectedSound = "A-CMBT Low ammo Autocannon (A082)";break;}
                case "LowAmmoAssaultCannon":{block.SelectedSound = "A-CMBT Low ammo Assault Cannon (A083)";break;}
                case "LowAmmoArtillery":{block.SelectedSound = "A-CMBT Low ammo Artillery (A084)";break;}
                case "LowAmmoRailgun":{block.SelectedSound = "A-CMBT Low ammo Railgun (A085)";break;}
                case "LowAmmoRockets":{block.SelectedSound = "A-CMBT Low ammo Rockets (A086)";break;}
                case "ReadyAssaultCannon":{block.SelectedSound = "A-CMBT Ready Assault Cannon (A087)";break;}
                case "ReadyArtilery":{block.SelectedSound = "A-CMBT Ready Artilery (A088)";break;}
                case "ReadyRailgun":{block.SelectedSound = "A-CMBT Ready Railgun (A089)";break;}
                case "WarheadActivate":{block.SelectedSound = "A-CMBT Warhead activate (A090)";break;}
                case "WarheadDeactivate":{block.SelectedSound = "A-CMBT Warhead deactivate (A091)";break;}
            //durability
                case "ThrustersDamaged":{block.SelectedSound = "A-DURB Thrusters damaged (A092)";break;}
                case "ThrustersDamagedReminder":{block.SelectedSound = "A-DURB Thrusters damaged reminder (A144)";break;}
                case "ThrustersRepaired":{block.SelectedSound = "A-DURB Thrusters repaired (A093)";break;}
                case "BatteriesDamaged":{block.SelectedSound = "A-DURB Batteries damaged (A094)";break;}
                case "BatteriesDamagedReminder":{block.SelectedSound = "A-DURB Batteries damaged reminder (A145)";break;}
                case "BatteriesRepaired":{block.SelectedSound = "A-DURB Batteries repaired (A095)";break;}
                case "HTanksDamaged":{block.SelectedSound = "A-DURB HTanks damaged (A096)";break;}
                case "HTanksDamagedReminder":{block.SelectedSound = "A-DURB HTanks damaged reminder (A146)";break;}
                case "HTanksRepaired":{block.SelectedSound = "A-DURB HTanks repaired (A097)";break;}
                case "OTanksDamaged":{block.SelectedSound = "A-DURB OTanks damaged (A098)";break;}
                case "OTanksDamagedReminder":{block.SelectedSound = "A-DURB OTanks damaged reminder (A147)";break;}
                case "OTanksRepaired":{block.SelectedSound = "A-DURB OTanks repaired (A099)";break;}
                case "CargoDamaged":{block.SelectedSound = "A-DURB Cargo damaged (A100)";break;}
                case "CargoDamagedReminder":{block.SelectedSound = "A-DURB Cargo damaged reminder (A148)";break;}
                case "CargoRepaired":{block.SelectedSound = "A-DURB Cargo repaired (A101)";break;}
                case "ConnectorsDamaged":{block.SelectedSound = "A-DURB Connectors damaged (A102)";break;}
                case "ConnectorsDamagedReminder":{block.SelectedSound = "A-DURB Connectors damaged reminder (A149)";break;}
                case "ConnectorsRepaired":{block.SelectedSound = "A-DURB Connectors repaired (A103)";break;}
                case "WeaponsDamaged":{block.SelectedSound = "A-DURB Weapons damaged (A104)";break;}
                case "WeaponsDamagedReminder":{block.SelectedSound = "A-DURB Weapons damaged reminder (A150)";break;}
                case "WeaponsRepaired":{block.SelectedSound = "A-DURB Weapons repaired (A105)";break;}
            //drones
                case "CargoDockedLoading":{block.SelectedSound = "A-DRON CargoD docked-Loading (A106)";break;}
                case "CargoDockedUnloading":{block.SelectedSound = "A-DRON CargoD docked-Unloading (A107)";break;}
                case "CargoUndockedWaypoint":{block.SelectedSound = "A-DRON CargoD undocked-Waypoint (A108)";break;}
                case "CargoUndockedResTrans":{block.SelectedSound = "A-DRON CargoD undocked-ResTrans (A109)";break;}
                case "CargoDDamaged":{block.SelectedSound = "A-DRON CargoD damaged (A110)";break;}
                case "MiningDockedOreUnload":{block.SelectedSound = "A-DRON MiningD docked-OreUnload (A111)";break;}
                case "MiningUndockedOreExtract":{block.SelectedSound = "A-DRON MiningD undocked-OreExtract (A112)";break;}
                case "MiningDamaged":{block.SelectedSound = "A-DRON MiningD damaged (A113)";break;}
                case "RefuelingDockedInOperation":{block.SelectedSound = "A-DRON RefuelingD docked-InOperation (A114)";break;}
                case "RefuelingUndockedFuelTrans":{block.SelectedSound = "A-DRON RefuelingD undocked-FuelTrans (A115)";break;}
                case "RefuelingUndockedReturn":{block.SelectedSound = "A-DRON RefuelingD undocked-Return (A116)";break;}
                case "RefuelingDamaged":{block.SelectedSound = "A-DRON RefuelingD damaged (A117)";break;}
                case "AssaultReady":{block.SelectedSound = "A-DRON AssaultD ready (A118)";break;}
                case "AssaultReturn":{block.SelectedSound = "A-DRON AssaultD return (A119)";break;}
                case "AssaultDamaged":{block.SelectedSound = "A-DRON AssaultD damaged (A120)";break;}
                case "DefenseEscortActivated":{block.SelectedSound = "A-DRON DefenseD escort activated (A121)";break;}
                case "DefensePatrolActivated":{block.SelectedSound = "A-DRON DefenseD patrol activated (A122)";break;}
                case "DefenseReturn":{block.SelectedSound = "A-DRON DefenseD return (A123)";break;}
                case "DefenseDamaged":{block.SelectedSound = "A-DRON DefenseD damaged (A124)";break;}
            //phrases
                case "CheckOxygenAndHydrogen":{block.SelectedSound = "A-PHRS Check oxygen and hydrogen (A125)";break;}
                case "Credits":{block.SelectedSound = "A-PHRS Credits (A126)";break;}
                case "KeepYourWeaponsReady":{block.SelectedSound = "A-PHRS Keep your weapons ready (A127)";break;}
                case "OreDetector":{block.SelectedSound = "A-PHRS Ore detector (A128)";break;}
                case "ScanningComplete1":{block.SelectedSound = "A-PHRS Scanning complete 1 (A129)";break;}
                case "ScanningComplete2":{block.SelectedSound = "A-PHRS Scanning complete 2 (A130)";break;}
                case "SuitIntegrityCheck":{block.SelectedSound = "A-PHRS Suit integrity check (A131)";break;}
                case "Tasks":{block.SelectedSound = "A-PHRS Tasks (A132)";break;}
            //greetings
                case "Greet":
                {
                    time = (int) System.DateTime.Now.ToBinary();
                    block.SelectedSound = Greetings[Math.Abs(time%11)];
                    break;
                }

                default:
                {
                    block.SelectedSound = argument;
                    break;
                }
            }
            for(int i=0;i<10000;i++){}
            block.Play();
            //block.SelectedSound = null;
            //LCD(argument);
        }

        /* void LCD(string note)
        {
        IMyTextSurface mesurface0 = Me.GetSurface(0);
                    mesurface0.ContentType = ContentType.TEXT_AND_IMAGE;
                    mesurface0.FontSize = 2;
                    mesurface0.Alignment = VRage.Game.GUI.TextPanel.TextAlignment.CENTER;
                    mesurface0.WriteText(note);
        } */
#region PreludeFooter
    }
}
#endregion
/*
A001    A-BSIC Airlock open
A002    A-BSIC Airlock close
A003    A-BSIC Doors open
A004    A-BSIC Doors close
A005    A-BSIC Hangar doors open
A006    A-BSIC Hangar doors close
A007    A-BSIC Lights on
A008    A-BSIC Lights off
A009    A-BSIC Objective started
A010    A-BSIC Objective complete
A011    A-BSIC Objective failed
A012    A-BSIC Systems online

A013    A-NOTS Fuel low
A014    A-NOTS Fuel critical
A015    A-NOTS Fuel restored
A016    A-NOTS Oxygen low
A017    A-NOTS Oxygen restored
A018    A-NOTS Battery low
A019    A-NOTS Battery critical
A020    A-NOTS Battery charged
A021    A-NOTS Energy consumption critical
A022    A-NOTS Cargo full
A023    A-NOTS Cargo emptied
A024    A-NOTS Ship overloaded
A025    A-NOTS EnShield charged
A026    A-NOTS EnShield critical
A027    A-NOTS Refinery final
A028    A-NOTS Refinery full
A029    A-NOTS Assembler full

A030    A-FLGT Thrusters engaged
A031    A-FLGT Thrusters deactivated
A032    A-FLGT Atmos thrusters engaged
A033    A-FLGT Atmos thrusters deactivated
A034    A-FLGT Atmos thrusters inefficient
A035    A-FLGT Hydro thrusters engaged
A036    A-FLGT Hydro thrusters deactivated
A037    A-FLGT Ion thrusters engaged
A038    A-FLGT Ion thrusters deactivated
A039    A-FLGT Ion thrusters inefficient
A040    A-FLGT Inertial thrusters activate
A041    A-FLGT Inertial thrusters deactivated
A042    A-FLGT Cruise control activate
A043    A-FLGT Cruise control deactivate
A044    A-FLGT Autopilot activate
A045    A-FLGT Autopilot deactivated
A046    A-FLGT Waypoint set
A047    A-FLGT Entering a gravity field
A048    A-FLGT Exiting gravity field
A049    A-FLGT Gravity field detected
A050    A-FLGT Gravity field left
A051    A-FLGT High speed
A052    A-FLGT Maximum speed reached
A053    A-FLGT Slow down
A054    A-FLGT Alt 100m
A055    A-FLGT Alt 500m
A056    A-FLGT Alt 1km
A057    A-FLGT Alt 2km
A058    A-FLGT Alt 10km
A059    A-FLGT Alt 20km
A060    A-FLGT Alt 30km

A061    A-WARP Warp drive charged
A062    A-WARP Warp Jump Countdown
A063    A-WARP Warp Jump successful
A064    A-WARP Warp Jump phrase

A065    A-PRKG Landing
A066    A-PRKG Landing emergency
A067    A-PRKG Landing gear extended
A068    A-PRKG Landing gear retracted
A069    A-PRKG Liftoff
A070    A-PRKG Docking
A071    A-PRKG Docking Cargo loading
A072    A-PRKG Docking Cargo unloading
A073    A-PRKG Docking Charging
A074    A-PRKG Docking Refueling
A075    A-PRKG Docking Phrase
A076    A-PRKG UnDocking

A077    A-CMBT Enemy detected
A078    A-CMBT Enemy on board
A079    A-CMBT Weapons systems ready
A080    A-CMBT Launching escape pod
A081    A-CMBT Low ammo Gatling
A082    A-CMBT Low ammo Autocannon
A083    A-CMBT Low ammo Assault Cannon
A084    A-CMBT Low ammo Artillery
A085    A-CMBT Low ammo Railgun
A086    A-CMBT Low ammo Rockets
A087    A-CMBT Ready Assault Cannon
A088    A-CMBT Ready Artilery
A089    A-CMBT Ready Railgun
A090    A-CMBT Warhead activate
A091    A-CMBT Warhead deactivate

A092    A-DURB Thrusters damaged
A144    A-DURB Thrusters damaged reminder
A093    A-DURB Thrusters repaired
A094    A-DURB Batteries damaged
A145    A-DURB Batteries damaged reminder
A095    A-DURB Batteries repaired
A096    A-DURB HTanks damaged
A146    A-DURB HTanks damaged reminder
A097    A-DURB HTanks repaired
A098    A-DURB OTanks damaged
A147    A-DURB OTanks damaged reminder
A099    A-DURB OTanks repaired
A100    A-DURB Cargo damaged
A148    A-DURB Cargo damaged reminder
A101    A-DURB Cargo repaired
A102    A-DURB Connectors damaged
A149    A-DURB Connectors damaged reminder
A103    A-DURB Connectors repaired
A104    A-DURB Weapons damaged
A150    A-DURB Weapons damaged reminder
A105    A-DURB Weapons repaired

A106    A-DRON CargoD docked-Loading
A107    A-DRON CargoD docked-Unloading
A108    A-DRON CargoD undocked-Waypoint
A109    A-DRON CargoD undocked-ResTrans
A110    A-DRON CargoD damaged
A111    A-DRON MiningD docked-OreUnload
A112    A-DRON MiningD undocked-OreExtract
A113    A-DRON MiningD damaged
A114    A-DRON RefuelingD docked-InOperation
A115    A-DRON RefuelingD undocked-FuelTrans
A116    A-DRON RefuelingD undocked-Return
A117    A-DRON RefuelingD damaged
A118    A-DRON AssaultD ready
A119    A-DRON AssaultD return
A120    A-DRON AssaultD damaged
A121    A-DRON DefenseD escort activated
A122    A-DRON DefenseD patrol activated
A123    A-DRON DefenseD return
A124    A-DRON DefenseD damaged

A125    A-PHRS Check oxygen and hydrogen
A126    A-PHRS Credits
A127    A-PHRS Keep your weapons ready
A128    A-PHRS Ore detector
A129    A-PHRS Scanning complete 1
A130    A-PHRS Scanning complete 2
A131    A-PHRS Suit integrity check
A132    A-PHRS Tasks

A133    A-GRNG Clr Greetings
A134    A-GRNG Greetings Funny 1
A135    A-GRNG Greetings Funny 2
A136    A-GRNG Greetings Funny 3
A137    A-GRNG Greetings Funny 4
A138    A-GRNG Greetings Funny 5
A139    A-GRNG Greetings Funny 6
A140    A-GRNG Greetings Phrase 1
A141    A-GRNG Greetings Phrase 2
A142    A-GRNG Greetings Phrase 3
A143    A-GRNG Greetings Phrase 4*/