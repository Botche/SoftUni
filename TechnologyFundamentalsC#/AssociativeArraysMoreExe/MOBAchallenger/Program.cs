using System;
using System.Collections.Generic;
using System.Linq;

namespace MOBAchallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            string pureInput = Console.ReadLine();
            string[] input = new string[2];
            if (pureInput.Contains("->"))
                input = pureInput
                    .Split(" -> ")
                    .ToArray();
            else
                input = pureInput
                    .Split(" vs ")
                    .ToArray();

            Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> skills = new Dictionary<string, int>();
            while (pureInput != "Season end")
            {
                if (pureInput.Contains("->"))
                {
                    input = pureInput
                          .Split(" -> ")
                          .ToArray();

                    string player = input[0];
                    string pos = input[1];
                    int skill = int.Parse(input[2]);

                    if (!skills.ContainsKey(player))
                        skills.Add(player, skill);

                    if (!players.ContainsKey(player))
                    {
                        players.Add(player, new Dictionary<string, int>());
                        players[player].Add(pos, skill);
                    }
                    else
                    {
                        if (players[player].ContainsKey(pos))
                        {
                            if (players[player][pos] < skill)
                            {
                                skills[player] += skill - players[player][pos];
                                players[player][pos] = skill;
                            }
                        }
                        else
                        {
                            players[player].Add(pos, skill);
                            skills[player] += skill;
                        }

                    }
                }
                else
                {
                    input = pureInput
                          .Split(" vs ")
                          .ToArray();

                    string playerOne = input[0];
                    string playerTwo = input[1];

                    if (players.ContainsKey(playerOne) && players.ContainsKey(playerTwo))
                    {
                        bool checkerForDuel = false;
                        foreach (var posForFirst in players[playerOne])
                        {
                            var posSaver = players[playerTwo];
                            if (posSaver.ContainsKey(posForFirst.Key))
                            {
                                checkerForDuel = true;
                                break;
                            }
                        }
                        if (checkerForDuel == true)
                        {
                            int sumOfFirst = 0;
                            foreach (var plOne in players[playerOne])
                            {
                                sumOfFirst += plOne.Value;
                            }

                            int sumOfSecond = 0;
                            foreach (var plTwo in players[playerTwo])
                            {
                                sumOfSecond += plTwo.Value;
                            }

                            if (sumOfFirst < sumOfSecond)
                            {
                                players.Remove(playerOne);
                                skills.Remove(playerOne);
                            }
                            else if (sumOfFirst > sumOfSecond)
                            {
                                players.Remove(playerTwo);
                                skills.Remove(playerTwo);
                            }
                        }
                    }
                }
                pureInput = Console.ReadLine();
            }
            var sortedPlayers = skills
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key);
            foreach (var player in sortedPlayers)
            {
                Console.WriteLine($"{player.Key}: {player.Value} skill");
                foreach (var pos in players[player.Key]
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, z => z.Value))
                {
                    Console.WriteLine($"- {pos.Key} <::> {pos.Value}");
                }
            }
        }
    }
}
