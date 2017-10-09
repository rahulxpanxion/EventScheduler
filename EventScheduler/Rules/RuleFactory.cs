using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using static EventScheduler.Enums;

namespace EventScheduler
{
    public class RuleFactory : IRuleFactory
    {
        private static IReadOnlyDictionary<RuleType, Type> ruleMap;
        private readonly IUnityContainer container;
        private readonly IRepositoryCollection repository;

        static RuleFactory()
        {
            var map = new Dictionary<RuleType, Type>
            {
                { RuleType.TwoMatchHomeAwayRule, typeof(TwoMatchHomeAwayRule)}
            };

            ruleMap = map;
        }

        public RuleFactory(IUnityContainer container, IRepositoryCollection repository)
        {
            if (container == null)
            {
                throw new RuleException("Failed to initialize container");
            }

            this.repository = repository;
            this.container = container;
        }

        /// <summary>
        /// Gets the rule engine.
        /// </summary>
        /// <param name="ruleType">Type of the rule.</param>
        /// <returns></returns>
        public IRuleEngine GetRuleEngine()
        {
            var fixtureSetting = this.repository.RuleRespository.Get().FirstOrDefault();

            if (fixtureSetting == null)
            {
                throw new RuleException("No configured rule found");
            }


            if (ruleMap.ContainsKey(fixtureSetting.Rule))
            {
                return this.container.Resolve(ruleMap[fixtureSetting.Rule]) as IRuleEngine;
            }

            throw new RuleException($"No rule engine found for {fixtureSetting.Rule.ToString()}");
        }
    }
}
