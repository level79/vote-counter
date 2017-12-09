using System.Reflection.Metadata.Ecma335;
using Newtonsoft.Json;
using Xunit;

namespace VoteCounter.Test.Unit
{
    public class VoteTest
    {
        [Fact]
        public void VoteIsForTheFirstPreference()
        {
            var vote = new Vote(new []
            {
                new Preference(new Candidate("Bill Gates"), 1),
                new Preference(new Candidate("Fred Flinstone"), 2)
            });
            
            Assert.Equal("Bill Gates", vote.Primary.Value);
        }

        [Fact]
        public void VoteIsForHighestPrefernceAfterEliminatedCandidate()
        {
            var bill = new Candidate("Bill Gates");
            var fred = new Candidate("Fred Flintstone");
            var vote = new Vote(new []
            {
                new Preference(bill, 1),
                new Preference(fred, 2)
            });

            var nextPreferenceName = vote.Preference(new []{ bill, }).Value;
            Assert.Equal("Fred Flintstone", nextPreferenceName);
        }

        [Fact]
        public void VoteExhausted()
        {
            var bill = new Candidate("Bill Gates");
            var fred = new Candidate("Fred Flintstone");
            var vote = new Vote(new []
            {
                new Preference(bill, 1),
                new Preference(fred, 2)
            });
            
            Assert.False(vote.IsExhausted(new Candidate[0]));
            Assert.True(vote.IsExhausted(new []{bill, fred}));
        }

        [Fact]
        public void VoteIsFormal()
        {
            var bill = new Candidate("Bill Gates");
            var fred = new Candidate("Fred Flintstone");
            var vote = new Vote(new []
            {
                new Preference(bill, 1),
                new Preference(fred, 2)
            });
            
            Assert.True(vote.IsFormal);
        }
        
        [Fact]
        public void VoteIsNotFormal()
        {
            var bill = new Candidate("Bill Gates");
            var fred = new Candidate("Fred Flintstone");
            var vote = new Vote(new []
            {
                new Preference(bill, 1),
                new Preference(fred, 3)
            });
            
            Assert.False(vote.IsFormal);
        }
    }
}