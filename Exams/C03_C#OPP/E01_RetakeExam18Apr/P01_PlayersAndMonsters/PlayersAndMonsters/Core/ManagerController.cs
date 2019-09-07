namespace PlayersAndMonsters.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private ICardRepository cardRepository;
        private IPlayerRepository playerRepository;
        private IPlayerFactory playerFactory;
        private ICardFactory cardFactory;

        public ManagerController()
        {
            cardRepository = new CardRepository();
            playerRepository = new PlayerRepository();
            playerFactory = new PlayerFactory();
            cardFactory = new CardFactory();
        }

        public string AddPlayer(string type, string username)
        {
            var player = playerFactory.CreatePlayer(type, username);

            playerRepository.Add(player);

            string result = string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);

            return result;
        }

        public string AddCard(string type, string name)
        {
            var card = cardFactory.CreateCard(type, name);

            cardRepository.Add(card);

            var result = string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);

            return result;
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = playerRepository.Find(username);
            var card = cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            var result = string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);

            return result;
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var battleField = new BattleField();

            var attackPlayer = playerRepository.Find(attackUser);
            var enemyPlayer = playerRepository.Find(enemyUser);

            battleField.Fight(attackPlayer, enemyPlayer);

            var result = string.Format(ConstantMessages.FightInfo, attackPlayer.Health, enemyPlayer.Health);

            return result;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine(string.Format(ConstantMessages.PlayerReportInfo,
                    player.Username,
                    player.Health,
                    player.CardRepository.Count));

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(string.Format(ConstantMessages.CardReportInfo,
                        card.Name,
                        card.DamagePoints));
                }
                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
