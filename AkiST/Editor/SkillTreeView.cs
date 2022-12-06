using System.Collections.Generic;
using UnityEditor;
using Kurisu.AkiBT;
using Kurisu.AkiBT.Editor;

namespace Kurisu.AkiST.Editor
{
    public class SkillTreeView : BehaviorTreeView
    {
        public SkillTreeView(IBehaviorTree bt, EditorWindow editor) : base(bt, editor)
        {
            provider.SetShowNodeTypes(new List<string>(){"Skill","Math"});
        }
        protected override string treeEditorName=>"AkiST";
        protected override bool Validate()
        {
            var stack = new Stack<BehaviorTreeNode>();
            bool findExit=false;
            stack.Push(root);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                if (!node.Validate(stack))
                {
                    return false;
                }
                if(node.GetBehavior().Equals(typeof(SkillExit))||node.GetBehavior().Equals(typeof(SkillSequence)))findExit=true;
            }
            if(!findExit)return false;
            return true;
        }
    }
}