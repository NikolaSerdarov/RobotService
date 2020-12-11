using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int capacity = 10;
        private readonly Dictionary<string, IRobot> robots;
        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots { get => robots; private set { } }

        public void Manufacture(IRobot robot)
        {
            
            if (Robots.Count >= capacity)
            {
                throw new InvalidOperationException(message: ExceptionMessages.NotEnoughCapacity);
            }
            if (Robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(message: String.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }
            robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(message: String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot currRobot = this.Robots.GetValueOrDefault(robotName);
            currRobot.Owner = ownerName;
            currRobot.IsBought = true;
            robots.Remove(robotName);
        }
    }
}
