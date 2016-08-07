/**
 * Author:      G. Shelley
 * Program:     Group Project
 * Date:        13-Feb-2015
 * 
*/

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLibrary;


// namespace
namespace DurakLibrary
{
    class PlayerStats
    {
        //============================================
        // Instance Constant and Variable Declarations
        //============================================
        private static DateTime myDate = DateTime.Now;
        private static string fileName;
        private static string playerName;
        private static string comma = ",";
        private static int playerAttack = 0;
        private static int playerDefend = 0;
        private static int cardsDealt = 0;
        private static int numberOfGames = 0;


        //============================================
        // Load Durak Opens file for saving game info
        //============================================
        public static void LoadDurak(string name)
        {
            
            playerName = name;
            //fileName = @"C:\TestingDurak\" + name + "-test.csv";

            fileName = @"../../log_stats/" + name + "-test.csv";

            if (!File.Exists(fileName))
            {
                Console.WriteLine("\nThank you for joining us " + playerName);
                File.Create(fileName).Close();
                System.IO.StreamWriter file = new System.IO.StreamWriter
                (fileName);
                file.WriteLine("Player Name :" + comma + playerName);
                file.WriteLine("Game Date :" + comma + myDate.ToString("g"));
                file.WriteLine("******************" + comma + "******************");    
                file.Close();
            }
            else
            {
                Console.WriteLine("\nWelcome back " + playerName);
                using (StreamWriter file = File.AppendText(fileName))
                {
                    file.WriteLine("Player Name :" + comma + playerName);
                    file.WriteLine("Game Date :" + comma + myDate.ToString("g"));
                    file.WriteLine("******************" + comma + "******************");    
                }
            } 
        }


        //============================================
        // Save the static information to the file
        //============================================
        public static void DisplayStats()
        {
            using (StreamWriter file = File.AppendText(fileName))
            {
                file.WriteLine("End of Game Satistics");                
                file.WriteLine("Game Date  :" + comma + myDate.ToString("g"));
                file.WriteLine("Cards Dealt:" + comma + cardsDealt);
                file.WriteLine("Attacks    :" + comma + playerAttack);
                file.WriteLine("Defends    :" + comma + playerDefend);
                file.WriteLine("******************" + comma + "******************");    
            }
        }


        //============================================
        // Save the Attack Hand results to the file 
        //============================================
        public static void AttackSuccess()
        {
            playerAttack++;
            using (StreamWriter file = File.AppendText(fileName))
            {
                file.WriteLine("Player Attack was succesful");
                file.WriteLine("******************" + comma + "******************");   
            }
        }


        //============================================
        // Save the Defend Hand results to the file 
        //============================================
        public static void DefendSuccess()
        {
            playerDefend++;
            using (StreamWriter file = File.AppendText(fileName))
            {
                file.WriteLine("Player Defence was succesful");
                file.WriteLine("******************" + comma + "******************");   
            }
        }


        //============================================
        // Save the cards played to the file 
        //============================================
        public static void TrackCards(Card myCard)
        {
            using (StreamWriter file = File.AppendText(fileName))
            {
                file.WriteLine(myCard.ToString());
            }
        }


        //============================================
        // Incerement the number of cards dealt
        //============================================
        public static void CardsDealt()
        {
            cardsDealt++;
        }


        //============================================
        // Save the initial cards of each players hand
        //============================================
        public static void DealHands(Card[] playerHand, Card[] dealerHand)
        {
            using (StreamWriter file = File.AppendText(fileName))
            {
                file.WriteLine("Initial Card Hands");
                file.WriteLine("Player Cards" + comma + "Dealer Cards");
            
                // Set cards in a hand
                for (int i = 0; i <= playerHand.GetUpperBound(0); i++)
                {
                    file.WriteLine(playerHand[i] + comma + dealerHand[i]);
                }
            }
        }


        //============================================
        // Play the cards for each Attack
        //============================================
        public static void PlayCards(string playerName, Card attackCard, Card defendCard)
        {
            using (StreamWriter file = File.AppendText(fileName))
            {
                file.WriteLine(playerName + "Attacks");
                file.WriteLine("Player Cards" + comma + "Dealer Cards");
                file.WriteLine(attackCard + comma + defendCard); 
            }
        }


        //============================================
        // Draw new cards from the deck
        //============================================
        public static void DrawCards(string playerName, Card drawCard)
        {
            using (StreamWriter file = File.AppendText(fileName))
            {
                file.WriteLine(playerName + " draws the card " + comma + drawCard);
            }
        }

    }
}

