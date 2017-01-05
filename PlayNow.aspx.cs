using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    protected static int bet = 0;
    protected static int user_count = 0;
    protected static int dealer_count = 0;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("Welcome.aspx");
        }
        else
        {
            if(!IsPostBack)
            {
                bet = 0;
                Deal.Enabled = false;
                buttonpanel.Enabled = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('New Game !!! Select the Bet Amount first and click on Deal');", true);
            }
            
            int x = Convert.ToInt32(Session["UserID"]);
            using (var context = new BlackJackOnlineEntities())
            {
                var users = from u in context.Users
                            where u.UserId == x
                            select u;

                if (users.FirstOrDefault() != null)
                {
                    var user = users.FirstOrDefault();
                    money.Text = Convert.ToString(user.Money);
                }
            }
        }
    }

    protected List<int> cards
    {
        get
        {
            var list = Session["cards"] as List<int>;
            if (list == null)
            {
                Session["cards"] = list = new List<int>();
            }
            return list;
        }
    }

    protected List<int> user_deck
    {
        get
        {
            var list = Session["user_deck"] as List<int>;
            if (list == null)
            {
                Session["user_deck"] = list = new List<int>();
            }
            return list;
        }
    }

    protected List<int> dealer_deck
    {
        get
        {
            var list = Session["dealer_deck"] as List<int>;
            if (list == null)
            {
                Session["dealer_deck"] = list = new List<int>();
            }
            return list;
        }
    }

    public List<int> ShuffleList(List<int> inputList)
    {
        List<int> randomList = new List<int>();

        Random r = new Random();
        int randomIndex = 0;
        while (inputList.Count > 0)
        {
            randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
            randomList.Add(inputList[randomIndex]); //add it to the new, random list
            inputList.RemoveAt(randomIndex); //remove to avoid duplicates
        }

        return randomList;
    }

    public void addmoney(decimal n)
    {
        int x = Convert.ToInt32(Session["UserId"]);
        using (var context = new BlackJackOnlineEntities())
        {
            var users = from u in context.Users
                        where u.UserId == x
                        select u;

            if (users.FirstOrDefault() != null)
            {
                var user = users.FirstOrDefault();
                user.Money = n;
                money.Text = Convert.ToString(user.Money);
            }
            context.SaveChanges();
            

        }
    }


    protected int calculateBlackJack(List<int> calculate_list)
    {
        if (calculate_list.Count == 2)
        {
            var card1 = getCardNumber(calculate_list[0]);
            var card2 = getCardNumber(calculate_list[1]);
            if ((card1 == 1 && (card2 == 11 || card2 == 12 || card2 == 13)) || (card2 == 1 && (card1 == 11 || card1 == 12 || card1 == 13)))
                return 22;
        }
        int points = 0;
        for (var i = 0; i < calculate_list.Count; i++)
        {
            int number = getCardNumber(calculate_list[i]);
            if (number >= 11)
                points += 10;
            else points += number;
        }
        if (points > 21)
            return points;
        for (var i = 0; i < calculate_list.Count; i++)
        {
            var number = getCardNumber(calculate_list[i]);
            if (number == 1 && points + 10 <= 21)
                return points + 10;
        }
        return points;
    }

    protected int getCardNumber(int n)
    {
        while (n > 13)
        {
            n = n % 13;
            if (n == 0)
            { n = 13; break; }
        }
        return n;
    }

    protected string GetCard(int number)
    {
        int n = number;
        string s = "";
        while (n > 13)
        {
            n = n % 13;
            if (n == 0)
            { n = 13; break; }
        }

        if (n >= 11 && n <= 13 || n == 1)
        {
            if (n == 11)
            {
                s = "jack";
            }
            else if (n == 12)
            {
                s = "queen";
            }
            else if (n == 13)
            {
                s = "king";
            }
            else
            {
                s = "ace";
            }
        }

        if (number >= 1 && number <= 13)
        {
            if (n < 11 && n > 1)
            {
                return n + "_of_hearts.svg";
            }
            else
            {
                return s + "_of_hearts.svg";
            }

        }
        else if (number >= 14 && number <= 26)
        {
            if (n < 11 && n > 1)
            {
                return n + "_of_spades.svg";
            }
            else
            {
                return s + "_of_spades.svg";
            }
        }
        else if (number >= 27 && number <= 39)
        {
            if (n < 11 && n > 1)
            {
                return n + "_of_diamonds.svg";
            }
            else
            {
                return s + "_of_diamonds.svg";
            }
        }
        else
        {
            if (n < 11 && n > 1)
            {
                return n + "_of_clubs.svg";
            }
            else
            {
                return s + "_of_clubs.svg";
            }
        }
    }

    protected void Stand_Click(object sender, EventArgs e)
    {
        int x = Convert.ToInt32(Session["UserID"]);
        using (var context = new BlackJackOnlineEntities())
        {

            user_count = calculateBlackJack(user_deck);
            playerscore.Text = user_count.ToString();

            if (dealer_count < 17)
            {
                if (Image19.ImageUrl == "")
                {
                    string deal3 = GetCard(cards[0]);
                    dealer_deck.Add(cards[0]);
                    Image19.ImageUrl = "~/Images/Cards/" + deal3;
                    Image19.Visible = true;
                    cards.Remove(cards[0]);
                }
                else if (Image20.ImageUrl == "")
                {
                    string deal4 = GetCard(cards[0]);
                    dealer_deck.Add(cards[0]);
                    Image20.ImageUrl = "~/Images/Cards/" + deal4;
                    Image20.Visible = true;
                    cards.Remove(cards[0]);
                }
                else if (Image21.ImageUrl == "")
                {
                    string deal5 = GetCard(cards[0]);
                    dealer_deck.Add(cards[0]);
                    Image21.ImageUrl = "~/Images/Cards/" + deal5;
                    Image21.Visible = true;
                    cards.Remove(cards[0]);
                }
                else if (Image22.ImageUrl == "")
                {
                    string deal6 = GetCard(cards[0]);
                    dealer_deck.Add(cards[0]);
                    Image22.ImageUrl = "~/Images/Cards/" + deal6;
                    Image22.Visible = true;
                    cards.Remove(cards[0]);
                }
                else
                {
                    string deal7 = GetCard(cards[0]);
                    dealer_deck.Add(cards[0]);
                    Image23.ImageUrl = "~/Images/Cards/" + deal7;
                    Image23.Visible = true;
                    cards.Remove(cards[0]);
                }

            }
            dealer_count = calculateBlackJack(dealer_deck);
            dealerscore.Text = dealer_count.ToString();
            if (dealer_count >= 17 && dealer_count <= 21)
            {
                if (dealer_count > 21)
                {
                    Panel1.Visible = true;
                    game_state.Text = "Dealer Busted";

                    var users = from u in context.Users
                                where u.UserId == x
                                select u;

                    if (users.FirstOrDefault() != null)
                    {
                        var user = users.FirstOrDefault();
                        decimal money = Convert.ToDecimal(user.Money);
                        user.Wins += 1;
                        money = 2 * bet + money;                        
                        potamount.Text = (2 * bet).ToString();
                        addmoney(money);
                        context.SaveChanges();
                        clearAll();
                    }
                }
                else if (dealer_count >= 17)
                {
                    if (dealer_count > user_count)
                    {
                        Panel1.Visible = true;
                        game_state.Text = "Dealer Won";

                        var users = from u in context.Users
                                    where u.UserId == x
                                    select u;

                        if (users.FirstOrDefault() != null)
                        {
                            var user = users.FirstOrDefault();
                            decimal money = Convert.ToDecimal(user.Money);
                            money = money - bet;
                            user.Losses += 1;
                            potamount.Text = (2 * bet).ToString();
                            addmoney(money);
                            context.SaveChanges();
                            clearAll();
                        }
                    }
                    else if (user_count > dealer_count)
                    {
                        Panel1.Visible = true;
                        game_state.Text = "User Won";

                        var users = from u in context.Users
                                    where u.UserId == x
                                    select u;

                        if (users.FirstOrDefault() != null)
                        {
                            var user = users.FirstOrDefault();
                            decimal money = Convert.ToDecimal(user.Money);
                            money = 2 * bet + money;
                            user.Wins += 1;
                            potamount.Text = (2 * bet).ToString();
                            addmoney(money);
                            context.SaveChanges();
                            clearAll();
                        }
                    }
                    else
                    {
                        Panel1.Visible = true;
                        game_state.Text = "Push, Game Draw";

                        var users = from u in context.Users
                                    where u.UserId == x
                                    select u;

                        if (users.FirstOrDefault() != null)
                        {
                            var user = users.FirstOrDefault();
                            user.Money = user.Money + bet;
                            user.Draws += 1;
                            potamount.Text = "0";
                            context.SaveChanges();
                            clearAll();
                        }
                    }

                }
            }
            else
            {
                if (Image19.ImageUrl == "")
                {
                    string deal3 = GetCard(cards[0]);
                    dealer_deck.Add(cards[0]);
                    Image19.ImageUrl = "~/Images/Cards/" + deal3;
                    Image19.Visible = true;
                    cards.Remove(cards[0]);
                }
                else if (Image20.ImageUrl == "")
                {
                    string deal4 = GetCard(cards[0]);
                    dealer_deck.Add(cards[0]);
                    Image20.ImageUrl = "~/Images/Cards/" + deal4;
                    Image20.Visible = true;
                    cards.Remove(cards[0]);
                }
                else if (Image21.ImageUrl == "")
                {
                    string deal5 = GetCard(cards[0]);
                    dealer_deck.Add(cards[0]);
                    Image21.ImageUrl = "~/Images/Cards/" + deal5;
                    Image21.Visible = true;
                    cards.Remove(cards[0]);
                }
                else if (Image22.ImageUrl == "")
                {
                    string deal6 = GetCard(cards[0]);
                    dealer_deck.Add(cards[0]);
                    Image22.ImageUrl = "~/Images/Cards/" + deal6;
                    Image22.Visible = true;
                    cards.Remove(cards[0]);
                }
                else
                {
                    string deal7 = GetCard(cards[0]);
                    dealer_deck.Add(cards[0]);
                    Image23.ImageUrl = "~/Images/Cards/" + deal7;
                    Image23.Visible = true;
                    cards.Remove(cards[0]);
                }
                dealer_count = calculateBlackJack(dealer_deck);
                dealerscore.Text = dealer_count.ToString();

                if (dealer_count > 21)
                {
                    Panel1.Visible = true;
                    game_state.Text = "Dealer Busted";

                    var users = from u in context.Users
                                where u.UserId == x
                                select u;

                    if (users.FirstOrDefault() != null)
                    {
                        var user = users.FirstOrDefault();
                        decimal money = Convert.ToDecimal(user.Money);
                        money = 2 * bet + money;
                        user.Wins += 1;
                        potamount.Text = (2 * bet).ToString();
                        addmoney(money);
                        context.SaveChanges();
                        clearAll();
                    }
                }
                else if (dealer_count >= 17)
                {
                    if (dealer_count > user_count)
                    {
                        Panel1.Visible = true;
                        game_state.Text = "Dealer Won";

                        var users = from u in context.Users
                                    where u.UserId == x
                                    select u;

                        if (users.FirstOrDefault() != null)
                        {
                            var user = users.FirstOrDefault();
                            decimal money = Convert.ToDecimal(user.Money);
                            money = money - bet;
                            user.Losses += 1;
                            potamount.Text = (2 * bet).ToString();
                            addmoney(money);
                            context.SaveChanges();
                            clearAll();
                        }
                    }
                    else if (user_count > dealer_count)
                    {
                        Panel1.Visible = true;
                        game_state.Text = "User Won";

                        var users = from u in context.Users
                                    where u.UserId == x
                                    select u;

                        if (users.FirstOrDefault() != null)
                        {
                            var user = users.FirstOrDefault();
                            decimal money = Convert.ToDecimal(user.Money);
                            money = 2 * bet + money;
                            user.Wins += 1;
                            potamount.Text = (2 * bet).ToString();
                            addmoney(money);
                            context.SaveChanges();
                            clearAll();
                        }
                    }
                    else
                    {
                        Panel1.Visible = true;
                        game_state.Text = "Push, Game Draw";

                        var users = from u in context.Users
                                    where u.UserId == x
                                    select u;

                        if (users.FirstOrDefault() != null)
                        {
                            var user = users.FirstOrDefault();
                            potamount.Text = "0";
                            user.Money = user.Money + bet;
                            user.Draws += 1;
                            context.SaveChanges();
                            clearAll();
                        }
                    }

                }
            }


        }


    }

    protected void Hit_Click(object sender, EventArgs e)
    {
        int x = Convert.ToInt32(Session["UserID"]);

        using (var context = new BlackJackOnlineEntities())
        {

            if (Image16.ImageUrl == "")
            {
                string user3 = GetCard(cards[0]);
                user_deck.Add(cards[0]);
                Image16.ImageUrl = "~/Images/Cards/" + user3;
                Image16.Visible = true;
                cards.Remove(cards[0]);
            }
            else if (Image17.ImageUrl == "")
            {
                string user4 = GetCard(cards[0]);
                user_deck.Add(cards[0]);
                Image17.ImageUrl = "~/Images/Cards/" + user4;
                Image17.Visible = true;
                cards.Remove(cards[0]);
            }
            else if (Image18.ImageUrl == "")
            {
                string user5 = GetCard(cards[0]);
                user_deck.Add(cards[0]);
                Image18.ImageUrl = "~/Images/Cards/" + user5;
                Image18.Visible = true;
                cards.Remove(cards[0]);
            }
            else if (Image24.ImageUrl == "")
            {
                string user6 = GetCard(cards[0]);
                user_deck.Add(cards[0]);
                Image24.ImageUrl = "~/Images/Cards/" + user6;
                Image24.Visible = true;
                cards.Remove(cards[0]);
            }
            else
            {
                string user7 = GetCard(cards[0]);
                user_deck.Add(cards[0]);
                Image25.ImageUrl = "~/Images/Cards/" + user7;
                Image25.Visible = true;
                cards.Remove(cards[0]);
            }

            user_count = calculateBlackJack(user_deck);
            playerscore.Text = user_count.ToString();


            if (user_count > 21)
            {
                Panel1.Visible = true;
                game_state.Text = "User Busted !!!";

                var users = from u in context.Users
                            where u.UserId == x
                            select u;

                if (users.FirstOrDefault() != null)
                {
                    var user = users.FirstOrDefault();
                    decimal money = Convert.ToInt32(user.Money);
                    money = money - bet;
                    user.Losses += 1;
                    potamount.Text = (2 * bet).ToString();
                    addmoney(money);
                    context.SaveChanges();
                    clearAll();
                }
            }
            else
            {
                if (dealer_count < 17)
                {
                    if (Image19.ImageUrl == "")
                    {
                        string deal3 = GetCard(cards[0]);
                        dealer_deck.Add(cards[0]);
                        Image19.ImageUrl = "~/Images/Cards/" + deal3;
                        Image19.Visible = true;
                        cards.Remove(cards[0]);
                    }
                    else if (Image20.ImageUrl == "")
                    {
                        string deal4 = GetCard(cards[0]);
                        dealer_deck.Add(cards[0]);
                        Image20.ImageUrl = "~/Images/Cards/" + deal4;
                        Image20.Visible = true;
                        cards.Remove(cards[0]);
                    }
                    else if (Image21.ImageUrl == "")
                    {
                        string deal5 = GetCard(cards[0]);
                        dealer_deck.Add(cards[0]);
                        Image21.ImageUrl = "~/Images/Cards/" + deal5;
                        Image21.Visible = true;
                        cards.Remove(cards[0]);
                    }
                    else if (Image22.ImageUrl == "")
                    {
                        string deal6 = GetCard(cards[0]);
                        dealer_deck.Add(cards[0]);
                        Image22.ImageUrl = "~/Images/Cards/" + deal6;
                        Image22.Visible = true;
                        cards.Remove(cards[0]);
                    }
                    else
                    {
                        string deal7 = GetCard(cards[0]);
                        dealer_deck.Add(cards[0]);
                        Image23.ImageUrl = "~/Images/Cards/" + deal7;
                        Image23.Visible = true;
                        cards.Remove(cards[0]);
                    }
                }
                dealer_count = calculateBlackJack(dealer_deck);
                dealerscore.Text = dealer_count.ToString();

                if (dealer_count > 21)
                {
                    Panel1.Visible = true;
                    game_state.Text = "Dealer Busted";

                    var users = from u in context.Users
                                where u.UserId == x
                                select u;

                    if (users.FirstOrDefault() != null)
                    {
                        var user = users.FirstOrDefault();
                        decimal money = Convert.ToInt32(user.Money);
                        money = 2 * bet + money;
                        user.Wins += 1;
                        potamount.Text = (2 * bet).ToString();
                        addmoney(money);
                        context.SaveChanges();
                        clearAll();
                    }
                }
            }

           
        }

    }

    // BUTTON DEAL //
    protected void Button6_Click(object sender, EventArgs e)
    {

        int x = Convert.ToInt32(Session["UserID"]);

        buttonpanel.Enabled = true;
        Deal.Enabled = false;


        using (var context = new BlackJackOnlineEntities())
        {
            List<int> input = new List<int>();
            for (int i = 1; i < 53; i++)
            {
                input.Add(i);
            }
            List<int> input1 = new List<int>();
            input1 = ShuffleList(input);            

            foreach (var item in input1)
            {
                cards.Add(item);
            }

                        
            string deal1 = GetCard(input1[0]);
            string deal2 = GetCard(input1[1]);

            dealer_deck.Add(input1[0]);
            dealer_deck.Add(input1[1]);

            dealer_count = calculateBlackJack(dealer_deck);

            dealerscore.Text = dealer_count.ToString();

            string user1 = GetCard(input1[2]);
            string user2 = GetCard(input1[3]);

            

            user_deck.Add(input1[2]);
            user_deck.Add(input1[3]);

            user_count = calculateBlackJack(user_deck);

            playerscore.Text = user_count.ToString();

            Image2.ImageUrl = "~/Images/Cards/" + deal1;
            Image3.ImageUrl = "~/Images/Cards/" + deal2;
            Image4.ImageUrl = "~/Images/Cards/" + user1;
            Image5.ImageUrl = "~/Images/Cards/" + user2;

            cards.RemoveRange(0, 4);

            int bj1 = getCardNumber(input1[2]);
            int bj2 = getCardNumber(input1[3]);


            if ((bj1 == 1 && (bj2 == 11 || bj2 == 12 || bj2 == 13)) || (bj2 == 1 && (bj1 == 11 || bj1 == 12 ||bj1 == 13)))
            {
                Panel1.Visible = true;
                game_state.Text = "User Won";
                playerscore.Text = "Black Jack!!!";


                var users = from u in context.Users
                            where u.UserId == x
                            select u;

                if (users.FirstOrDefault() != null)
                {
                    var user = users.FirstOrDefault();
                    decimal money = Convert.ToDecimal(user.Money);
                    money = ((decimal)2.5 * bet) + money;
                    user.Wins += 1;
                    potamount.Text = (2.5 * bet).ToString();
                    addmoney(money);
                    context.SaveChanges();
                    clearAll();
                }
            }

            

           


        }
    }

    protected void bet5_Click(object sender, EventArgs e)
    {
        int x = Convert.ToInt32(Session["UserID"]);

        bet = 5;
        Deal.Enabled = true;
        bet_money.Text = bet.ToString();
        potamount.Text = "10";

        using (var context = new BlackJackOnlineEntities())
        {
            var users = from u in context.Users
                        where u.UserId == x
                        select u;

            if (users.FirstOrDefault() != null)
            {
                var user = users.FirstOrDefault();
                decimal money = Convert.ToInt32(user.Money);
                money = money - bet;
                addmoney(money);
                context.SaveChanges();


            }
        }
    }

    protected void bet10_Click(object sender, EventArgs e)
    {
        int x = Convert.ToInt32(Session["UserID"]);

        bet = 10;
        Deal.Enabled = true;
        bet_money.Text = bet.ToString();
        potamount.Text = "20";
        using (var context = new BlackJackOnlineEntities())
        {
            var users = from u in context.Users
                        where u.UserId == x
                        select u;

            if (users.FirstOrDefault() != null)
            {
                var user = users.FirstOrDefault();
                decimal money = Convert.ToInt32(user.Money);
                money = money - bet;
                addmoney(money);
                context.SaveChanges();

            }
        }
    }

    protected void bet25_Click(object sender, EventArgs e)
    {
        int x = Convert.ToInt32(Session["UserID"]);

        bet = 25;
        Deal.Enabled = true;
        bet_money.Text = bet.ToString();
        potamount.Text = "50";
        using (var context = new BlackJackOnlineEntities())
        {
            var users = from u in context.Users
                        where u.UserId == x
                        select u;

            if (users.FirstOrDefault() != null)
            {
                var user = users.FirstOrDefault();
                decimal money = Convert.ToDecimal(user.Money);
                money = money - bet;
                addmoney(money);
                context.SaveChanges();
            }
        }
    }

    protected void clearAll()
    {
        bet = 0;
        user_count = 0;
        dealer_count = 0;
        cards.Clear();
        user_deck.Clear();
        dealer_deck.Clear();

        NewGame.Enabled = true;
        NewGame.Visible = true;
        Deal.Enabled = false;
        Deal.Visible = false;

        buttonpanel.Visible = false;
        buttonpanel.Enabled = false;
        Panel2.Enabled = false;
        Panel2.Visible = false;
                   
}

    protected void NewGame_Click(object sender, EventArgs e)
    {
        Response.Redirect("PlayNow.aspx");
    }

    protected void Surrender_Click(object sender, EventArgs e)
    {
        int x = Convert.ToInt32(Session["UserID"]);
        using (var context = new BlackJackOnlineEntities())
        {
            var users = from u in context.Users
                        where u.UserId == x
                        select u;

            if (users.FirstOrDefault() != null)
            {
                var user = users.FirstOrDefault();
                decimal money = Convert.ToDecimal(user.Money);
                money = money + (bet/2);
                addmoney(money);
                user.Losses += 1;
                context.SaveChanges();
                clearAll();
            }
        }
    }
}
