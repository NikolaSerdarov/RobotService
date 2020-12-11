using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures.Contracts
{
    public abstract class Procedure : IProcedure
    {
        private List<IRobot> robots;
        public Procedure()
        {
            robots = new List<IRobot>();
        }
        public IReadOnlyCollection<IRobot> Robots { get => robots.AsReadOnly(); }
        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {

                throw new ArgumentException(message: ExceptionMessages.InsufficientProcedureTime);
            }
            this.robots.Add(robot);
        }


        public string History()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Robot robot in Robots)
            {
                sb.AppendLine($"{typeof(Procedure)}");
                sb.AppendLine($"Robot type: {robot.GetType().Name} - {robot.Name} - Happiness: {robot.Happiness} - Energy: {robot.Energy}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
