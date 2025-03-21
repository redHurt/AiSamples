using _Project.Common.Ai;
using _Project.Common.Characters.Model;
using _Project.Common.Services;
using _Project.RuleBasedAi.Core;

namespace _Project.RuleBasedAi.Implementation
{
    public class RuleBasedAiFactory : AiFactory
    {
        public RuleBasedAiFactory(CharactersFactory charactersFactory, ActorsRepository actorsRepository,
            CharactersRepository charactersRepository) : base(charactersFactory, actorsRepository, charactersRepository)
        {
        }

        protected override IAiActor CreateAiActor(Character character) =>
            new RuleBasedAiActor(
                new Freeze(character),
                new FindEnemy(character, CharactersRepository),
                new MoveToEnemy(character),
                new Attack(character));
    }
}