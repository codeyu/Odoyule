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
namespace OdoyuleRules.Models.SemanticModel
{
    using System.Reflection;

    public class PropertyLessThanOrEqualCondition<T, TProperty> :
        PropertyCondition<T, TProperty>,
        RuleCondition<T>
        where T : class
    {
        readonly TProperty _value;

        public PropertyLessThanOrEqualCondition(PropertyInfo propertyInfo, TProperty value)
            : base(propertyInfo)
        {
            _value = value;
        }

        public TProperty Value
        {
            get { return _value; }
        }
    }
}