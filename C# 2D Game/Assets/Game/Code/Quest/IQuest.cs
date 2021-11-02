using System;

namespace Game.Code.Quest
{
  public interface IQuest
  {
    event Action<IQuest> Completed;
    bool IsComplete { get; }
    void Reset();
  }
}