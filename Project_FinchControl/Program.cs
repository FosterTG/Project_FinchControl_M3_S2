using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, and the menu
    // Application Type: Console
    // Authors: Velis, John / Gilmore, Foster
    // Dated Created: 1/22/2020 
    // Last Modified: 2/22/2021
    //
    // **************************************************

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayMenuScreen(finchRobot);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(finchRobot);
                        break;

                    case "d":

                        break;

                    case "e":

                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void TalentShowDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound (Wind Up and Down");
                Console.WriteLine("\tb) Dance (Finch Dance)");
                Console.WriteLine("\tc) Mixing it Up (Drag Race)");
                Console.WriteLine("\td) Your Finch");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        TalentShowDisplayLightAndSound(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayDance(finchRobot);
                        break;

                    case "c":
                        TalantShowDisplayMixItUp(finchRobot);
                        break;

                    case "d":
                        
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// 

        static void TalentShowDisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will now show off its glowing talent!");
            DisplayContinuePrompt();
            // Light wind up and down Red
            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                finchRobot.setLED(lightSoundLevel, 0, 0);
                finchRobot.noteOn(lightSoundLevel * 20);
            }
            for (int lightSoundLevel = 255; lightSoundLevel > 1; lightSoundLevel--)
            {
                finchRobot.setLED(lightSoundLevel, 0, 0);
                finchRobot.noteOn(lightSoundLevel * 20);
            }
            // Light wind Up and Down Green
            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                finchRobot.setLED(0, lightSoundLevel, 0);
                finchRobot.noteOn(lightSoundLevel * 50);
            }
            for (int lightSoundLevel = 255; lightSoundLevel > 1; lightSoundLevel--)
            {
                finchRobot.setLED(0, lightSoundLevel, 0);
                finchRobot.noteOn(lightSoundLevel * 50);
            }
            // Light wind Up and Down Blue
            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                finchRobot.setLED(0, 0, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 100);
            }
            for (int lightSoundLevel = 255; lightSoundLevel > 1; lightSoundLevel--)
            {
                finchRobot.setLED(0, 0, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 100);
            }



            //Stop
            finchRobot.setMotors(0, 0);
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();
            DisplayMenuPrompt("Talent Show Menu");
        }

        static void TalentShowDisplayDance(Finch finchRobot)
        {
            
            /// *****************************************************************
            /// *               Talent Show > Dance                             *
            /// *****************************************************************
            /// </This method directs the finch to perform a dance>

            Console.CursorVisible = false;
            
            DisplayScreenHeader("Dance");

            Console.WriteLine("\tThe Finch robot will now show off its dance!");
            DisplayContinuePrompt();

            //Move Backwards 0.5s
            finchRobot.setMotors(-255, -255);
            finchRobot.wait(500);

            //Move Forwards 0.5s
            finchRobot.setMotors(255, 255);
            finchRobot.wait(500);

            //Turn Left 1s
            finchRobot.setMotors(-30, 255);
            finchRobot.wait(1000);

            //Turn Right 1s
            finchRobot.setMotors(255, -30);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 0);

            //Move Forwards 0.5s
            finchRobot.setMotors(255, 255);
            finchRobot.wait(500);

            //Move Backwards 0.5s
            finchRobot.setMotors(-255, -255);
            finchRobot.wait(500);

            
            //Stop
            finchRobot.setMotors(0, 0);
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            DisplayMenuPrompt("Talent Show Menu");
        }

        static void TalantShowDisplayMixItUp(Finch finchRobot)
        {
            /// *****************************************************************
            /// *               Talent Show > Mix it Up (Drag Race)             *
            /// *****************************************************************
            /// </This method directs the finch to perform a Dance, Light, and Sound in a drag race>

            Console.CursorVisible = false;

            DisplayScreenHeader("Mixing it Up");

            Console.WriteLine("\tThe Finch robot will now perform a drag race!");
            DisplayContinuePrompt();

            //Ready
            finchRobot.setLED(255, 0, 0);
            finchRobot.noteOn(1600);
            finchRobot.wait(700);
            finchRobot.noteOn(0);
            finchRobot.setLED(0, 0, 0);
            //Ready
            finchRobot.setLED(255, 0, 0);
            finchRobot.noteOn(1600);
            finchRobot.wait(700);
            finchRobot.noteOn(0);
            finchRobot.setLED(0, 0, 0);
            //Ready
            finchRobot.setLED(255, 200, 0);
            finchRobot.noteOn(1600);
            finchRobot.wait(700);
            finchRobot.noteOn(0);
            finchRobot.setLED(0, 0, 0);
            //GO
            finchRobot.setLED(0, 255, 0);
            finchRobot.noteOn(2500);
            finchRobot.wait(200);
            finchRobot.noteOn(0);
            finchRobot.setLED(0, 0, 0);
            
            //First Gear
            for (int acceleration = 30; acceleration < 85; acceleration++)
            {
                finchRobot.setMotors(acceleration, acceleration);
                
            }
            finchRobot.noteOn(2000);
            finchRobot.noteOn(0);
            //Second Gear
            for (int acceleration = 85; acceleration < 170; acceleration++)
            {
                finchRobot.setMotors(acceleration, acceleration);
                
            }
            finchRobot.noteOn(2000);
            finchRobot.noteOn(0);
            //Third Gear
            for (int acceleration = 170; acceleration < 255; acceleration++)
            {
                finchRobot.setMotors(acceleration, acceleration);
                
            }
            finchRobot.noteOn(1000);
            finchRobot.noteOn(0);
            // Drive On for 2s
            finchRobot.wait(2000);

            // Victory Spin sound and Light
            finchRobot.setMotors(-255, 255);
            finchRobot.wait(2000);

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel+=3)
            {
                finchRobot.setLED(lightSoundLevel, 30, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 100);
            }
            finchRobot.setLED(0, 0, 0);

            //Stop
            finchRobot.setMotors(0, 0);
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();
            DisplayMenuPrompt("Talent Show Menu");
        }



        #endregion

        #region Data Recorder

        static void DataRecorderDisplayMenuScreen(Finch finchRobot)
        {

            int numberOfDataPoints = 0;
            double dataPointFrequancy = 0;
            double[] tempratures = null;

            Console.CursorVisible = true;

            bool quitDataRecorderMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of data points");
                Console.WriteLine("\tb) Frequancy of data points");
                Console.WriteLine("\tc) Get data");
                Console.WriteLine("\td) Show Data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = DataRecorderDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequancy = DataRecorderDisplayGetFrequancyOfDataPoints();
                        break;

                    case "c":
                        tempratures = DataRecorderDisplayGetData(numberOfDataPoints, dataPointFrequancy, finchRobot);
                        break;

                    case "d":
                        DataRecorderDisplayData(tempratures, numberOfDataPoints, dataPointFrequancy);
                        break;

                    case "q":
                        quitDataRecorderMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitDataRecorderMenu);

        }

        static void DataRecorderDisplayData(double[] tempratures, int numberOfDataPoints, double dataPointFrequancy)
        {

            DisplayScreenHeader("SHow Data");
            //
            //display table haeaders

            Console.WriteLine(
                "Recording #".PadLeft(15) +
                "Temprature".PadLeft(15));
            Console.WriteLine(
                "-------------".PadLeft(15) +
                "----------".PadLeft(15));

            //
            // display table data 

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                Console.WriteLine(
                (index + 1).ToString().PadLeft(15) +
                tempratures[index].ToString("n2").PadLeft(15));
            }

            DisplayContinuePrompt();

        }

        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequancy, Finch finchRobot)
        {

            double[] tempratures = new double[numberOfDataPoints];

            DisplayScreenHeader("Get Data");

            Console.WriteLine($"Number of data points: {numberOfDataPoints}");
            Console.WriteLine($"Data point frequancy: {dataPointFrequancy}");
            Console.WriteLine();
            Console.WriteLine("\tThe finch Robot is ready to collect temprature data");
            DisplayContinuePrompt();

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                tempratures[index] = finchRobot.getTemperature();
                Console.WriteLine($"\tReading {index + 1}: {tempratures[index].ToString("n2")}:");
                int waitInSeconds = (int)(dataPointFrequancy * 1000);
                finchRobot.wait(waitInSeconds);

            }


            DisplayContinuePrompt();
            return tempratures;
        }

        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            /// <summary>
            /// Get Number of Data Points From the User. 
            /// </summary>
            /// <returns> Number of Data points </returns>
            /// 
            int numberOfDataPoints;
            string userResponse;
            bool validResponse = true;
            DisplayScreenHeader("Number of Data Points");

            do
            {
                Console.Write("\tEnter Number of Data Points: ");
                userResponse = Console.ReadLine();
                validResponse = int.TryParse(userResponse, out numberOfDataPoints);

                if (!validResponse)
                {
                    Console.WriteLine("\tPlease enter a valid response.");
                }

            } while (!validResponse);

            DisplayContinuePrompt();
            return numberOfDataPoints;

        }

        static double DataRecorderDisplayGetFrequancyOfDataPoints()
        {

            /// <summary>
            /// Get Frequancy From the User. 
            /// </summary>
            /// <returns> Frequancy Set </returns>
            /// 
            double datapointFrequancy;
            string userResponse;
            bool validResponse = true;
            DisplayScreenHeader("Set Frequancy");

            do
            {
                Console.Write("\tEnter frequancy value: ");
                userResponse = Console.ReadLine();
                validResponse = double.TryParse(userResponse, out datapointFrequancy);

                if (!validResponse)
                {
                    Console.WriteLine("\tPlease enter a valid response.");
                }

            } while (!validResponse);

            DisplayContinuePrompt();
            return datapointFrequancy;

        }



        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
