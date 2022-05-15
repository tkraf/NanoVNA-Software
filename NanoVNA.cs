using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoVNA_Software
{
    internal class NanoVNA
    {
        private System.IO.Ports.SerialPort _serialPort;

        //Designating Constructor
        public NanoVNA(string port)
        {
            _serialPort = new System.IO.Ports.SerialPort(port);
        }

        //Designating Properties
        public string COMPort
        {
            get { return _serialPort.PortName; }
            set { _serialPort.PortName = value; }
        }

        public int BaudRate
        {
            get { return _serialPort.BaudRate; }
            set { _serialPort.BaudRate = value; }
        }

        //Designating Methods
        private void SendCommand(byte Command)
        {
            var dataArray = new byte[] {Command};

            _serialPort.Open();
            _serialPort.Write(dataArray, 0, 1);
            _serialPort.Close();
        }

        private void SendArray(byte[] Array, int Values)
        {
            _serialPort.Open();
            _serialPort.Write(Array, 0, Values);
            _serialPort.Close();
        }

        /// <summary>
        /// No Operation
        /// </summary>
        public void NOP()
        {
            SendCommand(0x00);
        }

        /// <summary>
        /// Device always replies with ASCII '2'
        /// </summary>
        public void Indicate()
        {
            SendCommand(0x0d);
        }

        /// <summary>
        /// Read a 4 byte register
        /// </summary>
        /// <param name="Address">Start address of register</param>
        public void ReadByte(byte Address)
        {
            var dataArray = new byte[] { 0x10, Address };
            SendArray(dataArray, 2);
        }

        /// <summary>
        /// Read a 4 byte register
        /// </summary>
        /// <param name="Address">Start address of register</param>
        public void Read2Byte(byte Address)
        {
            var dataArray = new byte[] { 0x11, Address };
            SendArray(dataArray, 2);
        }

        /// <summary>
        /// Read a 4 byte register
        /// </summary>
        /// <param name="Address">Start address of register</param>
        public void Read4Byte(byte Address)
        {
            var dataArray = new byte[] { 0x12, Address };
            SendArray(dataArray, 2);
        }

        /// <summary>
        /// Read from a FIFO register
        /// </summary>
        /// <param name="StartAddress">Start Address to read from</param>
        /// <param name="Bytes">Number of bytes to read</param>
        public void ReadFIFO(byte StartAddress, byte Bytes)
        {
            var dataArray = new byte[] {0x18, StartAddress, Bytes};
            SendArray(dataArray, 3);
        }

        /// <summary>
        /// Write bytes to NanoVNA
        /// </summary>
        /// <param name="Address">Address to be Written</param>
        /// <param name="Value1">1st Value to be Written</param>
        public void WriteBytes(byte Address, byte Value)
        {
            var dataArray = new byte[] {0x20, Address, Value};
            SendArray(dataArray, 3);
        }

        /// <summary>
        /// Write bytes to NanoVNA
        /// </summary>
        /// <param name="Address">Address to be Written</param>
        /// <param name="Value1">1st Value to be Written</param>
        /// <param name="Value2">2nd Value to be Written</param>
        public void WriteBytes(byte Address, byte Value1, byte Value2)
        {
            var dataArray = new byte[] {0x21, Address, Value1, Value2};
            SendArray(dataArray, 4);
        }

        /// <summary>
        /// Write bytes to NanoVNA
        /// </summary>
        /// <param name="Address">Address to be Written</param>
        /// <param name="Value1">1st Value to be Written</param>
        /// <param name="Value2">2nd Value to be Written</param>
        /// <param name="Value3">3rd Value to be Written</param>
        /// <param name="Value4">4th Value to be Written</param>
        public void WriteBytes(byte Address, byte Value1, byte Value2, byte Value3, byte Value4)
        {
            var dataArray = new byte[] {0x22, Address, Value1, Value2, Value3, Value4};
            SendArray(dataArray, 6);
        }

        /// <summary>
        /// Write bytes to NanoVNA
        /// </summary>
        /// <param name="Address">Address to be Written</param>
        /// <param name="Value1">1st Value to be Written</param>
        /// <param name="Value2">2nd Value to be Written</param>
        /// <param name="Value3">3rd Value to be Written</param>
        /// <param name="Value4">4th Value to be Written</param>
        /// <param name="Value5">5th Value to be Written</param>
        /// <param name="Value6">6th Value to be Written</param>
        /// <param name="Value7">7th Value to be Written</param>
        /// <param name="Value8">8th Value to be Written</param>
        public void WriteBytes(byte Address, byte Value1, byte Value2, byte Value3, byte Value4, byte Value5, byte Value6, byte Value7, byte Value8)
        {
            var dataArray = new byte[] {0x23, Address, Value1, Value2, Value3, Value4, Value5, Value6, Value7, Value8};
            SendArray(dataArray, 10);
        }

        /// <summary>
        /// Write bytes into a FIFO
        /// </summary>
        /// <param name="Address">FIFO Start Address</param>
        /// <param name="Values">Values to be Written</param>
        /// <param name="Length">Number of Values</param>
        public void WriteFIFO(byte Address, byte[] Values, int Length)
        {
            var dataArray = new byte[] { 0x28, Address };
            dataArray.Concat(Values);
            SendArray(dataArray, Length + 2);
        }
    }
}
