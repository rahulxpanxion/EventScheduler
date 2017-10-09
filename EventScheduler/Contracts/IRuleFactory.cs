namespace EventScheduler
{
    public interface IRuleFactory
    {
        IRuleEngine GetRuleEngine();
    }
}