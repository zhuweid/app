using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Machine.Specifications;
using app.windows;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs.windows
{
    [Subject(typeof(NodesFactory))]
    public class NodesFactorySpecs
    {
        public abstract class concern : Observes<NodesFactory>
        {
        }

        public class when_creating_a_directory_node: concern
        {
            Establish c = () =>
                              {
                                  depends.on<IDetermineIfANodeIsADirectory>(x => true);
                                  depends.on<IGetDisplayNodeName>(x => x.Substring(0,4));
                              };

            Because b = () =>
                                node = sut.create_node("some directory entry");

            It should_create_a_directory_node = () =>
                   node.Text.ShouldEqual("some");

            It should_create_a_dummy_child_node = () =>
                   node.FirstNode.ShouldNotBeNull();

            private static TreeNode node;
        }

        public class when_creating_a_file_node : concern
        {
            Establish c = () =>
            {
                depends.on<IDetermineIfANodeIsADirectory>(x => false);
                depends.on<IGetDisplayNodeName>(x => x.Substring(0, 4));
            };

            Because b = () =>
                node = sut.create_node("some directory entry");

            It should_create_a_file_node = () =>
                   node.Text.ShouldEqual("some");

            It should_create_a_dummy_child_node = () =>
                   node.FirstNode.ShouldBeNull();

            private static TreeNode node;
        }
    }

}
