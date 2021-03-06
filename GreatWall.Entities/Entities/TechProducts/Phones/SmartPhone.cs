﻿namespace GreatWall.Entities.Entities.TechProducts.Phones
{
    using System;
    using System.Text;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Exceptions;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class SmartPhone : Product, ISmartPhone
    {
        private string processor;
        private string ramMemory;
        private string internalMemory;
        private string displayType;
        private string displaySize;
        private string operationalSystem;
        private string simCardType;
        private string memorySlot;
        private string networkCompatibility;
        private int batteryCapacity;

        public SmartPhone(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory, string simCardType, string memorySlot, string networkCompatibility, int batteryCapacity, string procesor, string ramMemory, string internalMemory, string displayType, string displaySize, string operationalSystem)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.Processor = procesor;
            this.RamMemory = ramMemory;
            this.InternalMemory = internalMemory;
            this.DisplayType = displayType;
            this.DisplaySize = displaySize;
            this.OperationalSystem = operationalSystem;
            this.SimCardType = simCardType;
            this.MemorySlot = memorySlot;
            this.NetworkCompatibility = networkCompatibility;
            this.BatteryCapacity = batteryCapacity;
        }

        public string Processor
        {
            get
            {
                return this.processor;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.Processor)} is required!");
                }

                this.processor = value;
            }
        }

        public string RamMemory
        {
            get
            {
                return this.ramMemory;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.RamMemory)} is required!");
                }

                this.ramMemory = value;
            }
        }

        public string InternalMemory
        {
            get
            {
                return this.internalMemory;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.InternalMemory)} is required!");
                }

                this.internalMemory = value;
            }
        }

        public string DisplayType
        {
            get
            {
                return this.displayType;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.DisplayType)} is required!");
                }

                this.displayType = value;
            }
        }

        public string DisplaySize
        {
            get
            {
                return this.displaySize;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.DisplaySize)} is required!");
                }

                this.displaySize = value;
            }
        }

        public string OperationalSystem
        {
            get
            {
                return this.operationalSystem;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.OperationalSystem)} is required!");
                }

                this.operationalSystem = value;
            }
        }

        public string SimCardType
        {
            get
            {
                return this.simCardType;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.SimCardType)} is required!");
                }

                this.simCardType = value;
            }
        }

        public string MemorySlot
        {
            get
            {
                return this.memorySlot;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.MemorySlot)} is required!");
                }

                this.memorySlot = value;
            }
        }

        public string NetworkCompatibility
        {
            get
            {
                return this.networkCompatibility;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.NetworkCompatibility)} is required!");
                }

                this.networkCompatibility = value;
            }
        }

        public int BatteryCapacity
        {
            get
            {
                return this.batteryCapacity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new NegativeNumberException(nameof(this.BatteryCapacity));
                }

                this.batteryCapacity = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Processor: {this.Processor}");
            sb.AppendLine($"Ram Memory: {this.RamMemory}");
            sb.AppendLine($"Internal Memory: {this.InternalMemory}");
            sb.AppendLine($"Operational System: {this.OperationalSystem}");
            sb.AppendLine($"Display Size: {this.DisplaySize}");
            sb.AppendLine($"Display Type: {this.DisplayType}");
            sb.AppendLine($"Sim Card Type: {this.SimCardType}");
            sb.AppendLine($"Memory Slot: {this.MemorySlot}");
            sb.AppendLine($"Network Compatibility: {this.NetworkCompatibility}");
            sb.AppendLine($"Battery Capacity: {this.BatteryCapacity}");

            return sb.ToString();
        }
    }
}
