// Copyright 2011 Chris Patterson
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace OdoyuleRules.Compiling
{
    using Configuration.RulesEngineConfigurators;
    using Models.SemanticModel;
    using Util.Caching;

    public class OdoyuleRuleCompiler :
        RuleCompiler
    {
        readonly RuntimeConfigurator _configurator;
        readonly Cache<string, Rule> _rules;

        public OdoyuleRuleCompiler(RuntimeConfigurator configurator)
        {
            _configurator = configurator;
            _rules = new DictionaryCache<string, Rule>(rule => rule.RuleName);
        }

        public void Add(params Rule[] rules)
        {
            _rules.Fill(rules);
        }

        public RulePackage Compile()
        {
            foreach (Rule rule in _rules)
            {
                CompileRule(rule);
            }

            return null;
        }

        void CompileRule(Rule rule)
        {
            var conditionCompiler = new RuleConditionCompilerImpl(_configurator);

            foreach (RuleCondition condition in rule.Conditions)
            {
                condition.Accept(conditionCompiler);
            }

            var consequenceCompiler = new RuleConsequenceCompilerImpl(_configurator, conditionCompiler);

            foreach (var consequence in rule.Consequences)
            {
                consequence.Accept(consequenceCompiler);
            }
        }
    }
}