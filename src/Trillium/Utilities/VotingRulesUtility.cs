using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trillium.Utilities
{
    internal class VotingRulesUtility
    {
        public static List<ClassUtility.VotingRules> CreateRules(int maxVotesAllowed, string voteToken, int maxVotingDays, bool isTxRequired)
        {
            List<ClassUtility.VotingRules> votingRules = new List<ClassUtility.VotingRules>();

            ClassUtility.VotingRules voteAmountRule = new ClassUtility.VotingRules
            {
                RuleName = "Max Votes Allowed",
                RuleSummary = "This is the max amount of times a token holder can vote on a topic",
                RuleType = "Int",
                RuleValue = maxVotesAllowed
            };

            votingRules.Add(voteAmountRule);

            ClassUtility.VotingRules voteTokenRule = new ClassUtility.VotingRules
            {
                RuleName = "Vote Token",
                RuleSummary = "This is the token that must be used in ALL votes. It is required to be signed in the following format. {Address + TimeStamp + Token)",
                RuleType = "String",
                RuleValue = voteToken
            };

            votingRules.Add(voteTokenRule);

            ClassUtility.VotingRules maxVotingDaysRule = new ClassUtility.VotingRules
            {
                RuleName = "Maximum Voting Days",
                RuleSummary = "This is the max amount of times a topic may last for. 30 days is the default and highest value.",
                RuleType = "Int",
                RuleValue = maxVotingDays
            };

            votingRules.Add(maxVotingDaysRule);

            ClassUtility.VotingRules isTXRequiredRule = new ClassUtility.VotingRules
            {
                RuleName = "Transaction Required",
                RuleSummary = "If this is true a TX showing ownership of token must be provided to prove you did not acquire coin after the topic has started.",
                RuleType = "Bool",
                RuleValue = isTxRequired
            };

            votingRules.Add(isTXRequiredRule);

            return votingRules;
        }
    }
}
