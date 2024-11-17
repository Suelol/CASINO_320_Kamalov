using CASINO.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CASINO.Pages
{
    /// <summary>
    /// Логика взаимодействия для BlakjakPage.xaml
    /// </summary>
    public partial class BlakjakPage : Page
    {
        
        private Deck deck;
        private Hand playerHand;
        private Hand dealerHand;


        public BlakjakPage()
        {
            InitializeComponent();
            deck = new Deck();
            InitData();
        }

        private void InitData()
        {
            var user = ConnectionClass.db.Users.FirstOrDefault(u => u.Id == ConnectionClass.IsOnlineUserId);
            if (user != null)
            {
                balanceTxt.Content = user.Balance.ToString();
            }
            else
            {
                balanceTxt.Content = "No connect user";
            }
        }

        private void UpdateBalance(BalanceUpdateEnum balanceUpdateEnum, decimal stavka)
        {
            if (stavka != 0)
            {
                var user = ConnectionClass.db.Users.FirstOrDefault(u => u.Id == ConnectionClass.IsOnlineUserId);
                if (balanceUpdateEnum == BalanceUpdateEnum.Replenish)
                {
                    user.Balance += stavka;
                }
                else if (balanceUpdateEnum == BalanceUpdateEnum.Removal)
                {
                    user.Balance -= stavka;
                }

                ConnectionClass.db.SaveChanges();
            }
        }

        private void UpdateGameHistory(ResultGameEnum resultGameEnum)
        {
            Random rnd = new Random();

            int result = 0;
            switch (resultGameEnum)
            {
                case ResultGameEnum.Won:
                    result = 1;
                    break;
                case ResultGameEnum.Losing:
                    result = 0;
                    break;
                case ResultGameEnum.Tie:
                    result = 2;
                    break;
            }

            GameHistory gameHistory = new GameHistory()
            {
                UserId = ConnectionClass.IsOnlineUserId,
                GameId = 1,
                SessionId = 4,
                Bet = Convert.ToDecimal(StavkaTextBox.Text),
                Result = result,
                DateTime = DateTime.Now
            };
            ConnectionClass.db.GameHistory.Add(gameHistory);
            ConnectionClass.db.SaveChanges();
        }

        private void DealButton_Click(object sender, RoutedEventArgs e)
        {

            var user = ConnectionClass.db.Users.FirstOrDefault(u => u.Id == ConnectionClass.IsOnlineUserId);
            if (user.Balance < Convert.ToDecimal(StavkaTextBox.Text))
            {
                CustomMessageBox successMessage = new CustomMessageBox("Недостаточно средств на счете!");
                successMessage.ShowDialog();
                return;
            }
            deck.Shuffle();
            playerHand = new Hand();
            dealerHand = new Hand();

            // Раздаем две карты игроку и дилеру
            playerHand.AddCard(deck.DrawCard());
            playerHand.AddCard(deck.DrawCard());
            dealerHand.AddCard(deck.DrawCard());
            dealerHand.AddCard(deck.DrawCard());

            UpdateUI();
            DealButton.IsEnabled = false;
            HitButton.IsEnabled = true;
            StandButton.IsEnabled = true;
        }

        private void HitButton_Click(object sender, RoutedEventArgs e)
        {
            playerHand.AddCard(deck.DrawCard());
            UpdateUI();

            if (playerHand.GetValue() > 21)
            {
                EndGame("Вы проиграли!");
                UpdateBalance(BalanceUpdateEnum.Removal, Convert.ToDecimal(StavkaTextBox.Text));
                InitData();
                UpdateGameHistory(ResultGameEnum.Losing);
            }
        }

        private void StandButton_Click(object sender, RoutedEventArgs e)
        {
            // Дилер берет карты до тех пор, пока его значение меньше 17
            while (dealerHand.GetValue() < 17)
            {
                dealerHand.AddCard(deck.DrawCard());
            }

            UpdateUI();
            CheckWinner();
        }

        private void CheckWinner()
        {
            int playerValue = playerHand.GetValue();
            int dealerValue = dealerHand.GetValue();

            if (dealerValue > 21 || playerValue > dealerValue)
            {
                EndGame("Вы выиграли!");

                UpdateBalance(BalanceUpdateEnum.Replenish, Convert.ToDecimal(StavkaTextBox.Text));
                InitData();
                UpdateGameHistory(ResultGameEnum.Won);
            }
            else if (playerValue == dealerValue)
            {
                EndGame("Ничья!");
                UpdateGameHistory(ResultGameEnum.Tie);
            }
            else
            {
                EndGame("Дилер выиграл!");

                UpdateGameHistory(ResultGameEnum.Losing);
                UpdateBalance(BalanceUpdateEnum.Removal, Convert.ToDecimal(StavkaTextBox.Text));
                InitData();
            }
        }

        private void EndGame(string result)
        {
            ResultLabel.Content = result;
            DealButton.IsEnabled = true;
            HitButton.IsEnabled = false;
            StandButton.IsEnabled = false;
        }

        private void UpdateUI()
        {
            PlayerHand.Children.Clear();
            DealerHand.Children.Clear();

            foreach (var card in playerHand.Cards)
            {
                // Создаем карточку как прямоугольник с текстом
                var cardBorder = new Border
                {
                    Width = 50,
                    Height = 70,
                    Background = Brushes.White,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(2),
                    CornerRadius = new CornerRadius(5),
                    Margin = new Thickness(5)
                };

                // Вставляем текст карты в прямоугольник
                var cardText = new TextBlock
                {
                    Text = card.ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 16,
                    FontWeight = FontWeights.Bold
                };

                cardBorder.Child = cardText;
                PlayerHand.Children.Add(cardBorder);
            }

            foreach (var card in dealerHand.Cards)
            {
                // Создаем карточку как прямоугольник с текстом
                var cardBorder = new Border
                {
                    Width = 50,
                    Height = 70,
                    Background = Brushes.White,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(2),
                    CornerRadius = new CornerRadius(5),
                    Margin = new Thickness(5)
                };

                // Вставляем текст карты в прямоугольник
                var cardText = new TextBlock
                {
                    Text = card.ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 16,
                    FontWeight = FontWeights.Bold
                };

                cardBorder.Child = cardText;
                DealerHand.Children.Add(cardBorder);
            }
        }

    }

    public class Deck
    {
        private List<Card> cards;
        private Random random = new Random();

        public Deck()
        {
            cards = new List<Card>();
            string[] suits = { "♠", "♥", "♦", "♣" };
            string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach (var suit in suits)
            {
                foreach (var value in values)
                {
                    cards.Add(new Card(value, suit));
                }
            }
        }

        public void Shuffle()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                int j = random.Next(cards.Count);
                var temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public Card DrawCard()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }

    public class Hand
    {
        public List<Card> Cards { get; private set; }

        public Hand()
        {
            Cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public int GetValue()
        {
            int value = 0;
            int aceCount = 0;

            foreach (var card in Cards)
            {
                if (card.Value == "A")
                {
                    aceCount++;
                    value += 11;
                }
                else if (card.Value == "K" || card.Value == "Q" || card.Value == "J")
                {
                    value += 10;
                }
                else
                {
                    value += int.Parse(card.Value);
                }
            }

            while (value > 21 && aceCount > 0)
            {
                value -= 10;
                aceCount--;
            }

            return value;
        }
    }

    public class Card
    {
        public string Value { get; private set; }
        public string Suit { get; private set; }

        public Card(string value, string suit)
        {
            Value = value;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{Value}{Suit}";
        }
    }
}
