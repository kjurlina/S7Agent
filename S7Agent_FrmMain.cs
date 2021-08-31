using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Sharp7;

namespace S7Agent
{
    // ATO Engineering d.o.o. S7 data logger
    // Thank you Davide Nardella for Snap7 (Sharp7)
    // Coding by kjurlina. Have a lot of fun

    public partial class S7Agent_FrmMain : Form
    {
        S7Client Client;
        byte[] Buffer = new byte[65536];
        string[,] dataArray = new string[744, 6];
        string[] dataArrayCSV = new string[744];
        int Rack;
        int Slot;
        int SingleRecordSize;
        int DataBlockSize;
        int NumberOfValues;
        bool MinuteTick;
        bool MinuteTickDone;
        bool HourTick;
        bool HourTickDone;
        bool DayTick;
        bool DayTickDone;
        bool MonthTick;
        bool MonthTickDone;
        bool YearTick;
        bool YearTickDone;

        //CultureInfo.CurrentCulture = new CultureInfo();
        DateTimeFormatInfo DTFormat = CultureInfo.GetCultureInfo("hr-HR").DateTimeFormat;

        public S7Agent_FrmMain()
        {
            // Initialize component
            InitializeComponent();

            // S7Agent timer (500ms resolution)
            Timer Metronome = new Timer();
            Metronome.Tick += new EventHandler(Metronome_Tick);
            Metronome.Interval = 500;
            Metronome.Start();

            // UI event handlers
            IOValues.ValueChanged += new EventHandler(IOValues_ValueChanged);
            IOFamily.SelectedIndexChanged += new EventHandler(IOFamily_SelectedIndexChanged);

            // Initialize S7 Client
            Client = new S7Client();
            Initialize();
        }

        private void Initialize()
        {
            // Kill all periodic trigger markers
            MinuteTick = false;
            MinuteTickDone = false;
            HourTick = false;
            HourTickDone = false;
            DayTick = false;
            DayTickDone = false;
            MonthTick = false;
            MonthTickDone = false;
            YearTick = false;
            YearTickDone = false;

            // Recalculate connection & DB parameters
            IOFamily.SelectedIndex = 0;
            Rack = 0;
            Slot = 0;
            SingleRecordSize = 8 + (int)(IOValues.Value) * 4;
            DataBlockSize = SingleRecordSize * 744;
            IODBSize.Text = DataBlockSize.ToString();
            NumberOfValues = (int)IOValues.Value;

        }

        private void Connect()
        {
            // Spoji se na PLC
            try
            {
                int PLCStatus = Client.ConnectTo(IOAddress.Text, Rack, Slot);
                ShowPLCStatus(PLCStatus);
                if (PLCStatus == 0)
                {
                    IOConnectionState.Image = Properties.Resources.ImgOKSmall;
                }
                else
                {
                    IOConnectionState.Image = Properties.Resources.ImgNotOKSmall;
                }
            }
            catch (Exception ex)
            {
                // Kad se isprogramira logiranje maknuti message box
                MessageBox.Show(ex.Message);
            }

        }

        private void Read()
        {
            // Pocisti buffer iza sebe
            Array.Clear(Buffer, 0, Buffer.Length);

            // Procitaj podatke sa PLC-a
            try
            {
                int Size = Convert.ToInt32(IODBSize.Text);
                int Result = Client.DBRead(Convert.ToInt32(IODB.Text), 0, Size, Buffer);
                ShowPLCStatus(Result);
                if (Result == 0)
                {
                    Interpret(Buffer, Size);
                }
            }
            catch (Exception ex)
            {
                // Kad se isprogramira logiranje maknuti message box
                MessageBox.Show(ex.Message);
            }

        }

        private void Interpret(byte[] bytes, int size)
        {
            int hourIndex;

            if (bytes == null) return;

            // Pocisti buffer
            Array.Clear(dataArray, 0, dataArray.Length);
            Array.Clear(dataArrayCSV, 0, dataArrayCSV.Length);

            byte[] bTSYear = new byte[2];
            byte[] bTSMonth = new byte[2];
            byte[] bTSDay = new byte[2];
            byte[] bTSHour = new byte[2];
            byte[] bTSMinute = new byte[2];
            byte[] bTSSecond = new byte[2];
            byte[] bValue1 = new byte[4];
            byte[] bValue2 = new byte[4];
            byte[] bValue3 = new byte[4];
            byte[] bValue4 = new byte[4];
            byte[] bValue5 = new byte[4];

            for (hourIndex = 0; hourIndex <= 743; hourIndex++)
            {
                int pointer = hourIndex * SingleRecordSize;

                bTSYear[0] = bytes[pointer + 1];
                bTSYear[1] = bytes[pointer + 0];

                bTSMonth[0] = bytes[pointer + 2];
                bTSMonth[1] = 0;

                bTSDay[0] = bytes[pointer + 3];
                bTSDay[1] = 0;

                bTSHour[0] = bytes[pointer + 4];
                bTSHour[1] = 0;

                bTSMinute[0] = bytes[pointer + 5];
                bTSMinute[1] = 0;

                bTSSecond[0] = bytes[pointer + 6];
                bTSSecond[1] = 0;

                int TSYear = System.BitConverter.ToInt16(bTSYear, 0);
                int TSMonth = System.BitConverter.ToInt16(bTSMonth, 0);
                int TSDay = System.BitConverter.ToInt16(bTSDay, 0);
                int TSHour = System.BitConverter.ToInt16(bTSHour, 0);
                int TSMinute = System.BitConverter.ToInt16(bTSMinute, 0);
                int TSSecond = System.BitConverter.ToInt16(bTSSecond, 0);
                string TS = TSDay.ToString() + '.' + TSMonth.ToString() + '.' + TSYear.ToString() + ' ' + TSHour.ToString() + ":" + TSMinute.ToString() + ":" + TSSecond.ToString();
                dataArray[hourIndex, 0] = TS;
                dataArrayCSV[hourIndex] = TS;

                if (NumberOfValues >= 1)
                {
                    bValue1[0] = bytes[pointer + 11];
                    bValue1[1] = bytes[pointer + 10];
                    bValue1[2] = bytes[pointer + 9];
                    bValue1[3] = bytes[pointer + 8];
                    float Value1 = (float)Math.Round(System.BitConverter.ToSingle(bValue1, 0), 2);
                    string VAL1 = Value1.ToString();
                    dataArray[hourIndex, 1] = VAL1;
                    dataArrayCSV[hourIndex] += ";" + VAL1;
                }
                if (NumberOfValues >= 2)
                {
                    bValue2[0] = bytes[pointer + 15];
                    bValue2[1] = bytes[pointer + 14];
                    bValue2[2] = bytes[pointer + 13];
                    bValue2[3] = bytes[pointer + 12];
                    float Value2 = (float)Math.Round(System.BitConverter.ToSingle(bValue2, 0), 2);
                    string VAL2 = Value2.ToString();
                    dataArray[hourIndex, 2] = VAL2;
                    dataArrayCSV[hourIndex] += ";" + VAL2;
                }
                if (NumberOfValues >= 3)
                {
                    bValue3[0] = bytes[pointer + 19];
                    bValue3[1] = bytes[pointer + 18];
                    bValue3[2] = bytes[pointer + 17];
                    bValue3[3] = bytes[pointer + 16];
                    float Value3 = (float)Math.Round(System.BitConverter.ToSingle(bValue3, 0), 2);
                    string VAL3 = Value3.ToString();
                    dataArray[hourIndex, 3] = VAL3;
                    dataArrayCSV[hourIndex] += ";" + VAL3;
                }
                if (NumberOfValues >= 4)
                {
                    bValue4[0] = bytes[pointer + 23];
                    bValue4[1] = bytes[pointer + 22];
                    bValue4[2] = bytes[pointer + 21];
                    bValue4[3] = bytes[pointer + 20];
                    float Value4 = (float)Math.Round(System.BitConverter.ToSingle(bValue4, 0), 2);
                    string VAL4 = Value4.ToString();
                    dataArray[hourIndex, 4] = VAL4;
                    dataArrayCSV[hourIndex] += ";" + VAL4;
                }
                if (NumberOfValues >= 5)
                {
                    bValue5[0] = bytes[pointer + 27];
                    bValue5[1] = bytes[pointer + 26];
                    bValue5[2] = bytes[pointer + 25];
                    bValue5[3] = bytes[pointer + 24];
                    float Value5 = (float)Math.Round(System.BitConverter.ToSingle(bValue5, 0), 2);
                    string VAL5 = Value5.ToString();
                    dataArray[hourIndex, 5] = VAL5;
                    dataArrayCSV[hourIndex] += ";" + VAL5;
                }
            }
        }

        private void Disconnect()
        {
            // Odspoji se sa PLC-a
            try
            {
                IOConnectionState.Image = Properties.Resources.ImgTransparent;
                int PLCStatus = Client.Disconnect();
                ShowPLCStatus(PLCStatus);
            }
            catch (Exception ex)
            {
                // Kad se isprogramira logiranje maknuti message box
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowPLCStatus(int PLCStatus)
        {
            // This function returns a textual explaination of the error code
            if (PLCStatus > 0)
            {
                S7Agent_StatusStrip.Items[1].Text = "Last PLC activity error: " + Client.ErrorText(PLCStatus) + " at " + DateTime.Now.ToString();
                IOConnectionState.Image = Properties.Resources.ImgNotOKSmall;
            }
            else if (PLCStatus == 0)
            {                
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void IOValues_ValueChanged(object sender, EventArgs e)
        {
            // Check boundaries
            if (IOValues.Value > 5)
            {
                IOValues.Value = 5;
                NumberOfValues = 5;
                MessageBox.Show("Makksimum je 5 podataka!");
            }
            else if (IOValues.Value < 1)
            {
                IOValues.Value = 1;
                NumberOfValues = 1;
                MessageBox.Show("Minimum je jedan podatak...");
            }
            else
            {
                NumberOfValues = (int)(IOValues.Value);
                SingleRecordSize = 8 + (int)(IOValues.Value) * 4;
                DataBlockSize = SingleRecordSize * 744;
                IODBSize.Text = DataBlockSize.ToString();
            }
        }

        private void IOFamily_SelectedIndexChanged (object sender, EventArgs e)
        {
            // Set new rack/slot varaibles
            if (IOFamily.SelectedIndex >= 0 && IOFamily.SelectedIndex <= 1)
            {
                Rack = 0;
                Slot = 0;
            }
            else if (IOFamily.SelectedIndex >= 2 && IOFamily.SelectedIndex <= 3)
            {
                Rack = 0;
                Slot = 2;
            }
            else
            {
                Rack = 0;
                Slot = 0;
                MessageBox.Show("Wrong PLC family. That is odd...");
            }
        }

        private void Metronome_Tick(object sender, EventArgs e)
        {
            // Zapamti cijeli tick vremenski zig (da se ne cita DateTime.Now u kodu) i osvjezi sat
            DateTime tickTimeStamp = DateTime.Now;
            S7Agent_StatusStrip.Items[0].Text = DateTime.Now.ToString();

            // Ukoliko je prosao tick nulte sekunde resetiraj flagove periodickih zadataka
            if (tickTimeStamp.Second > 0)
            {
                MinuteTickDone = false;
                HourTickDone = false;
                DayTickDone = false;
                MonthTickDone = false;
                YearTickDone = false;
            }

            // Prozovi periodicke zadatak i postavi flag kada su izvrseni
            if (MinuteTickDone == false && tickTimeStamp.Second == 0)
            {
                MinuteTick = true;
            }
            if (HourTickDone == false && tickTimeStamp.Second == 0 && tickTimeStamp.Minute == 0)
            {
                HourTick = true;
            }
            if (DayTickDone == false && tickTimeStamp.Second == 0 && tickTimeStamp.Minute == 0 && tickTimeStamp.Hour == 0)
            {
                DayTick = true;
            }
            if (MonthTickDone == false && tickTimeStamp.Second == 0 && tickTimeStamp.Minute == 0 && tickTimeStamp.Hour == 0 && tickTimeStamp.Day == 1)
            {
                MonthTick = true;
            }
            if (YearTickDone == false && tickTimeStamp.Second == 0 && tickTimeStamp.Minute == 0 && tickTimeStamp.Hour == 0 && tickTimeStamp.Day == 1 && tickTimeStamp.Month == 1)
            {
                YearTick = true;
            }

            // Ukoliko je bilo koji periodicki task okinut procitaj podatke iz PLC-a
            if (MinuteTick || HourTick || DayTick || MonthTick || YearTick)
            {
                FullReadSequence();

                if (MinuteTick) MinuteTask();
                if (HourTick) HourTask();
                if (DayTick) DayTask();
                if (MonthTick) MonthTask();
                if (YearTick) YearTask();
            }
        }

        private void FullReadSequence()
        {
            // Spoji se, procitaj podatke i odspoji se
            Connect();
            Read();
            Disconnect();
        }

        private void MinuteTask()
        {
            // Postavi kontrolni bit da je task izvrsen
            MinuteTick = false;
            MinuteTickDone = true;

            // Upisi vrijednosti u CSV
            WriteCSV(dataArrayCSV);

            // Kasnije upisi u log negdje
            // ioDump.Text += "Minutni zadatak se izvršio u " + DateTime.Now.ToString(DTFormat) + "\r\n";
        }

        private void HourTask()
        {
            // Postavi kontrolni bit da je task izvrsen
            HourTick = false;
            HourTickDone = true;

            // Kasnije upisi u log negdje
            // ioDump.Text += "Satni zadatak se izvršio u " + DateTime.Now.ToString(DTFormat) + "\r\n";
        }

        private void DayTask()
        {
            // Postavi kontrolni bit da je task izvrsen
            DayTick = false;
            DayTickDone = true;

            // Kasnije upisi u log negdje
            // ioDump.Text += "Dnevni zadatak se izvršio u " + DateTime.Now.ToString(DTFormat) + "\r\n";
        }

        private void MonthTask()
        {
            // Postavi kontrolni bit da je task izvrsen
            MonthTick = false;
            MonthTickDone = true;

            // Kasnije upisi u log negdje
            // ioDump.Text += "Mjesečni zadatak se izvršio u " + DateTime.Now.ToString(DTFormat) + "\r\n";
        }

        private void YearTask()
        {
            // Postavi kontrolni bit da je task izvrsen
            YearTick = false;
            YearTickDone = true;

            // Kasnije upisi u log negdje
            // ioDump.Text += "Godišnji zadatak se izvršio u " + DateTime.Now.ToString(DTFormat) + "\r\n";
        }

        private void WriteCSV(string[] dataArrayCSV)
        {
            // Only test
            System.IO.File.AppendAllLines("d:\\file.csv", dataArrayCSV);
        }

    }
}
