using Hogwarts.Core.Models.Authentication;
using System;

namespace Hogwarts.Core.Models.TrainManagement.Services
{
    internal interface ITrainService
    {
        public Train AddTrain(DateTime departureTime,
                              string origin,
                              string destination,
                              string platform,
                              int nCompartments,
                              int nSeatsPerCompartment);

        TrainTicket GetTrainTicket(Train train,
                                   User owner);

        TrainTicket GetNearestTrainTicket(DateTime dateTime,
                                          User owner,
                                          string origin,
                                          string destination);
    }
}
