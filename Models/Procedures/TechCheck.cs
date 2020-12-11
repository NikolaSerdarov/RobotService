using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class TechCheck : Procedure
    {
        public TechCheck()
        {
        }
        //TechCheck – removes 8 energy and checks current robot (set IsChecked to true). If robot is already checked, just remove 8 energy again. 
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            if (!robot.IsChecked)
            {
                robot.IsChecked = true;
            }
            robot.Energy -= 8;
            robot.ProcedureTime -= procedureTime;
        }
    }
}
