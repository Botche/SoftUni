using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            CheckForBeginners(attackPlayer, enemyPlayer);

            
            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(c=>c.HealthPoints);

            while (true)
            {
                enemyPlayer.TakeDamage(attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints));

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints));

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private void CheckForBeginners(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            const int incrementForHealthPoints = 40;
            const int incrementForDamagePoints = 30;

            if (attackPlayer.GetType() == typeof(Beginner))
            {
                attackPlayer.Health += incrementForHealthPoints;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += incrementForDamagePoints;
                }
            }

            if (enemyPlayer.GetType()==typeof(Beginner))
            {
                enemyPlayer.Health += incrementForHealthPoints;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += incrementForDamagePoints;
                }
            }
        }
    }
}
