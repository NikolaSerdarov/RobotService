using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class Rest : Procedure
    {
        public Rest()
        {
        }
        //Rest – removes 3 happiness and adds 10 energy 
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Happiness -= 3;
            robot.Energy += 10;
            robot.ProcedureTime -= procedureTime;
        }
    }
}
