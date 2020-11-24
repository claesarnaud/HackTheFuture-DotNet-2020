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

        List<Position> discoveredLocations = new List<Position>();
        Position tracker = null;

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
                    //if (request.Map.Tiles[i, j].TileType == TileType.Finish)
                    //{
                    //    Finish finishPosition = new Finish();
                    //    finishPosition.x = i;
                    //    finishPosition.y = j;
                    //    itemPositions.Add(finishPosition);
                    //}
                }
            }
            Console.WriteLine("Itempositionslist: " + itemPositions.Count);
            Console.WriteLine("");

            int locationPos = 0;
            double minDistance = 1000;

            discoveredLocations.Add(new DiscoveredLocation() { x = request.PartyLocation.X, y = request.PartyLocation.Y });

            for (int i = 0; i < itemPositions.Count; i++)
            {
                for (int j = 0; j < discoveredLocations.Count; j++)
                {
                    if(itemPositions[i].x != discoveredLocations[j].x && itemPositions[i].y != discoveredLocations[j].y)
                    {
                        if (checkDistance(request.PartyLocation.X, request.PartyLocation.Y, itemPositions[i].x, itemPositions[i].y) < minDistance)
                        {
                            minDistance = checkDistance(request.PartyLocation.X, request.PartyLocation.Y, itemPositions[i].x, itemPositions[i].y);
                            locationPos = i;
                        }
                    }
                }         
            }

            if(tracker == null)
            {
                tracker = itemPositions[locationPos];
            }

            Console.WriteLine("Next Item Position "+ tracker.x + " : "+ tracker.y);
            Console.WriteLine("Mindistance: "+minDistance);
            Console.WriteLine("Playerposition: "+request.PartyLocation.X+" : "+request.PartyLocation.Y );

                
            return Test();

            Task<Turn> Test()
            { 
                if (request.IsCombat)
                {
                    if (request.PartyMember.CurrentHealthPoints < 5 && request.PossibleActions.Contains(TurnAction.DrinkPotion))
                    {
                        return Task.FromResult(new Turn(TurnAction.DrinkPotion));
                    }
                }

                if (request.PossibleActions.Contains(TurnAction.Attack))
                {
                    discoveredLocations.Add(tracker);
                    tracker = null;
                    return Task.FromResult(new Turn(TurnAction.Attack));
                }

                if (request.PossibleActions.Contains(TurnAction.Loot))
                {
                    discoveredLocations.Add(tracker);
                    tracker = null;
                    return Task.FromResult(new Turn(TurnAction.Loot));
                }


                Navigate nextItem = new Navigate(request, tracker.x, tracker.y);
                Console.WriteLine("Discovered locationslist:"+discoveredLocations.Count);
                return nextItem.ShortestRoute();
                //return Task.FromResult(new Turn(TurnAction.WalkEast));
            }

        }
    }
}


