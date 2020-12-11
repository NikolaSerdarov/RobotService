using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private string name;
        private int happiness;
        private int energy;
        private int procedureTime;
        private string owner = "Service";
        private bool isBought = false;
        private bool isChipped = false;
        private bool isChecked = true;
        public Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
        }
        public string Name
        {
            get => this.name;
            protected set
            {
                this.name = value;
            }
        }

        public int Happiness
        {
            get => this.happiness;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(message: ExceptionMessages.InvalidHappiness);
                }
                happiness = value;
            }

        }
        public int Energy
        {
            get => this.energy;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(message: ExceptionMessages.InvalidEnergy);
                }
                this.energy = value;
            }
        }
        public int ProcedureTime
        {
            get => this.procedureTime;
            set
            {
                this.procedureTime = value;
            }
        }
        public string Owner
        {
            get => this.owner;
            set { }
        }
        public bool IsBought
        {
            get => this.isBought;
            set { }
        }
        public bool IsChipped
        {
            get => this.isChipped;
            set { }
        }
        public bool IsChecked
        {
            get => this.IsChecked;
            set { }
        }
        public override string ToString()
        {
            return $" Robot type: {typeof(Robot)} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
