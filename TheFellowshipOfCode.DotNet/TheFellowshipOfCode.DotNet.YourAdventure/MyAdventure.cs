using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HTF2020.Contracts;
using HTF2020.Contracts.Enums;
using HTF2020.Contracts.Models;
using HTF2020.Contracts.Models.Adventurers;
using HTF2020.Contracts.Requests;

namespace TheFellowshipOfCode.DotNet.YourAdventure
{
    public class MyAdventure : IAdventure
    {
        private readonly Random _random = new Random();




        public Task<Party> CreateParty(CreatePartyRequest request)
        {
            var party = new Party
            {
                Name = "My Party",
                Members = new List<PartyMember>()
            };


            for (var i = 0; i < request.MembersCount; i++)
            {
                party.Members.Add(new Fighter()
                {
                    Id = i,
                    Name = $"Member {i + 1}",
                    Constitution = 8,
                    Strength = 8,
                    Intelligence = 18
                });
            }
            Console.WriteLine("Amount Party members: " + request.MembersCount);

            return Task.FromResult(party);
        }

        public double checkDistance(int x1, int y1, int x2, int y2)
        {
            return (Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }


        public Task<Turn> PlayTurn(PlayTurnRequest request)
        {
            List<Position> itemPositions = new List<Position>();
            for (int i = 0; i < request.Map.Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < request.Map.Tiles.GetLength(1); j++)
                {
                    if (request.Map.Tiles[i, j].TileType == TileType.TreasureChest)
                    {
                        Treasure treasurePosition = new Treasure();
                        treasurePosition.x = i;
                        treasurePosition.y = j;
                        itemPositions.Add(treasurePosition);
                    }
                    if (request.Map.Tiles[i, j].TileType == TileType.Enemy)
                    {
                        Enemy enemyPosition = new Enemy();
                        enemyPosition.x = i;
                        enemyPosition.y = j;
                        itemPositions.Add(enemyPosition);
                    }
                    if (request.Map.Tiles[i, j].TileType == TileType.Finish)
                    {
                        Finish finishPosition = new Finish();
                        finishPosition.x = i;
                        finishPosition.y = j;
                        itemPositions.Add(finishPosition);
                    }
                }
            }
            Console.WriteLine("Itempositionslist: " + itemPositions.Count);

            int locationPos = 0;
            double minDistance = 0;

            int nextItemX = 0;
            int nextItemY = 0;



            for (int i = 0; i < itemPositions.Count; i++)
            {
                if (checkDistance(request.PartyLocation.X, request.PartyLocation.Y, itemPositions[i].x, itemPositions[i].y) < minDistance || i == 0){
                    minDistance = checkDistance(request.PartyLocation.X, request.PartyLocation.Y, itemPositions[i].x, itemPositions[i].y);
                    locationPos = i;
                    nextItemX = itemPositions[i].x;
                    nextItemY = itemPositions[i].y;


                }
                    
             }
            Console.WriteLine("Next Item Position"+ nextItemX+":"+nextItemY);
            Console.WriteLine("Mindistance: "+minDistance);

                
            return Strategic();

            Task<Turn> Test()
            {


                if (request.IsCombat)
                {
                    Console.WriteLine("Active member " + request.PartyMember.Id);
                }
                //Console.WriteLine("Map: "+request.Map.Tiles[3,3].TileType);

                if (request.PossibleActions.Contains(TurnAction.DrinkPotion))
                {
                    return Task.FromResult(new Turn(TurnAction.DrinkPotion));
                }
                if (request.PossibleActions.Contains(TurnAction.Loot))
                {
                    return Task.FromResult(new Turn(TurnAction.Loot));
                }

                if (request.PossibleActions.Contains(TurnAction.Attack))
                {

                    return Task.FromResult(new Turn(TurnAction.Attack));
                }

                if (request.PossibleActions.Contains(TurnAction.Open))
                {
                    return Task.FromResult(new Turn(TurnAction.Open));
                }


                if (request.PossibleActions.Contains(TurnAction.WalkSouth))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkSouth));
                }

                return Task.FromResult(new Turn(TurnAction.WalkEast));
            }

            Task<Turn> PlayToEnd()
            {
                return Task.FromResult(request.PossibleActions.Contains(TurnAction.WalkSouth) ? new Turn(TurnAction.WalkSouth) : new Turn(request.PossibleActions[_random.Next(request.PossibleActions.Length)]));
            }

            Task<Turn> Strategic()
            {

                Console.WriteLine("Map check:"+ request.Map.Tiles[request.PartyLocation.X,request.PartyLocation.Y].TerrainType);
                const double goingEastBias = 0.35;
                const double goingSouthBias = 0.25;
                if (request.PossibleActions.Contains(TurnAction.Loot))
                {
                    return Task.FromResult(new Turn(TurnAction.Loot));
                }

                if (request.PossibleActions.Contains(TurnAction.Attack))
                {
                    return Task.FromResult(new Turn(TurnAction.Attack));
                }

                if (request.PossibleActions.Contains(TurnAction.WalkEast) && _random.NextDouble() > (1 - goingEastBias))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkEast));
                }

                if (request.PossibleActions.Contains(TurnAction.WalkSouth) && _random.NextDouble() > (1 - goingSouthBias))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkSouth));
                }

                return Task.FromResult(new Turn(request.PossibleActions[_random.Next(request.PossibleActions.Length)]));
            }

            Task<Turn> Strategic2()
            {


                const double goingEastBias = 0.35;
                const double goingSouthBias = 0.25;
                if (request.PossibleActions.Contains(TurnAction.Loot))
                {
                    return Task.FromResult(new Turn(TurnAction.Loot));
                }

                if (request.PossibleActions.Contains(TurnAction.Attack))
                {
                    return Task.FromResult(new Turn(TurnAction.Attack));
                }

                if (request.PossibleActions.Contains(TurnAction.WalkEast) && _random.NextDouble() > (1 - goingEastBias))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkEast));
                }

                if (request.PossibleActions.Contains(TurnAction.WalkSouth) && _random.NextDouble() > (1 - goingSouthBias))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkSouth));
                }

                return Task.FromResult(new Turn(request.PossibleActions[_random.Next(request.PossibleActions.Length)]));
            }


            //Class: Battle



            //Task<Turn> TestRun()
            //{
            //    if (request.PossibleActions.Contains(TurnAction.Loot)
            //    {
            //        return Task.FromResult(new Turn(TurnAction.Loot));
            //    }


            //}
        }
    }
}


