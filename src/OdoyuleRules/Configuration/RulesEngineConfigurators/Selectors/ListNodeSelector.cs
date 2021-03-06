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
namespace OdoyuleRules.Configuration.RulesEngineConfigurators.Selectors
{
    using System;
    using Models.RuntimeModel;
    using Visualization;

    public class ListNodeSelector<T, TElement> :
        NodeSelector
    {
        readonly int _index;
        readonly NodeSelector _next;

        public ListNodeSelector(NodeSelector next, int index)
        {
            _index = index;
            _next = next;
        }

        public Type NodeType
        {
            get { return typeof (T); }
        }

        public NodeSelector Next
        {
            get { return _next; }
        }

        public void Select()
        {
            throw new NotImplementedException();
        }

        public void Select<TNode>(Node<TNode> node) where TNode : class
        {
            throw new NotImplementedException();
        }

        public void Select<TNode>(MemoryNode<TNode> node) where TNode : class
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("List Index: [{0}], {1} => {2}", typeof(T).Tokens(), _index, typeof(TElement).Name);
        }
    }
}