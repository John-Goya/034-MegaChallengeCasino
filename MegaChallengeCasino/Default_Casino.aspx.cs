using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeCasino
{
    public partial class Default_Casino : System.Web.UI.Page
    {
        Random randomImage = new System.Random();
        //private int playerMoney = 0000;
        //private int betAmount;
        //private int winnings;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) //return;
            {
                
                //ViewState.Add("playerMoney", 100); //string
                pullLever(0);
                ViewState["playerMoney"] = 100; //integer

                displayMoneyTotal();
                //displayMoneyTotal(betAmount, winnings, playerMoney);
                    
            }
        }

        protected void pullLeverButton_Click(object sender, EventArgs e)
        {
            int betAmount = 0000;
            if (!int.TryParse(betTextBox.Text, out betAmount)) return;
            int winnings = pullLever(betAmount);
            displayOutput(betAmount, winnings);
            playerMoneyWinLose(betAmount, winnings);
            displayMoneyTotal();//(betAmount, winnings, playerMoney);


            //playerMoneyBet(betAmount, winnings, playerMoney);
            //playerMoneyWin(betAmount, winnings, playerMoney);
            
            //playerMoneyBet(betAmount, winnings, playerMoney);
            //playerMoneyStart(playerMoney);
            //playerMoneyTotal(betAmount, winnings, playerMoney);


            //DisplayOutput();
            //reel1Image();
            /*
            ReelArray();
            DisplayReels(reelSlots);
            string imageLocation = randReel();
            slot1Image.ImageUrl = "/Images/" + imageLocation; //slotReel[0];
            */
        }

        private void playerMoneyWinLose(int betAmount, int winnings)
        {
            //int winLoseMoney = int.Parse(ViewState["playerMoney"].ToString());
            int winLoseMoney = Convert.ToInt32(ViewState["playerMoney"]);
            winLoseMoney -= betAmount;
            winLoseMoney += winnings;
            //playerMoney -= betAmount;
            //playerMoney += winnings;
            ViewState["playerMoney"] = winLoseMoney;
        }
        /*private int playerMoneyBet(int betAmount, int winnings, int playerMoney)
        {
            if (winnings <= 0)
            playerMoney = playerMoney - betAmount;
            displayMoneyTotal(betAmount, winnings, playerMoney);
            return playerMoney;
        }

        private int playerMoneyWin(int betAmount, int winnings, int playerMoney)
        {
            if (winnings >= 0)
                playerMoney = playerMoney + winnings;
            displayMoneyTotal(betAmount, winnings, playerMoney);
            return playerMoney;
        }
        */
        private void displayMoneyTotal()//int betAmount, int winnings, int playerMoney)
        {
            playerMoneyLabel.Text = String.Format("Player's Money: {0:C2}", ViewState["playerMoney"]);
            //playerMoneyLabel.Text = String.Format("Player's Money: {0:C2}", playerMoney);
            //return playerMoney;
        }

        private void displayOutput(int betAmount, int winnings)
        {
            if (winnings > 0)
                winLosePayoutLabel.Text = String.Format("You bet {0:C2} and won {1:C2}!", betAmount, winnings);
            else
                winLosePayoutLabel.Text = String.Format("Sorry, you lost {0:C2}. Better luck next time.", betAmount);
        }
                
        private int pullLever(int betAmount) // retreive display results from array, display results in each reel
        {
            string[] reelSlots = new string[] { randReel(), randReel(), randReel() };
            DisplayReels(reelSlots);
            int jackpotMultiplier = spinResults(reelSlots);
            return betAmount * jackpotMultiplier;
            
        }

        private int spinResults(string[] reelSlots)
        {
            if (jackpotBar(reelSlots)) return 0; //one bar = no jackpot - win nothing
            if (jackpotPayout(reelSlots)) return 100; //3 7's bet x 100
            int multiplier = 0;
            if (jackpotCherries(reelSlots, out multiplier)) return multiplier; // 1 cherry bet 2x, 2 cherries bet 3x, 3 cherries bet 4x
            return 0;
        }

        private bool jackpotBar(string[] reelSlots) //one bar - win nothing
        {
            if (reelSlots[0] == "Bar.png" || reelSlots[1] == "Bar.png" || reelSlots[2] == "Bar.png")
                return true;
            else
                return false;
        }

        private bool jackpotPayout(string[] reelSlots) //3 7's bet x 100
        {
            if (reelSlots[0] == "Seven.png" && reelSlots[1] == "Seven.png" && reelSlots[2] == "Seven.png")
                return true;
            else
                return false;
        }

        private bool jackpotCherries(string[] reelSlots, out int multiplier) // 1 cherry bet 2x, 2 cherries bet 3x, 3 cherries bet 4x
        {
            multiplier = countCherries(reelSlots);
            if (multiplier > 0) return true;
            return false;
        }

        private int countCherries(string[] reelSlots)
        {
            int cherriesCount = countCherriesJackpot(reelSlots);
            if (cherriesCount == 1) return 2;
            if (cherriesCount == 2) return 3;
            if (cherriesCount == 3) return 4;
            return 0;
        }

        private int countCherriesJackpot(string[] reelSlots)
        {
            int cherriesCount = 0;
            if (reelSlots[0] == "Cherry.png") cherriesCount++;
            if (reelSlots[1] == "Cherry.png") cherriesCount++;
            if (reelSlots[2] == "Cherry.png") cherriesCount++;
            return cherriesCount;
        }


        private void DisplayReels(string[] reelSlots) //retreive random images and put them into each reel slot
        {
            slot1Image.ImageUrl = "/Images/" + reelSlots[0];
            slot2Image.ImageUrl = "/Images/" + reelSlots[1];
            slot3Image.ImageUrl = "/Images/" + reelSlots[2];
        }

        private string randReel()  // to select random images
        {
            string[] imageNames = {"Bar.png", "Bell.png", "Cherry.png", "Clover.png", "Diamond.png", "HorseShoe.png", "Lemon.png", "Orange.png", "Plum.png", "Seven.png", "Strawberry.png", "Watermelon.png" };
            return imageNames[randomImage.Next(11)];
            /*
            string imageLocation1 = imageNames[randomImage.Next(11)];
            slot1Image.ImageUrl = "/Images/" + imageLocation1;
            string imageLocation2 = imageNames[randomImage.Next(11)];
            slot2Image.ImageUrl = "/Images/" + imageLocation2;
            string imageLocation3 = imageNames[randomImage.Next(11)];
            slot3Image.ImageUrl = "/Images/" + imageLocation3;
            return imageLocation1 = "0";
            */
    }





    }
}


/*
        protected string reel1Image()
        {
            string imgPath = slot1Image.ImageUrl.ToString();
            string imgName = imgPath.Substring(imgPath.LastIndexOf('\\') + 1);
            imgName = imgPath.Remove(1, 1);
            playerMoneyLabel.Text = imgName;
            return imgName = "0";
        }
         
        private void reeloutput() ////double reeloutput() //
        {
            //double betAmount = Convert.ToDouble(betTextBox.Text);

        }


        protected void DisplayOutput() // to display output
        {
         //   double betAmount = Convert.ToDouble(betTextBox.Text);
         //   playerMoneyLabel.Text = betAmount.ToString();
        }
        
        //Sorry, you lost $x.xx. Better luck next time.

        //You bet $x.xx and won $x.xx!


        protected void pullLeverButton_Click(object sender, EventArgs e)
        {
            int betAmount = 0000;
            int playerMoney = 1000;
            if (!int.TryParse(betTextBox.Text, out betAmount)) return;
            int winnings = pullLever(betAmount);
            displayOutput(betAmount, winnings);
            playerMoneyStart(playerMoney);
            //playerMoneyTotal(betAmount, winnings, playerMoney);
            

            //DisplayOutput();
            //reel1Image();
            
            ReelArray();
            DisplayReels(reelSlots);
            string imageLocation = randReel();
            slot1Image.ImageUrl = "/Images/" + imageLocation; //slotReel[0];
            
        }

    
    for (int index = 0; index < 12; index++)
    {
    picArray[] = System.IO.Directory.GetFiles("\\Images", "*.png", SearchOption.TopDirectoryOnly);
    //picArray[] = Image.FromFile("\\Images[index]");
    }

//string[] straImageLocations = System.IO.Directory.GetFiles("DirectoryLocation", "*.png", SearchOption.TopDirectoryOnly);

/*Image[] deck = System.IO.Directory.GetFiles("Assets\\Cards\\")
            .Select(file => System.Drawing.Image.FromFile(file))
            .ToArray();
images in array to pick from randomly
string[] imageArray = new string[11];
imageArray[] = Directory.GetFiles("\\Images");
*/

/*
    public string RandomSlot()
    {
        Image slot1Image = RandomReel(OpenFile);
        //picturebox.image = 
        //pictureBox1.Image = Image.FromFile("c:\\testImage.jpg");
        //pictureBox.Image = Image.FromFile(randomImage);
        return "0";

    }

    private Image RandomReel(Func<string, Stream> openFile)
    {
        throw new NotImplementedException();
    }
*/

