using System;
using System.Linq;
using AutoFixture;
using ExercisesLibrary.Trainings;
using FluentAssertions;
using Xunit;

namespace Tests.Trainings
{
	public class AddParticipantsTest
	{
		private Fixture _fixture = new Fixture();

		[Fact]
		public void if_added_can_be_retrieved_from_collection()
		{
			// Arrange
			var training = new Training();
			var participant = new Participant
			{
				Id = _fixture.Create<int>(),
				Email = _fixture.Create<string>(),
				FirstName = _fixture.Create<string>(),
				LastName = _fixture.Create<string>(),
			};

			// Act
			training.AddParticipant(participant);

			// Assert
			training
				.Participants
				.FirstOrDefault(i => i.Id == participant.Id)
				.Should()
				.NotBeNull();
		}

		[Fact]
		public void cannot_add_duplicate()
		{
			// Arrange
			var training = new Training();
			var participant = new Participant
			{
				Id = _fixture.Create<int>(),
				Email = _fixture.Create<string>(),
				FirstName = _fixture.Create<string>(),
				LastName = _fixture.Create<string>(),
			};
			training.AddParticipant(participant);

			// Act
			training.AddParticipant(participant);

			// Assert
			training
				.Participants
				.Count(i => i.Id == participant.Id)
				.Should()
				.Be(1);
		}

		[Fact]
		public void cannot_add_score_for_not_existing_participant()
		{
			// Arrange
			var training = new Training();

			// Act
			Action action = () => training.SetScore(1, 10.0);

			// Assert
			action.Should().Throw<Exception>();
		}
	}
}