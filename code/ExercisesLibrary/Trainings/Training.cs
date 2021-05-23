using System;
using System.Collections.Generic;
using System.Linq;

namespace ExercisesLibrary.Trainings
{
	public class Training
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public List<Participant> Participants { get; private set; }

		public Training()
		{
			Participants = new List<Participant>();
		}

		public void AddParticipant(Participant participant)
		{
			if (Participants.Any(i => i.Id == participant.Id))
			{
				return;
			}

			Participants.Add(participant);
		}

		public void SetScore(int participantId, double score)
		{
			var participant = Participants
				.FirstOrDefault(p => p.Id == participantId);

			if (participant == null)
			{
				throw new Exception("Participant does not exist");
			}

			participant.Score = score;
		}

		public double GetAverageScore()
		{
			return Participants.Average(participant => participant.Score);
		}

		public List<Participant> GetTopParticipants(int count)
		{
			var topParticipants = Participants
				.OrderByDescending(i => i.Score)
				.Take(count);

			return topParticipants.ToList();
		}

		public decimal CalculateCosts()
		{
			var trainer = 1000.0m;
			var cateringPerPerson = 50.50m;
			var room = 2000.0m;

			return Participants.Count * cateringPerPerson + trainer + room;
		}
	}
}