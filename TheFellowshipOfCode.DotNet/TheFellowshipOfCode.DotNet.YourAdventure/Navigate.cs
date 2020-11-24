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
    class Navigate
    {
        public int positionItemX = 0;
        public int positionItemY = 0;

        public int playerX = 0;
        public int playerY = 0;

        PlayTurnRequest request;

        public Navigate(PlayTurnRequest _request, int _positionItemX, int _positionItemY)
        {
            request = _request;
            positionItemX = _positionItemX;
            positionItemY = _positionItemY;
        }

        public Task<Turn> ShortestRoute()
        {
            if (request.PartyLocation.X == positionItemX && request.PartyLocation.Y > positionItemY)
            {
                if (request.PossibleActions.Contains(TurnAction.WalkNorth))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkNorth));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkWest))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkWest));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkSouth))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkSouth));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkEast))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkEast));
                }
            }
            if (request.PartyLocation.X == positionItemX && request.PartyLocation.Y < positionItemY)
            {
                if (request.PossibleActions.Contains(TurnAction.WalkSouth))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkSouth));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkWest))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkWest));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkNorth))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkNorth));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkEast))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkEast));
                }
            }
            if (request.PartyLocation.X > positionItemX && request.PartyLocation.Y == positionItemY)
            {
                if (request.PossibleActions.Contains(TurnAction.WalkWest))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkWest));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkNorth))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkNorth));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkSouth))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkSouth));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkEast))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkEast));
                }
            }
            if (request.PartyLocation.X < positionItemX && request.PartyLocation.Y == positionItemY)
            {
                if (request.PossibleActions.Contains(TurnAction.WalkEast))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkEast));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkWest))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkWest));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkSouth))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkSouth));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkNorth))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkNorth));
                }
            }
           
            if (request.PartyLocation.X >= positionItemX && request.PartyLocation.Y >= positionItemY)
            {
                if (request.PossibleActions.Contains(TurnAction.WalkNorth))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkNorth));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkWest))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkWest));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkSouth))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkSouth));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkEast))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkEast));
                }
            }

            if (request.PartyLocation.X >= positionItemX && request.PartyLocation.Y >= positionItemY)
            {
                if (request.PossibleActions.Contains(TurnAction.WalkNorth))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkNorth));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkWest))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkWest));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkSouth))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkSouth));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkEast))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkEast));
                }
            }

            if (request.PartyLocation.X <= positionItemX && request.PartyLocation.Y <= positionItemY)
            {
                if (request.PossibleActions.Contains(TurnAction.WalkEast))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkEast));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkSouth))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkSouth));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkNorth))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkNorth));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkWest))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkWest));
                }
            }


            if (request.PartyLocation.X <= positionItemX && request.PartyLocation.Y >= positionItemY)
            {
                if (request.PossibleActions.Contains(TurnAction.WalkEast))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkEast));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkNorth))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkNorth));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkSouth))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkSouth));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkWest))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkWest));
                }
            }

                if (request.PartyLocation.X >= positionItemX && request.PartyLocation.Y <= positionItemY)
                {
                    if (request.PossibleActions.Contains(TurnAction.WalkSouth))
                    {
                        return Task.FromResult(new Turn(TurnAction.WalkSouth));
                    }
                    if (request.PossibleActions.Contains(TurnAction.WalkWest))
                    {
                        return Task.FromResult(new Turn(TurnAction.WalkWest));
                    }
                    if (request.PossibleActions.Contains(TurnAction.WalkNorth))
                    {
                        return Task.FromResult(new Turn(TurnAction.WalkNorth));
                    }
                    if (request.PossibleActions.Contains(TurnAction.WalkEast))
                    {
                        return Task.FromResult(new Turn(TurnAction.WalkEast));
                    }
                }

                return Task.FromResult(new Turn(TurnAction.WalkSouth));
            }
        }
    }
