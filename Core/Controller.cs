using RobotService.Models.Robots;
using RobotService.Utilities.Messages;
using RobotService.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Core.Contracts
{
    public class Controller : IController
    {
        private Garage garage;
        private IProcedure charge;
        private IProcedure chip;
        private IProcedure polish;
        private IProcedure rest;
        private IProcedure techCheck;
        private IProcedure work;

        public Controller()
        {
            this.garage = new Garage();
            this.charge = new Charge();
            this.chip = new Chip();
            this.polish = new Polish();
            this.rest = new Rest();
            this.techCheck = new TechCheck();
            this.work = new Work();
        }
        public string Charge(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot currentRobot = garage.Robots.GetValueOrDefault(robotName);
            charge.DoService(currentRobot, procedureTime);
            string result = $"{currentRobot.Name} had charge procedure";
            return result;
        }

        public string Chip(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot currentRobot = garage.Robots.GetValueOrDefault(robotName);
            chip.DoService(currentRobot, procedureTime);
            string result = $"{currentRobot.Name} had chip procedure";
            return result;
        }

        public string History(string procedureType)
        {
            string result = null;
            if (procedureType == "Chip")
            {
                result = chip.History();
            }
            else if (procedureType == "Charge")
            {
                result = charge.History();
            }
            else if (procedureType == "Rest")
            {
                result = rest.History();
            }
            else if (procedureType == "Polish")
            {
                result = polish.History();
            }
            else if (procedureType == "Work")
            {
                result = work.History();
            }
            else if (procedureType == "TechCheck")
            {
                result = techCheck.History();
            }
            return result;
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robotCurrent;
            if (robotType == "HouseholdRobot")
            {
                robotCurrent = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "WalkerRobot")
            {
                robotCurrent = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "PetRobot")
            {
                robotCurrent = new PetRobot(name, energy, happiness, procedureTime);
            }
            else
            {

                throw new ArgumentException(message: String.Format(ExceptionMessages.InvalidRobotType, robotType));
            }
            garage.Manufacture(robotCurrent);

            return String.Format(OutputMessages.RobotManufactured, robotType);
        }

        public string Polish(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot currentRobot = garage.Robots.GetValueOrDefault(robotName);
            polish.DoService(currentRobot, procedureTime);
            string result = $"{currentRobot.Name} had polish procedure";
            return result;
        }

        public string Rest(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot currentRobot = garage.Robots.GetValueOrDefault(robotName);
            IProcedure rest = new Chip();
            rest.DoService(currentRobot, procedureTime);
            string result = $"{currentRobot.Name} had rest procedure";
            return result;
        }

        public string Sell(string robotName, string ownerName)
        {
            string result;
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot currentRobot = garage.Robots.GetValueOrDefault(robotName);
            if (currentRobot.IsChipped == true)
            {
                result = $"{ownerName} bought robot with chip";
            }
            else
            {
                result = $"{ownerName} bought robot without chip";
            }
            return result;
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot currentRobot = garage.Robots.GetValueOrDefault(robotName);
            techCheck.DoService(currentRobot, procedureTime);
            string result = $"{currentRobot.Name} had tech check procedure";
            return result;
        }

        public string Work(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot currentRobot = garage.Robots.GetValueOrDefault(robotName);
            work.DoService(currentRobot, procedureTime);
            string result = $"{currentRobot.Name} was working for {procedureTime} hours";
            return result;
        }
    }
}
