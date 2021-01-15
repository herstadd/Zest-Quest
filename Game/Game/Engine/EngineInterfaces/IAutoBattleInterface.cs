using System.Threading.Tasks;

namespace Game.Engine.EngineInterfaces
{
    public interface IAutoBattleInterface
    {
        IBattleEngineInterface Battle { get;}

        Task<bool> RunAutoBattle();
        bool DetectInfinateLoop();
        bool CreateCharacterParty();
    }
}